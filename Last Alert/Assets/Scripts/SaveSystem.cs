using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//static class to controll saving player state
public static class SaveSystem
{
    /*
        To save the players state:
         1. First get reference to the players transform.
         2. call SaveSystem.save(transform);
    */
    public static void save(Transform player)
    {
        string path = Application.persistentDataPath + "/data.abc";
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    /*
        To load the players state:
        1. retrieve the data:
            PlayerData data = SaveSystem.load();

            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];

        2. get reference to the players transform
        3. set the transforms position to position:
            transform.position = position;
    */
    public static PlayerData load()
    {
        string path = Application.persistentDataPath + "/data.abc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("save file does not exist! : " + path);
            return null;
        }
    }

}
