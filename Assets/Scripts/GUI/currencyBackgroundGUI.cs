using UnityEngine;
using System.Collections;

public class currencyBackgroundGUI : MonoBehaviour {

    RectTransform _rect;
    float _minWidth;
    float _height;
    public RectTransform _childGUIRect;

	void Start () {
        _childGUIRect = transform.GetChild(0).GetComponent<RectTransform>();
        _rect = GetComponent<RectTransform>();
        _minWidth = _rect.rect.width;
        _height = _rect.rect.height;
    }
	
	void Update () {
        Debug.Log(_childGUIRect.rect.width);
        _rect.sizeDelta = new Vector2(Mathf.Max(_minWidth, _childGUIRect.rect.width + 50), _height);
    }
}
