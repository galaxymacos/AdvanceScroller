using UnityEngine;

public class ParticleDisposer : MonoBehaviour
{
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(transform.root.gameObject, delay);
    }
}