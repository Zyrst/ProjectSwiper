using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Arena : MonoBehaviour {

    public Texture[] textures;
    public Renderer renderer;
    public int _textureIndex;

    /// <summary>
    /// updates the "_textureIndex" variable
    /// </summary>
    public void setTexture(int index_)
    {
        setTexture(textures[index_]);
        _textureIndex = index_;
    }

    /// <summary>
    /// does not update the "_textureIndex" variable
    /// </summary>
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
