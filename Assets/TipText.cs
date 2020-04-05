using DG.Tweening;
using TMPro;
using UnityEngine;

public class TipText : MonoBehaviour
{
    public Tip[] tips;

    public float tipShowInterval = 3f;
    public TextMeshProUGUI text;
    private float tipShowTimeCounter;

    private int tipIndexToShow;

    private bool ShouldHide;
    // Start is called before the first frame update
    void Start()
    {
        Randomize(tips);
        tipShowTimeCounter = tipShowInterval;
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
                if (ShouldHide)
                {
                    DOTween.To(() => text.alpha, result => text.alpha = result, 0, 2f).OnComplete(ChangeTextContent);
                }
                else
                {
                    DOTween.To(() => text.alpha, result => text.alpha = result, 1, 2f).OnComplete(ChangeTextContent);
                }
                
            }
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

        if (ShouldHide)
        {
            text.text = tips[tipIndexToShow].text;
            tipShowTimeCounter = 0.1f;
        }
        else
        {
            tipShowTimeCounter = tipShowInterval;
        }
        ShouldHide = !ShouldHide;
    }
}