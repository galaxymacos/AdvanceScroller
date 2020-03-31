using UnityEngine;


public class IceSpike : MonoBehaviour, IPauseable
{
    [SerializeField] private float speed;
    [SerializeField] private DamageData DamageData;
    [SerializeField] private ParticleSystem IceSpikeExplosion;

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
        var damageReceiver = other.GetComponent<IDamageReceiver>();

        if (damageReceiver != null)
        {
            damageReceiver.Analyze(DamageData, transform);
            Destroy(gameObject);
            Vector3 vector3 = new Vector3(0f, 1f, 0f);
            IceSpikeExplosion = Instantiate(IceSpikeExplosion, 
                other.transform.position + vector3, Quaternion.identity);
            Destroy(IceSpikeExplosion , 2.0f);
            


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
