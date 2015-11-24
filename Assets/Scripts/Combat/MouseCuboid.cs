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


            midPoint.transform.rotation = transform.rotation;

            Vector3 dir = transform.position - lastPoint;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            Vector3 scale = Vector3.one;
            scale.z = 20;
            float distance = Vector3.Distance(lastPoint, transform.position);
            scale.x *= distance * 2 > scale.x ? distance * 2 : scale.x;

            if (scale.x <= 0.5f)    scale.x = 0.5f;

            midPoint.transform.localScale = scale;

            midPoint.transform.Rotate(new Vector3(0, 0, 1), angle, Space.Self);

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
    // lägger in collidern om den inte redan finns i listan
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
        // clearar alla, men det är lugnt, alla gamla kommer in nästa frame igen
        colliders.Clear();
    }
}
