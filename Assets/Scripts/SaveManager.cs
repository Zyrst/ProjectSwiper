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
        public int _level;
        public int _gameCurrency;
        public float _damage;
        public float _maxHealth;
    }

    public static GameInfo _info = new GameInfo();
    public static void Save()
    {
        //Add information to GameInfo before save
        _info._level = Game.Instance._level;
        _info._gameCurrency = Game.Instance._gameCurrency;
        Player player = Resources.Instance._player.GetComponent<Player>();
        _info._damage = player._damage;
        _info._maxHealth = player._maxHealth;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.dfq");
        bf.Serialize(file, _info);
        file.Close();

        Debug.Log("Save damage: " + _info._damage);
    }

    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/savedGame.dfq"))
        {
            //Load information from file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.dfq", FileMode.Open);
            _info = (GameInfo)bf.Deserialize(file);
            file.Close();

            //apply everything
            Game.Instance._level = _info._level;
            Game.Instance._gameCurrency  = _info._gameCurrency;
            Player player = Resources.Instance._player.GetComponent<Player>();
            player._damage = _info._damage;
            player._maxHealth = _info._maxHealth;

            Debug.Log("Load damage: " + _info._damage);
        }

    }
    
}
