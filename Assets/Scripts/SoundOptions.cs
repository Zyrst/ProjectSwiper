using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour {

    public Button _muteButton;
    public Slider _slider;

	// Use this for initialization
	void Start () {
        ChangeVolume(References.Instance._FMODMasterSlider);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateVolumeFromSlider()
    {
        ChangeVolume(_slider.value);
    }

    public void ChangeVolume(float value_)
    {
        _slider.value = value_;
        References.Instance._FMODMasterSlider = value_;
        Sounds.Instance.UpdateVolume(value_);
    }

    public void ToggleMute()
    {
        References.Instance._FMODMasterMute = !References.Instance._FMODMasterMute;
        Sounds.Instance.Mute(References.Instance._FMODMasterMute);
    }
}
