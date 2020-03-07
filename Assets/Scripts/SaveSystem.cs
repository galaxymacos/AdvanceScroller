using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveHeroSelectionData(string fightDataString)
    {
        Debug.Log(fightDataString);
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        formatter.Serialize(stream,fightDataString);
        stream.Close();
    }

    public static FightData LoadHeroSelectionData()
    {
        string path = Application.persistentDataPath + "/player.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            string fightDataInString = formatter.Deserialize(stream) as string;
            stream.Close();
            var fightData = JsonUtility.FromJson<FightData>(fightDataInString);
            return fightData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}