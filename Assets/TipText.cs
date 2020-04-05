using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class TipText : MonoBehaviour
{
    public Tip[] tips;

    public float tipShowInterval = 3f;
    public TextMeshProUGUI text;
    private float tipShowTimeCounter;

    private int tipIndexToShow;

    private bool ShouldHide;
    // Start is called before the first frame update

    private void OnEnable()
    {
        Randomize(tips);
        tipShowTimeCounter = 0.1f;
        ChangeTextContent();
    }

    private void Randomize(Tip[] _tips)
    {
        for (int i = _tips.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Tip temp = _tips[i];
            _tips[i] = _tips[j];
            _tips[j] = temp;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (tipShowTimeCounter > 0)
        {
            tipShowTimeCounter -= Time.deltaTime;
            if (tipShowTimeCounter <= 0)
            {
                print("Change show stats");
                if (ShouldHide)
                {
                    DOTween.To(() => text.alpha, result => text.alpha = result, 0, 2f).OnComplete(AppearDisappear);
                }
                else
                {
                    DOTween.To(() => text.alpha, result => text.alpha = result, 1, 2f).OnComplete(AppearDisappear);
                }
                
            }
        }
    }

    private void AppearDisappear()
    {
        ChangeStats();

        if (!ShouldHide)
        {
            ChangeTextContent();
        }
    }

    private void ChangeTextContent()
    {
        if (tipIndexToShow < tips.Length - 1)
        {
            tipIndexToShow++;
        }
        else
        {
            tipIndexToShow = 0;
        }
        text.text = tips[tipIndexToShow].text;
    }

    private void ChangeStats()
    {
        if (ShouldHide)
        {
            tipShowTimeCounter = 0.1f;
        }
        else
        {
            tipShowTimeCounter = tipShowInterval;
        }
        ShouldHide = !ShouldHide;
    }
}