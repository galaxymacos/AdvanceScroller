using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ChannelErrorPlacer : MonoBehaviour
{
    public Channel channel;
    public Sprite errorPicture;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        ChannelEventSystem.onChannelNotAvailable += ShowErrorPicture;
        ChannelEventSystem.onChannelAvailable += HideErrorPicture;
    }

    private void HideErrorPicture(Channel obj)
    {
        if (obj == channel)
            sr.sprite = null;
    }

    private void ShowErrorPicture(Channel obj)
    {
        if (obj == channel)
            sr.sprite = errorPicture;
    }
}