using UnityEngine;

public class IceSpike : MonoBehaviour, IPauseable
{
    [SerializeField] private float speed;
    [SerializeField] private DamageData DamageData;
    private float speedBeforePause;

    private void Awake()
    {
        speedBeforePause = speed;
    }

    void Update()
    {
        transform.Translate(new Vector2(0f, 1f) * (Time.deltaTime * speed));
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
    
    public void Pause()
    {
        speed = 0;
    }

    public void UnPause()
    {
        speed = speedBeforePause;
    }
}
