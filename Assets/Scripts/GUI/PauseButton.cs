using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {

    public Sprite[] _sprites;
    private bool _paused = false;
    Button _button;
    Image _image;

	// Use this for initialization
	void Start () {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _image.sprite = _sprites[0];
        _button.targetGraphic = _image;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TogglePause()
    {
        if(!_paused)
        {
            Time.timeScale = 0;
            _paused = true;
            _image.sprite = _sprites[1];
        }
        else if (_paused)
        {
            Time.timeScale = 1;
            _paused = false;
            _image.sprite = _sprites[0];
        }
    }
}
