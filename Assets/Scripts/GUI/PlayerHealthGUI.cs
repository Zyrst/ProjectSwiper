using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class PlayerHealthGUI : MonoBehaviour {
    GameObject life;
	// Use this for initialization
	void Start () {
       life =  GetComponentsInChildren<Image>().FirstOrDefault(x => x.name == "Life").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        float perc = References.Instance._currentPlayer._health / References.Instance._currentPlayer._maxHealth;
        life.transform.localScale = new Vector3(perc, 1f, 1f);
	}

}
