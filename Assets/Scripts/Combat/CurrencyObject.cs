﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class CurrencyObject : MonoBehaviour {

    public float _lifeTime = 5f;
    public int _value = 1;
    public bool _collect = false;
    public Vector3 _target;
    public float _speed = 1f;

    [HideInInspector]
    public float _timer = 0f;

	// Use this for initialization
	void Start () {
        GameObject go = GameObject.Find("CurrencyComponent");
        Vector3 targ = go.transform.position;
        targ -= new Vector3((go.GetComponent<RectTransform>().rect.width / 2), 0 , 0);
        _target = Camera.main.ScreenToWorldPoint(targ);
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if (_timer >= _lifeTime && !_collect)
        {
            Collect();
        }
        else if(!_collect)
        {
           // Ray ray = Camera.main.ScreenPointToRay(MouseController.Instance.position);
            //RaycastHit hit = new RaycastHit();
            //if(Physics.Raycast(ray, out hit))
            //{
            //    if(hit.collider.transform == transform)
            //    {
            //        Collect();
            //    }
            //}
            if (MouseController.Instance.buttonDown)
            {
                if (MouseCuboid.hit)
                {
                    Collider tempCol = MouseCuboid.colliders.FirstOrDefault(x => x.gameObject.tag == "Currency");
                    if (tempCol != null)
                    {
                        Debug.Log(tempCol.transform);
                        if(tempCol.transform == transform)
                            Collect();
                    }
                }
            }   
        }
        if(_collect)
        {
            Vector3 calc = (_target - transform.position) * (_speed * Time.deltaTime);
            transform.position += calc;

            if(Vector3.Distance(_target, transform.position) <= 3f)
            {
                Game.Instance._gameCurrency += _value;
                Debug.Log("Currency " + Game.Instance._gameCurrency);
                GameObject.Destroy(gameObject);
            }
        }
	}

    public void Collect()
    {
        
        Rigidbody body = GetComponent<Rigidbody>();
        body.useGravity = false;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        GetComponent<SphereCollider>().enabled = false;
        _collect = true;
    }


    public static void Spawn(Vector3 force_, Vector3 pos_)
    {
        GameObject go = GameObject.Instantiate(Resources.Instance._gameCurrency);

        pos_ += new Vector3(0f, 1f, 0f);
        go.transform.position = pos_;
        go.GetComponent<Rigidbody>().AddForce(force_);
        // HACK: Suck ₫ for a ₫ 
    }
}