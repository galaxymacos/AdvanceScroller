using UnityEngine;

public class SceneObjectDestroyOnContactComponent: MonoBehaviour
{
    private void Awake()
    {
        GetComponent<NewProjectileDamageComponent>().onDamageDealt += SelfDestroy;
    }

    private void OnDestroy()
    {
        GetComponent<NewProjectileDamageComponent>().onDamageDealt -= SelfDestroy;
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}