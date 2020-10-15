using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SaveSystem 
{
    public static void SavePlayer(PlayerController player) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedata.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player, LobbyController.currentSceneIndex, DeathController.health);
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log(data.level);
        Debug.Log(data.hearts);
        Debug.Log(data.position);
        Debug.Log("Game has been saved...");
    }
    
    public static PlayerData LoadPlayer() 
    {
        string path = Application.persistentDataPath + "/savedata.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            Debug.Log("Loading existing game...");
            Debug.Log(data.level);
            Debug.Log(data.hearts);
            return data;
         }
        else 
        {
            Debug.LogError("Save file not found in " + path);
            Debug.Log("Loading new game...");
            SceneManager.LoadScene(1);
            return null;
        }
    }
}
