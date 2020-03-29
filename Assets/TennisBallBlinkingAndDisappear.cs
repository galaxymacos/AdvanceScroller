using System.Collections;
using UnityEngine;

public class TennisBallBlinkingAndDisappear : MonoBehaviour
{
    private SpriteRenderer sr;

    private bool isDisappearing = false;
    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        GetComponent<NewProjectileDamageComponent>().onDamageDealt += Blink;
        GetComponent<TennisBallTimer>().onTimeOut += Blink;
    }

    private void OnDestroy()
    {
        GetComponent<NewProjectileDamageComponent>().onDamageDealt -= Blink;
        GetComponent<TennisBallTimer>().onTimeOut -= Blink;
    }

    private void Blink()
    {
        if (isDisappearing) return;
        StartBlinkingEffect();
        StartCoroutine(Blinking());
        isDisappearing = true; 
    }

    private void StartBlinkingEffect()
    {
        Color color = sr.color;
        color.a = 0;
        sr.color = color;
    }

    private IEnumerator Blinking()
    {
        for (int i = 0; i < 10; i++)
        {
            StartBlinkingEffect();
            yield return new WaitForSeconds(0.1f);
            StopBlinkingEffect();
            yield return new WaitForSeconds(0.1f);
        }
        Disappear();
    }

    private void StopBlinkingEffect()
    {
        Color color = sr.color;
        color.a = 255;
        sr.color = color;
    }

    private void Disappear()
    {
        Destroy(gameObject);
    }

}
