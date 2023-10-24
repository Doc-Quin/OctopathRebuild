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
        // ���ֵ�����ת��Ϊ�ַ���
        string dataString = DictionaryToString(keyCodeMapping);

        // ������д���ı��ļ�
        File.WriteAllText(filePath, dataString);

        Debug.Log("Data saved to: " + filePath);
    }

    void LoadDataFromFile()
    {
        // ����ļ��Ƿ����
        if (File.Exists(filePath))
        {
            // ���ļ���ȡ����
            string dataString = File.ReadAllText(filePath);

            // ���ַ���ת��Ϊ�ֵ�����
            keyCodeMapping = StringToDictionary(dataString);

            // ������ص��ֵ�����
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
        // ���ֵ�����ת��Ϊ�ַ���
        List<string> keyValuePairs = new List<string>();
        foreach (var pair in dict)
        {
            // ʹ�� pair.Key.ToString() �� KeyCode ת��Ϊ�ַ���
            keyValuePairs.Add(pair.Key.ToString() + ":" + pair.Value);
        }
        return string.Join(",", keyValuePairs.ToArray());
    }

    Dictionary<KeyCode, int> StringToDictionary(string dataString)
    {
        // ���ַ���ת��Ϊ�ֵ�����
        Dictionary<KeyCode, int> dict = new Dictionary<KeyCode, int>();
        string[] keyValuePairs = dataString.Split(',');
        foreach (var pair in keyValuePairs)
        {
            string[] parts = pair.Split(':');
            if (parts.Length == 2)
            {
                string keyString = parts[0];
                int value = int.Parse(parts[1]);

                // ʹ�� Enum.Parse ���ַ�����ԭΪ KeyCode
                KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyString);

                dict.Add(key, value);
            }
        }
        return dict;
    }

    public int GetMappedValue(KeyCode key)
    {
        // ����ֵ����Ƿ������
        if (keyCodeMapping.ContainsKey(key))
        {
            // ����ӳ���ֵ
            return keyCodeMapping[key];
        }
        else
        {
            // ����ֵ��в�������������һ��Ĭ��ֵ���ߴ���ȱʧ���
            Debug.LogWarning("KeyCode mapping not found for key: " + key);
            return -1; // ���磬����-1��ʾû��ӳ��
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
        return KeyCode.None; // ���磬����KeyCode.None��ʾû���ҵ���Ӧ��KeyCode
    }

}
