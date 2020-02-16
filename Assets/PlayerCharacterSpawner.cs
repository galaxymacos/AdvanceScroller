using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacterSpawner : MonoBehaviour
{

    public List<PlayerInput> playerInputs;
    public List<GameObject> selectedHeros;

    [SerializeField] private GameObject batHeroPrefab;
    [SerializeField] private GameObject SwordPrincessPrefab;
    [SerializeField] private GameObject AxeHeroPrefab;
    [SerializeField] private GameObject PsychicHeroPrefab;


    public List<LayerMask> whatIsPlayer;

    public List<PlayerCharacter> charactersForPlayer;

    public UnityAction onPlayerSpawnFinished;

    public static PlayerCharacterSpawner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        charactersForPlayer = new List<PlayerCharacter>();
        for (int i = 0; i < selectedHeros.Count; i++)
        {
            GameObject hero = Instantiate(selectedHeros[i], new Vector2(0+i*4, 0), Quaternion.identity);
            hero.AddComponent(playerInputs[i].GetType());
            hero.layer = layermask_to_layer(whatIsPlayer[i]);
            hero.SetActive(true);
            charactersForPlayer.Add(hero.GetComponent<PlayerCharacter>());
        }


        for (int i = 0; i < charactersForPlayer.Count; i++)
        {
            for (int j = 0; j < charactersForPlayer.Count; j++)
            {
                if (i != j)
                {
                    charactersForPlayer[i].whatIsEnemy |= 1<<charactersForPlayer[j].gameObject.layer;
                    charactersForPlayer[i].whatIsGround |= 1 << charactersForPlayer[j].gameObject.layer;
                }
            }
                
        }
        
        onPlayerSpawnFinished?.Invoke();
        
    }
    
    public static int layermask_to_layer(LayerMask layerMask) {
        int layerNumber = 0;
        int layer = layerMask.value;
        while(layer > 0) {
            layer = layer >> 1;
            layerNumber++;
        }
        return layerNumber - 1;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
