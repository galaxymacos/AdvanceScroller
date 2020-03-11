using UnityEngine;

public class ParticleSystemRecycler: MonoBehaviour
{
    [SerializeField] private float delay = 5f;

    private void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}