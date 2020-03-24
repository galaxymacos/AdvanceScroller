using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerPushoutSystem : MonoBehaviour
{
    [SerializeField] private List<Channel> channels;
    public Dictionary<Channel, float> channelRuntimeDictionary;
    [SerializeField] private float channelCooldown = 5f;

    
    private void Awake()
    {
        channelRuntimeDictionary = new Dictionary<Channel, float>();
        foreach (var channel in channels)
        {
            channelRuntimeDictionary.Add(channel, channelCooldown);
            ChannelEventSystem.instance.ChannelBecomeUnavailable(channel);
        }
        ChannelEventSystem.onPlayerGoInToChannel += DistributePlayerToChannel;

    }

    public bool TwoChannelsAvailable()
    {
        int channalAvailable = 0;
        foreach (Channel channel in channelRuntimeDictionary.Keys)
        {
            if (channelRuntimeDictionary[channel] <= 0)
            {
                channalAvailable++;
            }
        }

        return channalAvailable >= 2;
    }

    private void OnDestroy()
    {
        ChannelEventSystem.onPlayerGoInToChannel -= DistributePlayerToChannel;
    }

    private void Update()
    {
        List<Channel> channelsInDic = new List<Channel>(channelRuntimeDictionary.Keys);
        foreach (Channel channel in channelsInDic)
        {
            if (channelRuntimeDictionary[channel] > 0)
            {
                channelRuntimeDictionary[channel] -= Time.deltaTime;
                if (channelRuntimeDictionary[channel] <= 0)
                {
                    channelRuntimeDictionary[channel] = 0;
                    ChannelEventSystem.instance.ChannelBecomeAvailable(channel);
                }
            }
        }
    }

    private void DistributePlayerToChannel(Channel channel, PlayerCharacter playerCharacter)
    {
        if (!TwoChannelsAvailable())
        {
            return;
        }
        if (channelRuntimeDictionary[channel] > 0)
        {
            return;
        }
        if (channels.Count <= 1)
        {
            return;
        }
        
        channelRuntimeDictionary[channel] = channelCooldown;


        List<Channel> freeChannels = new List<Channel>();
        foreach (Channel channelinDic in channelRuntimeDictionary.Keys)
        {
            if (channelRuntimeDictionary[channelinDic] <= 0 && channelinDic!=channel)
            {
                freeChannels.Add(channelinDic);
            }
        }
        int randomChannelIndex = Random.Range(0, freeChannels.Count);

        
        channelRuntimeDictionary[freeChannels[randomChannelIndex]] = channelCooldown;
        print("go from channel " + channel.name + " to channel " + freeChannels[randomChannelIndex].name);

        ChannelEventSystem.instance.ChannelBecomeUnavailable(channel);
        ChannelEventSystem.instance.ChannelBecomeUnavailable(freeChannels[randomChannelIndex]);

        playerCharacter.playerInput.horizontalAxis = 0;
        playerCharacter.transform.position = freeChannels[randomChannelIndex].transform.position;
        
        
    }
}