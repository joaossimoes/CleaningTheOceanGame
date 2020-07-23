using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame(ProgressionManager progressionManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.sto";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(progressionManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/player.sto";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();

            Debug.Log(data);
            return  data;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }
}
