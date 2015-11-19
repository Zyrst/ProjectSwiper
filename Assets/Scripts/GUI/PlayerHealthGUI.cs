using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class PlayerHealthGUI : MonoBehaviour {
    GameObject life;
    Vector2 _originalSize;
    
    // Use this for initialization
	void Start () {
       life =  GetComponentsInChildren<Image>().FirstOrDefault(x => x.name == "Life").gameObject;
       _originalSize = life.GetComponent<RectTransform>().sizeDelta;
    }
	
	// Update is called once per frame
	void Update () {
        float perc = References.Instance._currentPlayer._health / References.Instance._currentPlayer._maxHealth;
        //life.transform.localScale = new Vector3(perc, 1f, 1f);
        life.GetComponent<RectTransform>().sizeDelta = new Vector2(_originalSize.x * perc , _originalSize.y);
    }

}
