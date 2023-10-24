using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SaveSystemTutorial
{
    public static class SaveSystem
    {
        public static void SaveByJson(string SaveFileName, object data)
        {
            var json = JsonUtility.ToJson(data);
            var path = Path.Combine(Application.persistentDataPath, SaveFileName);
            File.WriteAllText(path, json);
            Debug.Log("Save successful");
        }

        public static T LoadFromJson<T>(string SaveFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, SaveFileName);
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            Debug.Log("Load successful");
            return data;
        }

        public static void DeleteSaveFile(string SaveFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, SaveFileName);
            File.Delete(path);
            Debug.Log("Del successful");
        }
    }
}
