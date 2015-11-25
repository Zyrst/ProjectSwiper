using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Arena : MonoBehaviour {

    public Texture[] textures;
    public Renderer _renderer{
        get {
            return GetComponentsInChildren<Transform>().FirstOrDefault(x => x.name == "Ground").GetComponentInChildren<Renderer>();
        }
    }
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
        _renderer.material.SetTexture(0, tex_);
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
