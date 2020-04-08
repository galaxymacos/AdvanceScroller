using UnityEngine;

public class GhostDieBehaviour : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayDieAnimation()
    {
        anim.SetTrigger("die");
    }
}