using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveManager {

    [System.Serializable]
    public class GameInfo
    {
        //Put things in here later
        //TODO  Add things in save manager
        public int _level;
        public float _damage;
        public float _maxHealth;
    }

    public static GameInfo _info = new GameInfo();
    public static void Save()
    {
        _info._level = Game.Instance._level;
        Debug.Log(_info._level);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.dfq");
        bf.Serialize(file, _info);
        file.Close();
        Debug.Log(Application.persistentDataPath);
    }

    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/savedGame.dfq"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.dfq", FileMode.Open);
            _info = (GameInfo)bf.Deserialize(file);
            file.Close();
            Debug.Log(_info._level);
        }
    }
    
}
