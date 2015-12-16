using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour {

    public Slider _musicSlider;
    public Slider _soundSlider;

	// Use this for initialization
	void Start () {
        ChangeMusicVolume(References.Instance._FMODMusicSlider);
        ChangeSoundVolume(References.Instance._FMODSoundSlider);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateVolumeFromMusicSlider()
    {
        ChangeMusicVolume(_musicSlider.value);
    }

    public void UpdateVolumeFromSoundSlider()
    {
        ChangeSoundVolume(_soundSlider.value);
    }

    public void ChangeMusicVolume(float value_)
    {
        _musicSlider.value = value_;
        References.Instance._FMODMusicSlider = value_;
        Sounds.Instance.UpdateVolume(Sounds.Instance.musicBus, value_);
    }

    public void ChangeSoundVolume(float value_)
    {
        _soundSlider.value = value_;
        References.Instance._FMODSoundSlider = value_;
        Sounds.Instance.UpdateVolume(Sounds.Instance.soundBus, value_);
    }

    public void ToggleMusicMute()
    {
        References.Instance._FMODMusicMute = !References.Instance._FMODMusicMute;
        Sounds.Instance.Mute(Sounds.Instance.musicBus, References.Instance._FMODMusicMute);

        Sounds.OneShot(Sounds.Instance.ui.buttonClick);
    }

    public void ToggleSoundMute()
    {
        References.Instance._FMODSoundMute = !References.Instance._FMODSoundMute;
        Sounds.Instance.Mute(Sounds.Instance.soundBus, References.Instance._FMODSoundMute);

        Sounds.OneShot(Sounds.Instance.ui.buttonClick);
    }
}
