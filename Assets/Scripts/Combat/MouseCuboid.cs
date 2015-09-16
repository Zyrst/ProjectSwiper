using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseCuboid : MonoBehaviour
{
    public static List<Collider> colliders = new List<Collider>();

    public static bool hit
    {
        get
        {
            return colliders.Count != 0;
        }
    }

    private static MouseCuboid midPoint = null;
    public Vector3 lastPoint;
    private bool mayUpdate = true;

    public MouseCuboid()
    {
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    void Update()
    {
        if (mayUpdate)
        {
            transform.forward = Camera.main.transform.forward;
            transform.position = MouseController.Instance.worldPosition;

            if (midPoint == null)
            {
                midPoint = GameObject.Instantiate(this as MouseCuboid);
                midPoint.transform.parent = transform;
                midPoint.mayUpdate = false;
            }

            midPoint.transform.forward = transform.forward;
            Vector3 pos = midPoint.transform.position;
            pos = (transform.position + lastPoint) / 2f;
            midPoint.transform.position = pos;
            midPoint.transform.localScale = transform.localScale;

            Vector3 scale = midPoint.transform.localScale;
            scale.x *= Vector3.Distance(lastPoint, transform.position) > scale.x ? Vector3.Distance(lastPoint, transform.position) : scale.x;

            if (scale.x <= 0.5f)    scale.x = 0.5f;
            
            midPoint.transform.localScale = scale;

            midPoint.GetComponent<Collider>().enabled = false;
            midPoint.GetComponent<Collider>().enabled = true;

            lastPoint = transform.position;
        }
	}

    void LateUpdate()
    {
        if (mayUpdate)
            colliders.Clear();
    }


    void OnTriggerEnter(Collider col_)
    {
        bool foundit = false;
        foreach (var item in colliders)
        {
            if (item == col_)
            {
                foundit = true;
                break;
            }
        }
        if (!foundit)
            colliders.Add(col_);
    }

    void OnTriggerStay(Collider col_)
    {
        bool foundit = false;
        foreach (var item in colliders)
        {
            if (item == col_)
            {
                foundit = true;
                break;
            }
        }
        if (!foundit)
            colliders.Add(col_);
    }

    void OnTriggerExit(Collider col_)
    {
        colliders.Clear();
    }
}
