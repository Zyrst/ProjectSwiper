using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextParticleScript : MonoBehaviour {

    string _string = "<UNDEF>";
    public Text _textRef;

    float _lifeTime = 0;
    float _maxLifeTime = 1;

    Vector3 _speed;

	// Use this for initialization
	void Start () {
        transform.forward = -Camera.main.transform.forward;
        _speed = new Vector3(Random.Range(-2, 2), 6f, Random.Range(-2, 2));
    }

    // Update is called once per frame
    void Update () {
        transform.forward = Camera.main.transform.forward;

        if (_textRef)
            _textRef.text = _string;

        _lifeTime += Time.deltaTime;
        if (_lifeTime > _maxLifeTime)
            GameObject.Destroy(transform.gameObject);

        _speed += new Vector3(0, -9 * Time.deltaTime, 0);
        transform.position += _speed * Time.deltaTime;
	}

    public void SetText(string text)
    {
        _string = text;
    }

    public void SetMaxLifeTime(float t)
    {
        _maxLifeTime = t;
    }
}
