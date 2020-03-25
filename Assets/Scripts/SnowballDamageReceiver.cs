using UnityEngine;

public class SnowballDamageReceiver: MonoBehaviour, IDamageReceiver
{
    [SerializeField] private Vector3 flyDirection = new Vector3(10f, 5f, 0.0f);

    [SerializeField] private float flySpeedGainPerDamage = 3f;

    public void Analyze(DamageData damageData, Transform damageOwner)
    {
        print("analyze damage data");

        var facingleft = damageOwner.position.x - transform.position.x > 0;
        flyDirection = facingleft
            ? new Vector3(-flyDirection.x, flyDirection.y, flyDirection.z)
            : flyDirection;
        flyDirection.Set((facingleft ? -flySpeedGainPerDamage : flySpeedGainPerDamage) * damageData.damage, flyDirection.y, flyDirection.z);
        var rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        rb.AddForce(flyDirection);
    }
}