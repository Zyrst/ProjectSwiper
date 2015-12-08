using UnityEngine;
using System.Collections;
using System.Linq;

public class CurrencyObject : MonoBehaviour {
    public float _lifeTime = 5f;
    public int _value = 1;
    public bool _collect = false;
    public Vector3 _target;
    public float _speed = 1000000f;

    [HideInInspector]
    public float _timer = 0f;

	// Use this for initialization
	void Start () {
        GameObject go = GameObject.Find("CurrencyBackground");
        Vector3 targ = go.transform.position;
        //targ -= new Vector3((go.GetComponent<RectTransform>().rect.width / 2), 0 , 0);
      //  targ += new Vector3(80, 0, 0);
        _target = Camera.main.ScreenToWorldPoint(targ);
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;   //Increase time
        if (_timer >= _lifeTime && !_collect)
        {
            Collect();
        }
        else if(!_collect)
        {
            if (MouseController.Instance.buttonDown)
            {
                if (MouseCuboid.hit)
                {
                    //if hit and the transform equals this transform, collect
                    Collider tempCol = MouseCuboid.colliders.FirstOrDefault(x => x.gameObject.tag == "Currency");
                    if (tempCol != null)
                    {
                        if(tempCol.transform == transform)
                            Collect();
                    }
                }
            }   
        }
        if(_collect)
        {
            //Make it fly to the target on the GUI
            Vector3 calc = ((_target - transform.position) *_speed) * Time.deltaTime;
            transform.position += calc;
            this.transform.Rotate(Random.Range(1, 9), Random.Range(1, 9), Random.Range(1, 9)); // Remove this for no rotation when moving towards position

            if(Vector3.Distance(_target, transform.position) <= 3f)
            {
                // kollar ifall man har mindre guld än kostnaden för upgrades innan
                bool preUnderCost = false;
                if (Game.Instance._gameCurrency < UpgradePlayer._cost)
                    preUnderCost = true;

                Sounds.OneShot(Sounds.Instance.ui.currencyCollect);
                Game.Instance._gameCurrency += _value;

                // spelar ljud ifall man har mer än kostnaden för upgrade efter
                if (preUnderCost && Game.Instance._gameCurrency >= UpgradePlayer._cost)
                    Sounds.OneShot(Sounds.Instance.ui.upgradeAvailable);

               // Debug.Log("Currency " + Game.Instance._gameCurrency);
                GameObject.Destroy(gameObject);
            }
        }
	}

    public void Collect()
    {
        //Setup so it can fly easily to the target
        //Remove all forces and no gravity and turn off collider
        Rigidbody body = GetComponent<Rigidbody>();
        body.useGravity = false;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        _collect = true;
    }


    public static void Spawn(Vector3 force_, Vector3 pos_)
    {
        GameObject go = GameObject.Instantiate(References.Instance._gameCurrency);

        pos_ += new Vector3(0f, 1f, 0f);
        go.transform.position = pos_;
        go.GetComponent<Rigidbody>().AddForce(force_);
        // HACK: Suck ₫ for a ₫ 
    }
}
