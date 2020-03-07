using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacterSpawner : MonoBehaviour
{
    
    [Tooltip("Spawn heroes manually by assigning it in the inspector")]
    public List<GameObject> selectedHeros;
    
    // Spawn heros from save file
    private List<GameObject> herosFromSavedFile;

    [SerializeField] private GameObject batHeroPrefab;
    [SerializeField] private GameObject SwordPrincessPrefab;
    [SerializeField] private GameObject AxeHeroPrefab;
    [SerializeField] private GameObject PsychicHeroPrefab;

    private List<GameObject> heroDatas;

    public List<LayerMask> whatIsPlayer;

    public List<PlayerCharacter> charactersForPlayer;

    public static Action onPlayerSpawnFinished;

    public static PlayerCharacterSpawner instance;

    private MapPlayerSpawnData mapPlayerSpawnData;

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

        mapPlayerSpawnData = FindObjectOfType<MapPlayerSpawnData>();
        if (mapPlayerSpawnData == null)
        {
            Debug.LogError("MapPlayerSpawnData not found");
            Debug.LogError(
                "You need to tell the player this class where to generate the players in the map by create a MapPlayerSpawnData class under your map");
        }

        FightData data = SaveSystem.LoadHeroSelectionData();
        heroDatas = new List<GameObject>();
        heroDatas.Add(batHeroPrefab);
        heroDatas.Add(SwordPrincessPrefab);
        heroDatas.Add(AxeHeroPrefab);
        heroDatas.Add(PsychicHeroPrefab);
        if (data != null)
        {
            herosFromSavedFile = new List<GameObject>();
            foreach (var champion in data.champions)
            {
                
                herosFromSavedFile.Add(champion);
            }
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        charactersForPlayer = new List<PlayerCharacter>();
        if (herosFromSavedFile != null)
        {
            for (int i = 0; i < herosFromSavedFile.Count; i++)
            {
                AddPlayer(herosFromSavedFile[i]);
            }
            
            print("Loaded champion data from save file");
        }
        else
        {
            for (int i = 0; i < selectedHeros.Count; i++)
            {
                // GameObject hero = Instantiate(selectedHeros[i]);
                // hero.transform.position = mapPlayerSpawnData.PlayerSpawnPositions[i].position;
                // hero.layer = layermask_to_layer(whatIsPlayer[i]);
                // charactersForPlayer.Add(hero.GetComponent<PlayerCharacter>());
            
                AddPlayer(selectedHeros[i]);
            }
            
            print("Loaded champion data from inspector");
        }


        // for (int i = 0; i < charactersForPlayer.Count; i++)
        // {
        //     for (int j = 0; j < charactersForPlayer.Count; j++)
        //     {
        //         if (i != j)
        //         {
        //             charactersForPlayer[i].whatIsEnemy |= 1 << charactersForPlayer[j].gameObject.layer;
        //             // charactersForPlayer[i].whatIsEnemy &= ~(1 << charactersForPlayer[j].gameObject.layer);
        //
        //             charactersForPlayer[i].whatIsGround |= 1 << charactersForPlayer[j].gameObject.layer;
        //             // charactersForPlayer[i].whatIsGround &= ~(1 << charactersForPlayer[j].gameObject.layer);
        //         }
        //     }
        // }

        if (PlayerInputStorage.instance != null)
        {
            for (int i = 0; i < charactersForPlayer.Count; i++)
            {
                charactersForPlayer[i].playerInput = PlayerInputStorage.instance.playerInputs[i];
            }
        }
        
        
        onPlayerSpawnFinished?.Invoke();
    }

    public void AddPlayer(GameObject heroToSpawn)
    {
        GameObject hero = Instantiate(heroToSpawn);

        hero.transform.position = mapPlayerSpawnData.PlayerSpawnPositions[charactersForPlayer.Count].position;
        hero.layer = layermask_to_layer(whatIsPlayer[charactersForPlayer.Count]);
        charactersForPlayer.Add(hero.GetComponent<PlayerCharacter>());

        for (int i = 0; i < charactersForPlayer.Count; i++)
        {
            for (int j = 0; j < charactersForPlayer.Count; j++)
            {
                if (i != j)
                {
                    charactersForPlayer[i].whatIsEnemy |= 1 << charactersForPlayer[j].gameObject.layer;

                    charactersForPlayer[i].whatIsGround |= 1 << charactersForPlayer[j].gameObject.layer;
                }
            }
        }

    }


    public static int layermask_to_layer(LayerMask layerMask)
    {
        int layerNumber = 0;
        int layer = layerMask.value;
        while (layer > 0)
        {
            layer = layer >> 1;
            layerNumber++;
        }

        return layerNumber - 1;
    }
}