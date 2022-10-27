using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystemLoader
{
    public static void SaveData(CharachterProperties character)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Hopeful.sve";

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData saveData = new SaveData(character);

        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/Game.weeklyhow";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            return null;
        }
    }
}
