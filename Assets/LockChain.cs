using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockChain : MonoBehaviour
{
    public StateMachine _stateMachine;
    public LockChainEventSystem eventSystem;

    public IState flyToEnemy;
    public IState hitEnemy;
    public IState pullBack;
    public GameObject owner;
    public DamageData damageDataWhenHitEnemy;

    public List<Collider2D> lockChainColliders;

    public GameObject enemyHit;
    public event Action<Collider2D> onCollideWith;
    
    public float timeToStun = 0.5f;
    private void Awake()
    {
        _stateMachine = new StateMachine();
    }

    public void Setup(GameObject _owner)
    {
        owner = _owner;
    }

    private void Start()
    {
        flyToEnemy = new FlyToEnemy(this); 
        hitEnemy = new HitEnemy(this);
        pullBack = new PullBack(this);
        
        _stateMachine.SetState(flyToEnemy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        onCollideWith?.Invoke(other);
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
    
    private void Update()
    {
        _stateMachine.Tick();
    }
}

public class LockChainEventSystem : MonoBehaviour
{
    
}

public class HitEnemy : IState
{
    
    private LockChain lockChain;

    private float timeToStunCounter;
    
    public HitEnemy(LockChain lockChain)
    {
        this.lockChain = lockChain;
    }
    public void Tick()
    {
        Debug.Log("lock chain hit enemy state ticking");
        if (timeToStunCounter > 0)
        {
            timeToStunCounter -= Time.deltaTime;
            if (timeToStunCounter <= 0)
            {
                TransferToPullBack();
            }
        }
        
    }

    public void OnEnter()
    {
        lockChain.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        lockChain.enemyHit.GetComponent<IDamageReceiver>().Analyze(lockChain.damageDataWhenHitEnemy,lockChain.transform);
        timeToStunCounter = lockChain.timeToStun;
        lockChain.lockChainColliders= new List<Collider2D>();
        foreach (var col in lockChain.enemyHit.GetComponents<Collider2D>())
        {
            if (col.enabled)
            {
                lockChain.lockChainColliders.Add(col);
                col.enabled = false;
            }
        }

        lockChain.enemyHit.GetComponent<Rigidbody2D>().gravityScale = 0;
        lockChain.enemyHit.transform.SetParent(lockChain.transform);
        
    }

    public void OnExit()
    {
    }
    
    private void TransferToPullBack()
    {
        lockChain._stateMachine.SetState(lockChain.pullBack);

    }
    
    
}

public class FlyToEnemy: IState
{

    private LockChain lockChain;

    public FlyToEnemy(LockChain lockChain)
    {
        this.lockChain = lockChain;
    }
    public void Tick()
    {
        Debug.Log("Fly to enemy state ticking");

    }

    public void OnEnter()
    {
        lockChain.onCollideWith += TransferToHitEnemy;
    }

    public void OnExit()
    {
        lockChain.onCollideWith -= TransferToHitEnemy;
    }

    private void TransferToHitEnemy(Collider2D collider2D)
    {
        if (collider2D.gameObject != lockChain.owner && collider2D.gameObject.CompareTag("Player"))
        {
            Debug.Log("send player hit");
            lockChain.enemyHit = collider2D.gameObject;
            lockChain._stateMachine.SetState(lockChain.hitEnemy);
        }
    }
}

public class PullBack:IState
{
    private LockChain lockChain;
    private float pullBackSpeed;
    private float timeToPullBack;

    public PullBack(LockChain lockChain)
    {

        this.lockChain = lockChain;
    }
    public void Tick()
    {
        Debug.Log("Pull back state ticking");

        if (Vector3.Distance(lockChain.owner.transform.position, lockChain.transform.position) > 0.5)
        {
            lockChain.GetComponent<Rigidbody2D>().velocity =
                (lockChain.owner.transform.position-lockChain.transform.position).normalized * pullBackSpeed;
            lockChain.enemyHit.GetComponent<Rigidbody2D>().MovePosition(lockChain.transform.position);
        }
        else
        {
            foreach (Collider2D col in lockChain.lockChainColliders)
            {
                col.enabled = true;
            }

            lockChain.enemyHit.GetComponent<Rigidbody2D>().gravityScale = 1;


            lockChain.lockChainColliders.Clear();
            lockChain.enemyHit.transform.SetParent(null);
            lockChain.SelfDestroy();
        }
        
        
    }

    public void OnEnter()
    {
        timeToPullBack = lockChain.damageDataWhenHitEnemy.hitStunPower - lockChain.timeToStun;
        pullBackSpeed = Vector3.Distance(lockChain.owner.transform.position, lockChain.transform.position) /
                        (lockChain.damageDataWhenHitEnemy.hitStunPower - lockChain.timeToStun);
    }

    public void OnExit()
    {
        

    }
}





