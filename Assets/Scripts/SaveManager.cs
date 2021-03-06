﻿using UnityEngine;
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
        public int _arenaLevel;
        public int _maxArenaLevel;
        public long _gameCurrency;
        public int _healthLevel;
        public int _damageLevel;
        public int _critLevel;
        public float _damage;
        public int _critDenominator;
        public float _maxHealth;

        public float _musicVolume;
        public bool _musicMute;
        public float _soundVolume;
        public bool _soundMute;

        public References.Stats _stats;
    }

    public static GameInfo _info = new GameInfo();
    public static void Save()
    {
        //Add information to GameInfo before save
        _info._level = Game.Instance._level;
        _info._gameCurrency = Game.Instance._gameCurrency;
        _info._arenaLevel = Game.Instance._arenaLevel;
        _info._maxArenaLevel = Game.Instance._maxArenaLevel;
        

        Player player = References.Instance._currentPlayer;
        _info._damage = player._damage;
        _info._maxHealth = player._maxHealth;
        _info._healthLevel = player._healthLevel;
        _info._damageLevel = player._damageLevel;
        _info._critLevel = player._critLevel;
        _info._critDenominator = player._critDenominator;

        _info._musicVolume = References.Instance._FMODMusicSlider;
        _info._musicMute = References.Instance._FMODMusicMute;
        _info._soundVolume = References.Instance._FMODSoundSlider;
        _info._soundMute = References.Instance._FMODSoundMute;

        _info._stats = References.Instance._stats;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.dfq");
        bf.Serialize(file, _info);
        file.Close();
        GameObject.Instantiate(UnityEngine.Resources.Load("Prefabs/Combat/Saved Popup"));
       // Debug.Log("Save damage: " + _info._damage + "Level " + _info._level);
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
            Game.Instance._arenaLevel = _info._arenaLevel;
            Game.Instance._maxArenaLevel = _info._maxArenaLevel;
            if (References.Instance._currentPlayer != null)
            {
                Player player = References.Instance._currentPlayer;
                player._damage = _info._damage;
                player._maxHealth = _info._maxHealth;
                player._healthLevel = _info._healthLevel;
                player._damageLevel = _info._damageLevel;
                player._critLevel = _info._critLevel;
                player._critDenominator = _info._critDenominator;
            }
            else
            {
                Debug.LogError("No current player");
            }

            References.Instance._FMODMusicSlider = _info._musicVolume;
            References.Instance._FMODMusicMute = _info._musicMute;

            References.Instance._FMODSoundSlider = _info._soundVolume;
            References.Instance._FMODSoundMute = _info._soundMute;

            References.Instance._stats = _info._stats;

        }
        else
        {
            References.Instance._currentPlayer.GetComponent<Player>().ResetStats();
        }

        Sounds.Instance.UpdateVolume(Sounds.Instance.musicBus, References.Instance._FMODMusicSlider);
        Sounds.Instance.Mute(Sounds.Instance.musicBus, References.Instance._FMODMusicMute);
        Sounds.Instance.UpdateVolume(Sounds.Instance.soundBus, References.Instance._FMODSoundSlider);
        Sounds.Instance.Mute(Sounds.Instance.soundBus, References.Instance._FMODSoundMute);
    }
}
