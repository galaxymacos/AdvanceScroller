using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacterSpawner : MonoBehaviour
{
    // public List<PlayerInput> playerInputs;
    public List<GameObject> selectedHeros;

    [SerializeField] private GameObject batHeroPrefab;
    [SerializeField] private GameObject SwordPrincessPrefab;
    [SerializeField] private GameObject AxeHeroPrefab;
    [SerializeField] private GameObject PsychicHeroPrefab;


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
    }


    // Start is called before the first frame update
    void Start()
    {
        charactersForPlayer = new List<PlayerCharacter>();
        for (int i = 0; i < selectedHeros.Count; i++)
        {
            // GameObject hero = Instantiate(selectedHeros[i]);
            // hero.transform.position = mapPlayerSpawnData.PlayerSpawnPositions[i].position;
            // hero.layer = layermask_to_layer(whatIsPlayer[i]);
            // charactersForPlayer.Add(hero.GetComponent<PlayerCharacter>());
            
            AddPlayer(selectedHeros[i]);
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

public class ChampionSelectionData
{
    public List<GameObject> champions;
    public int fightSceneIndex;

    public ChampionSelectionData(List<GameObject> champions)
    {
        this.champions = champions;
    }
}

public static class SaveSystem
{
    public static void SaveHeroSelectionData(ChampionSelectionData championSelectionData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        formatter.Serialize(stream,championSelectionData);
        stream.Close();
    }

    public static ChampionSelectionData LoadHeroSelectionData()
    {
        string path = Application.persistentDataPath + "/player.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ChampionSelectionData championSelectionData = formatter.Deserialize(stream) as ChampionSelectionData;
            stream.Close();
            
            return championSelectionData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}