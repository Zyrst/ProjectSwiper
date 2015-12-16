using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    private static Sounds _instance = null;
    public static Sounds Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("SOUNDS").GetComponent<Sounds>();
            }
            return _instance;
        }
    }

    [System.Serializable]
    public struct Abilities
    {
        public FMODAsset Damage;
        public FMODAsset Heal;
        public FMODAsset Stun;
    }

    [System.Serializable]
    public struct Combat
    {
        [System.Serializable]
        public struct Enemies
        {
            [System.Serializable]
            public struct Damage
            {
                public FMODAsset Heavy;
                public FMODAsset Medium;
                public FMODAsset Small;
            };

            public Damage robotDamage;
        };
        [System.Serializable]
        public struct Player
        {
            [System.Serializable]
            public struct Attack
            {
                public FMODAsset swipe;
            };

            public Attack attack;
            public FMODAsset damage;
            public FMODAsset dies;
        };

        public Enemies enemies;
        public Player player;
    };

    [System.Serializable]
    public struct UI
    {
        public FMODAsset abilityReady;
        public FMODAsset currencyCollect;
        public FMODAsset newWave;
        public FMODAsset planetAvailable;
        public FMODAsset PlanetTravel;
        public FMODAsset upgradeAvailable;
        public FMODAsset upgradeBuy;
        public FMODAsset clickFight;
        public FMODAsset buttonClick;
    };

    [System.Serializable]
    public struct Music
    {
        [System.Serializable]
        public struct Background
        {
            public FMODAsset song; 
            [HideInInspector]
            public FMOD.Studio.EventInstance instance;
            [HideInInspector]
            public FMOD.Studio.ParameterInstance param;

            public void ChangeDeath()
            {
                param.setValue(1);
            }
            public void Reset()
            {
                param.setValue(0);
            }
        }
        public Background background;
    };

    public Abilities abilities;
    public Combat combat;
    public UI ui;
    public Music music;

    public FMOD.Studio.Bus musicBus;
    public FMOD.Studio.Bus soundBus;

    void Start()
    {
        FMOD.Studio.System system = FMOD_StudioSystem.instance.System;

        FMOD.RESULT result = system.getBus("bus:/Music", out musicBus);
        Debug.Log("FMOD music bus: " + result);

        result = system.getBus("bus:/Game", out soundBus);
        Debug.Log("FMOD sound bus: " + result);


        music.background.instance = FMOD_StudioSystem.instance.GetEvent(music.background.song);
        music.background.instance.getParameter("Death", out  music.background.param);

        StartMusic(Songs.BackgroundSong);
    }

    public enum Songs { BackgroundSong };
    public void StartMusic(Songs song_)
    {
        switch (song_)
        {
            case Songs.BackgroundSong:
                music.background.instance.start();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// updates volume of master bus
    /// </summary>
    /// <param name="volume_">0 - 1</param>
    public void UpdateVolume(FMOD.Studio.Bus bus_, float volume_)
    {
        float vol = volume_ > 1f ? 1f : volume_;
        bus_.setFaderLevel(vol);
    }

    /// <summary>
    /// sets if master bus is mute
    /// </summary>
    public void Mute(FMOD.Studio.Bus bus_, bool mute_)
    {
        bus_.setMute(mute_);
    }

    /// <summary>
    /// plays the asset once
    /// </summary>
    /// <param name="asset_">asset to play</param>
    public static void OneShot(FMODAsset asset_)
    {
        OneShot(asset_, new Vector3(0, 0, 0));
    }

    /// <summary>
    /// plays the asset once
    /// </summary>
    /// <param name="asset_">asset to play</param>
    /// <param name="pos_">sound source position</param>
    public static void OneShot(FMODAsset asset_, Vector3 pos_)
    {
        FMOD_StudioSystem.instance.PlayOneShot(asset_.path, pos_);
    }

    /// <summary>
    /// returns lenght of sound in milliseconds
    /// </summary>
    public static int GetLength(FMODAsset asset_)
    {
        FMOD.Studio.EventInstance ev = FMOD_StudioSystem.instance.GetEvent(asset_);
        return GetLength(ev);
    }

    /// <summary>
    /// returns lenght of sound in milliseconds
    /// </summary>
    public static int GetLength(FMOD.Studio.EventInstance event_)
    {
        int lengthms = 0;

        FMOD.Studio.EventDescription ed = null;
        event_.getDescription(out ed);

        ed.getLength(out lengthms);

        return lengthms;
    }
}
