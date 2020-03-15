using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteEffectFactory : MonoBehaviour
{
    public static SpriteEffectFactory instance;


    private Dictionary<string, GameObject> spriteEffectsByName;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        spriteEffectsByName = new Dictionary<string, GameObject>();
        ImportSpriteEffect();
    }

    private void ImportSpriteEffect()
    {
        
        var objs = Resources.LoadAll("Sprite Effects");
        foreach (var obj in objs)
        {
            GameObject spriteEffect = (GameObject) obj;
            if (spriteEffect == null)
            {
                Debug.LogError("Loading asset error");
            }
            spriteEffectsByName.Add(spriteEffect.name, spriteEffect);
        }
    }


    public void SpawnEffect(string spriteEffectName ,Transform spawnTransform)
    {
        Instantiate(GetSpriteEffectByName(spriteEffectName), spawnTransform.position, Quaternion.identity);
    }

    private GameObject GetSpriteEffectByName(string spriteName)
    {
        if (spriteEffectsByName.ContainsKey(spriteName))
        {
            return spriteEffectsByName[spriteName];
        }
        Debug.LogError("Can't find sprite effect with name "+spriteName);
        return null;
    }

}



