using UnityEngine;
using System.Collections;

public class MouseSwipe : MonoBehaviour {

    public LineRenderer _lineRender;
    [HideInInspector]
    public int _count = 2;
    [HideInInspector]
    private Vector3[] vertecies = null;

	// Use this for initialization
	void Start () {
        _lineRender = GetComponent<LineRenderer>();
        transform.rotation = Camera.main.transform.rotation;

        vertecies = new Vector3[_count];
        _lineRender.SetVertexCount(_count);
        _lineRender.SetWidth(0.5f, 0.01f);
	}
	
	// Update is called once per frame
	void Update () {
        vertecies[0] = MouseController.Instance.worldPosition;
        _lineRender.SetPosition(0, vertecies[0]);

        for (int i = _count-1; i > 0; i--)
        {   
            vertecies[i] = vertecies[i-1];
            _lineRender.SetPosition(i, vertecies[i]);
        }

	}
}
