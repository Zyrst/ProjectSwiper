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
    };

    public Abilities abilities;
    public Combat combat;
    public UI ui;


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
