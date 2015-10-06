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
                _instance = GameObject.Find("Sounds").GetComponent<Sounds>();
            }
            return _instance;
        }
    }

    public FMODAsset test;

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
