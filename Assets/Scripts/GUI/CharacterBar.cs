using UnityEngine;
using UnityEngine.UI;

public class CharacterBar : MonoBehaviour {

    public enum BarType {
        Health,
        Cooldown
    }
    public BarType _barType;

    public EnemyAttack _enemy;
    public Character _character;
    public Image _foreground;
    public Image _background;
    public Image _border;
    private Vector2 _foregroundStartSize;

    // Use this for initialization
	void Start () {
        Debug.Assert(_foreground != null, "Could not find reference to foreground");
        Debug.Assert(_background != null, "Could not find reference to background");
        Debug.Assert(_border     != null, "Could not find reference to border");

        // Try to find enemy
        if (transform.parent != null) {
            _character = transform.parent.GetComponent<Character>();
            _enemy = transform.parent.GetComponent<EnemyAttack>();
        }

        _foregroundStartSize = _foreground.GetComponent<RectTransform>().sizeDelta;
    }
	
	// Update is called once per frame
	void Update () {
        // If projection, yes below. Otherwise no pls
        // transform.LookAt(Camera.main.transform.position);
        transform.forward = -Camera.main.transform.forward;
        Vector2 newSize = Vector2.zero;
        switch (_barType) {
            case BarType.Health:
                if (_character != null)
                    //_foreground.transform.localScale = new Vector3(_character._health / _character._maxHealth, 1, 1);
                    newSize = new Vector2(_foregroundStartSize.x * _character._health / _character._maxHealth, _foregroundStartSize.y);
                    _foreground.GetComponent<RectTransform>().sizeDelta = newSize;
                break;
            case BarType.Cooldown:
                if (_enemy != null)
                    //_foreground.transform.localScale = new Vector3(1 - (_enemy._attackCounter / _enemy._attackCooldown), 1, 1);
                    newSize = new Vector2(_foregroundStartSize.x * (1 - (_enemy._attackCounter / _enemy._attackCooldown)), _foregroundStartSize.y);
                    _foreground.GetComponent<RectTransform>().sizeDelta = newSize;
                break;
        }

    }
}
