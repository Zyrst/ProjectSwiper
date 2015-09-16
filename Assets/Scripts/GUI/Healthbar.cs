using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class Healthbar : MonoBehaviour {

    public Enemy enemy;
    public Image _foreground;
    public Image _background;
    public Image _border;

    // Use this for initialization
	void Start () {
        //if (_foreground == null)
        //    _foreground = GetComponentsInChildren<Image>().FirstOrDefault(x => x.name == "Foreground");
        Debug.Assert(_foreground != null, "Could not find reference to foreground");
        Debug.Assert(_background != null, "Could not find reference to background");
        Debug.Assert(_border     != null, "Could not find reference to border");

        // Try to find enemy
        if (transform.parent != null)
            enemy = transform.parent.GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform);
        
        if (enemy != null)
            _foreground.transform.localScale = new Vector3(enemy._maxHealth / enemy._health, 1, 1);
    }
}
