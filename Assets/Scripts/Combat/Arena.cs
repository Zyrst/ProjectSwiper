using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Arena : MonoBehaviour {

    public Texture[] textures;
    public Renderer renderer;

    public void setTexture(int index_)
    {
        setTexture(textures[index_]);
    }

    public void setTexture(Texture tex_)
    {
        renderer.material.SetTexture(0, tex_);
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
