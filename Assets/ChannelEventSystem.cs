using System;
using System.Collections;
using UnityEngine;

public class ChannelEventSystem : MonoBehaviour
{
    public static ChannelEventSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static event Action<Channel, PlayerCharacter> onPlayerGoInToChannel;
    public static event Action<Channel> onChannelNotAvailable;
    public static event Action<Channel> onChannelAvailable;

    

    public void PlayerGoIntoChannel(Channel channel, PlayerCharacter playerCharacter)
    {
        onPlayerGoInToChannel?.Invoke(channel, playerCharacter);
    }

    public void ChannelBecomeAvailable(Channel channel)
    {
        onChannelAvailable?.Invoke(channel);
    }

    public void ChannelBecomeUnavailable(Channel channel)
    {
        onChannelNotAvailable?.Invoke(channel);
    }
}