using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

[ExecuteInEditMode]
public class Healthbar : MonoBehaviour {

    public GameObject enemy;
    public Image _foreground;
    
    // Use this for initialization
	void Start () {
        if (_foreground == null)
            _foreground = GetComponentsInChildren<Image>().FirstOrDefault(x => x.name == "Foreground");
        Debug.Assert(_foreground != null, "Could not find reference to image");

        // Try to find enemy
        if (transform.parent != null)
            enemy = transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform);

        // TODO: Get enemy health and scale accordingly
    }
}
