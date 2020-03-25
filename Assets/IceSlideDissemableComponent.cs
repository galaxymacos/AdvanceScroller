using DG.Tweening;
using UnityEngine;

public class IceSlideDissemableComponent : MonoBehaviour
{
    
    private void Awake()
    {
        IceSlideEventSystem.onIceSlideFinish += Shrink;
        IceSlideEventSystem.onIceSlideShrinkFinish += AutoDestroy;
        transform.localScale = new Vector3(0.01f,0.01f,0.01f);
        Enlarge();
    }

    private void OnDestroy()
    {
        IceSlideEventSystem.onIceSlideFinish -= Shrink;
        IceSlideEventSystem.onIceSlideShrinkFinish -= AutoDestroy;

    }


    private void Shrink()
    {
        Debug.Log("Cloud Destroy");
        transform.DOScale(new Vector3(0.01f,0.01f,0.01f), 1).SetEase(Ease.InQuad).OnComplete(IceSlideEventSystem.instance.IceSlideShrinkFinish);
    }

    private void Enlarge()
    {
        transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.InQuad).OnComplete(IceSlideEventSystem.instance.IceSlideEnlargeFinish);
    }

    private void AutoDestroy()
    {
        IceSlideEventSystem.instance.IceSlideDestroy();
        Destroy(gameObject);
    }
}
