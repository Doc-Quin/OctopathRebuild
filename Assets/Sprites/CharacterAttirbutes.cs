using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SaveSystemTutorial;

namespace SaveSystemTutorial
{
    public class CharacterAttirbutes : MonoBehaviour
    {
        [System.Serializable] class Character
        {
            public string name;
            public string characterBasicProfession;
            public string characterAdvanceProfession;
            public int maxLife;
            public int freshLife;
            public int maxSP;
            public int freshSP;
            public int maxBP;
            public int freshBP;
            public int physicalAttack;
            public int physicalDefense;
            public int magicalAttack;
            public int magicalDefense;
            public int moveSpeed;
            public int avoid;
            public int critalHit;
            public int hit;
            public string status;
        }

        Character Running;
        //public Character running => Running;
        [System.Serializable] class SaveCharacter
        {
            public string name;
            public string characterBasicProfession;
            public string characterAdvanceProfession;
            public int maxLife;
            public int freshLife;
            public int maxSP;
            public int freshSP;
            public int maxBP;
            public int freshBP;
            public int physicalAttack;
            public int physicalDefense;
            public int magicalAttack;
            public int magicalDefense;
            public int moveSpeed;
            public int avoid;
            public int critalHit;
            public int hit;
            public string status;
        }

        const string CHARACTER_DATA_FILE_NAME = "CharacterData.cd";

        public void Save()
        {
            SaveByJson();
        }

        public void Load()
        {
            LoadFromJson();
        }

        void SaveByJson()
        {
            SaveSystem.SaveByJson(CHARACTER_DATA_FILE_NAME, SavingData());
        }

        SaveCharacter SavingData()
        {
            var saveCharacter = new SaveCharacter();

            saveCharacter.name = Running.name;
            saveCharacter.characterBasicProfession = Running.characterBasicProfession;
            saveCharacter.characterAdvanceProfession = Running.characterAdvanceProfession;
            saveCharacter.maxLife = Running.maxLife;
            saveCharacter.freshLife = Running.freshLife;
            saveCharacter.maxSP = Running.maxSP;
            saveCharacter.freshSP = Running.freshSP;
            saveCharacter.maxBP = Running.maxBP;
            saveCharacter.freshBP = Running.freshBP;
            saveCharacter.physicalAttack = Running.physicalAttack;
            saveCharacter.physicalDefense = Running.physicalDefense;
            saveCharacter.magicalAttack = Running.magicalAttack;
            saveCharacter.magicalDefense = Running.magicalDefense;
            saveCharacter.moveSpeed = Running.moveSpeed;
            saveCharacter.avoid = Running.avoid;
            saveCharacter.critalHit = Running.critalHit;
            saveCharacter.hit = Running.hit;
            saveCharacter.status = "Normal";
            return saveCharacter;
        }


        void LoadFromJson()
        {
            var saveCharacter = SaveSystem.LoadFromJson<SaveCharacter>(CHARACTER_DATA_FILE_NAME);

            LoadingData(saveCharacter);

        }

        void LoadingData(SaveCharacter saveCharacter)
        {
            Running.name = saveCharacter.name;
            Running.characterBasicProfession = saveCharacter.characterBasicProfession;
            Running.characterAdvanceProfession = saveCharacter.characterAdvanceProfession;
            Running.maxLife = saveCharacter.maxLife;
            Running.freshLife = saveCharacter.freshLife;
            Running.maxSP = saveCharacter.maxSP;
            Running.freshSP = saveCharacter.freshSP;
            Running.maxBP = saveCharacter.maxBP;
            Running.freshBP = saveCharacter.freshBP;
            Running.physicalAttack = saveCharacter.physicalAttack;
            Running.physicalDefense = saveCharacter.physicalDefense;
            Running.magicalAttack = saveCharacter.magicalAttack;
            Running.magicalDefense = saveCharacter.magicalDefense;
            Running.moveSpeed = saveCharacter.moveSpeed;
            Running.avoid = saveCharacter.avoid;
            Running.critalHit = saveCharacter.critalHit;
            Running.hit = saveCharacter.hit;
            Running.status = "Normal";
        }

        [UnityEditor.MenuItem("Developer/Delete Player Data Save File")]
        public static void DeleteSaveFile()
        {
            SaveSystem.DeleteSaveFile(CHARACTER_DATA_FILE_NAME);
        }
    }
}
