using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ControlSetting : MonoBehaviour
{
    private Dictionary<KeyCode, int> keyCodeMapping;
    private string filePath;
    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/myData.txt";
        keyCodeMapping = new Dictionary<KeyCode, int>();
        LoadDataFromFile();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(GetKeyCodeForValue(5)))
        {
            SaveDataToFile();
        }*/
    }

    void SaveDataToFile()
    {
        // 将字典数据转换为字符串
        string dataString = DictionaryToString(keyCodeMapping);

        // 将数据写入文本文件
        File.WriteAllText(filePath, dataString);

        Debug.Log("Data saved to: " + filePath);
    }

    void LoadDataFromFile()
    {
        // 检查文件是否存在
        if (File.Exists(filePath))
        {
            // 从文件读取数据
            string dataString = File.ReadAllText(filePath);

            // 将字符串转换为字典数据
            keyCodeMapping = StringToDictionary(dataString);

            // 输出加载的字典数据
            foreach (var pair in keyCodeMapping)
            {
                Debug.Log(pair.Key + ": " + pair.Value);
            }
        }
        else
        {
            Debug.LogWarning("Data file not found: " + filePath);
        }
    }

    string DictionaryToString(Dictionary<KeyCode, int> dict)
    {
        // 将字典数据转换为字符串
        List<string> keyValuePairs = new List<string>();
        foreach (var pair in dict)
        {
            // 使用 pair.Key.ToString() 将 KeyCode 转换为字符串
            keyValuePairs.Add(pair.Key.ToString() + ":" + pair.Value);
        }
        return string.Join(",", keyValuePairs.ToArray());
    }

    Dictionary<KeyCode, int> StringToDictionary(string dataString)
    {
        // 将字符串转换为字典数据
        Dictionary<KeyCode, int> dict = new Dictionary<KeyCode, int>();
        string[] keyValuePairs = dataString.Split(',');
        foreach (var pair in keyValuePairs)
        {
            string[] parts = pair.Split(':');
            if (parts.Length == 2)
            {
                string keyString = parts[0];
                int value = int.Parse(parts[1]);

                // 使用 Enum.Parse 将字符串还原为 KeyCode
                KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyString);

                dict.Add(key, value);
            }
        }
        return dict;
    }

    public int GetMappedValue(KeyCode key)
    {
        // 检查字典中是否包含键
        if (keyCodeMapping.ContainsKey(key))
        {
            // 返回映射的值
            return keyCodeMapping[key];
        }
        else
        {
            // 如果字典中不包含键，返回一个默认值或者处理缺失情况
            Debug.LogWarning("KeyCode mapping not found for key: " + key);
            return -1; // 例如，返回-1表示没有映射
        }
    }

    public KeyCode GetKeyCodeForValue(int value)
    {
        foreach (var pair in keyCodeMapping)
        {
            if (pair.Value == value)
            {
                return pair.Key;
            }
        }

        //Debug.LogWarning("KeyCode not found for value: " + value);
        return KeyCode.None; // 例如，返回KeyCode.None表示没有找到对应的KeyCode
    }

}
