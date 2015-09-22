using UnityEngine;
using System.Collections;

public class CurrencyObject : MonoBehaviour {

    public float _lifeTime = 5f;
    public int _value = 1;

    [HideInInspector]
    public float _timer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if (_timer >= _lifeTime)
        {
            Collect();
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(MouseController.Instance.position);
            RaycastHit hit = new RaycastHit();
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.transform == transform)
                {
                    Collect();
                }
            }
        }
	}

    public void Collect()
    {
        Game.Instance._gameCurrency += _value;
        Debug.Log("Currency " + Game.Instance._gameCurrency);
        GameObject.Destroy(gameObject);
    }


    public static void Spawn(Vector3 force_, Vector3 pos_)
    {
        GameObject _cur = GameObject.Instantiate(Resources.Instance._gameCurrency);

        pos_ += new Vector3(0f, 1f, 0f);
        _cur.transform.position = pos_;


        _cur.GetComponent<Rigidbody>().AddForce(force_);
        // HACK: Suck ₫ for a ₫ 
    }
}
