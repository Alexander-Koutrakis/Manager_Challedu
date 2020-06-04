using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem 
{
  public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameData.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(GameMaster.gameMaster,Player_Controller.player_Controller);
        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData LoadGame() {
        string path = Application.persistentDataPath + "/gameData.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData gameData = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return gameData;
        }
        else {
            Debug.Log("No save found!!!");
            return null;
        }
       
    }

    public static void DeleteSave() {
        string path = Application.persistentDataPath + "/gameData.save";
        File.Delete(path);
    }
}
