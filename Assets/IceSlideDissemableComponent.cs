using DG.Tweening;
using UnityEngine;

public class IceSlideDissemableComponent : MonoBehaviour
{
    
    private void Awake()
    {
        IceSlideEventSystem.onIceSlideFinish += Shrink;
        IceSlideEventSystem.onIceSlideShrinkFinish += AutoDestroy;
        transform.localScale = Vector3.zero;
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
        transform.DOScale(Vector3.zero, 2).SetEase(Ease.InQuad).OnComplete(IceSlideEventSystem.instance.IceSlideShrinkFinish);
    }

    private void Enlarge()
    {
        transform.DOScale(Vector3.one, 2).SetEase(Ease.InQuad).OnComplete(IceSlideEventSystem.instance.IceSlideEnlargeFinish);
    }

    private void AutoDestroy()
    {
        IceSlideEventSystem.instance.IceSlideDestroy();
        Destroy(gameObject);
    }
}
