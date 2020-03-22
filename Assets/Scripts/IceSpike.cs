using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpike : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private DamageData DamageData;

    void Update()
    {
        transform.Translate(new Vector2(0f, 1f) * Time.deltaTime * speed);
        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageReceiver = other.GetComponent<DamageReceiver>();
        if (damageReceiver != null)
        {
            damageReceiver.Analyze(DamageData, transform);

        }
    }
}
