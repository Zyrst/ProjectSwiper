using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour {

    public List<string> _textList;

    int _page;

	// Use this for initialization
	void Start () {
        _page = 0;
        UpdateText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Exit()
    {
        Destroy(this.gameObject);
    }

    public void Next()
    {
        _page++;

        if (_page > _textList.Count)
        {
            _page = _textList.Count;
        }

        UpdateText();
    }

    public void Previous()
    {
        _page--;

        if (_page < 0)
        {
            _page = 0;
        }

        UpdateText();
    }

    public void UpdateText()
    {
        GetComponentInChildren<Text>().text = _textList[_page];
    }
}
