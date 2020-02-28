using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Projectile))]
public class ProjectileReturnableComponent: MonoBehaviour
{
    public PlayerCharacter owner;
    [SerializeField] public float maxReturnSpeed = 10;
    [SerializeField] public float speedToGetMaxVelocity = 8;
    [SerializeField] public float maxDistanceToTravel = 10;
    public Vector2 originalPosition;
    public Rigidbody2D rb;
    private bool hasSetup;
    private IAxeReturnMover axeReturnMover;

    public Action onProjectileAtMaximumDistance;
    

    private void Awake()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        onProjectileAtMaximumDistance += ResetProjectile;
        axeReturnMover = new AxeReturnMoverSmooth(this);
    }

    private void OnEnable()
    {
        GetComponent<Projectile>().onSetupFinished += Setup;
    }

    private void OnDisable()
    {
        GetComponent<Projectile>().onSetupFinished -= Setup;
    }

    public void Setup(Projectile _projectile)
    {
        owner = _projectile.owner;
        hasSetup = true;
    }

    public bool isReturningToOwner;


    private void Update()
    {
        if (!hasSetup)
        {
            return;
        }
        
        axeReturnMover.Tick();
        print($"{hasSetup}   {isReturningToOwner}");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasSetup || !isReturningToOwner) return;
        if (other.gameObject == owner.gameObject)
        {
            print("Try to destroy");
            DestroyWhenProjectileReturnToOwner();
        }
    }

    private void DestroyWhenProjectileReturnToOwner()
    {
        Destroy(gameObject);
    }

    private void ResetProjectile()
    {
        print("reset projectile");
        GetComponent<Projectile>().ResetAttack();
    }
}

public interface IAxeReturnMover
{
    void Tick();
}

public class AxeReturnMoverOnMaxDistance: IAxeReturnMover
{
    private readonly ProjectileReturnableComponent _prc;
    public AxeReturnMoverOnMaxDistance(ProjectileReturnableComponent prc)
    {
        _prc = prc;
    }
    public void Tick()
    {
        if (Vector2.Distance(_prc.originalPosition, _prc.transform.position) >= _prc.maxDistanceToTravel && !_prc.isReturningToOwner)
        {
            _prc.isReturningToOwner = true;
            _prc.onProjectileAtMaximumDistance?.Invoke();
            
        }

        if (_prc.isReturningToOwner)
        {
            Vector3 distanceToOwner = _prc.owner.transform.position - _prc.transform.position;
            float speedFactor = distanceToOwner.magnitude / _prc.speedToGetMaxVelocity;

            Vector3 returnDirection = distanceToOwner.normalized;
            Vector3 returnVelocity = speedFactor * _prc.maxReturnSpeed * returnDirection;
            _prc.rb.velocity = returnVelocity;
        }
    }
}

public class AxeReturnMoverSmooth: IAxeReturnMover
{
    private readonly ProjectileReturnableComponent _prc;
    private float returnSpeedFactor = 0.01f;
    public float contractSpeed = 0.01f;    // per second
    private float lastContractTime;
    private Vector3 velocityLastFrame;
    
    
    public AxeReturnMoverSmooth(ProjectileReturnableComponent prc)
    {
        _prc = prc;
    }
    public void Tick()
    {
        Vector3 velocityThisFrame = _prc.rb.velocity;

        if (Time.time > lastContractTime + 1)
        {
            returnSpeedFactor += contractSpeed;
            lastContractTime = Time.time;
        }

        _prc.rb.AddForce(100*new Vector2(((_prc.owner.transform.position - _prc.transform.position) * returnSpeedFactor).x, ((_prc.owner.transform.position - _prc.transform.position) * returnSpeedFactor).y));
        // _prc.rb.velocity += new Vector2(((_prc.owner.transform.position - _prc.transform.position) * returnSpeedFactor).x, ((_prc.owner.transform.position - _prc.transform.position) * returnSpeedFactor).y);
        

        if (velocityThisFrame.magnitude > velocityLastFrame.magnitude)
        {
            _prc.isReturningToOwner = true;
            _prc.onProjectileAtMaximumDistance?.Invoke();
        }
        
        velocityLastFrame = _prc.rb.velocity;
    }
}