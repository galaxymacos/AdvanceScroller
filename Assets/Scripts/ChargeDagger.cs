using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class ChargeDagger: ChargeSkill
{
    public float sizeIncreaseFactor = 0.6f;
    public float rotateSpeed = 180f;
    private Projectile projectile;
    public GameObject daggerPrefab;
    public bool setUpFacing;
    private void Start()
    {
        print("spawn charge dagger");
        projectile = GetComponent<Projectile>();
    }

    

    public override void Update()
    {
        if (!setUpFacing && owner != null)
        {
            
            if (!owner.isFacingRight)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y,transform.localScale.z);
                setUpFacing = true;
                isFacingRight = false;
            }
            else
            {
                setUpFacing = true;
                isFacingRight = true;
            }

            transform.position = owner.transform.Find("SpawnLocations").Find("ChargedSword").position;
        }
        base.Update();
        if (!isChargingFinished)
        {
            transform.localScale *= 1 + sizeIncreaseFactor * Time.deltaTime;
        }
        else
        {
            if (isFacingRight)
            {
                transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);

            }
        }
    }

    protected override void OnChargingFull()
    {
        
    }

    protected override void OnChargingStart()
    {
        
    }

    protected override void OnChargingCancel()
    {
        var dagger = Instantiate(daggerPrefab, transform.position, Quaternion.identity);
        var daggerProjectile = dagger.GetComponent<Projectile>();
        daggerProjectile.Setup(owner);
        GetComponent<Projectile>().destroyWithoutDeadEffect = true;
        Destroy(gameObject);
    }

    protected override void OnChargingInterupt()
    {
        Destroy(gameObject);
    }

    protected override void OnChargingSuccess()
    {
        projectile = GetComponent<Projectile>();
        projectile.Setup(owner, 100, isFacingRight?transform.rotation.eulerAngles.z:-transform.rotation.eulerAngles.z, true);
        enabled = false;

    }
}