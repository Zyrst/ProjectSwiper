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
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform);

        switch (_barType) {
            case BarType.Health:
                if (_character != null)
                    _foreground.transform.localScale = new Vector3(_character._health / _character._maxHealth, 1, 1);
                break;
            case BarType.Cooldown:
                if (_enemy != null)
                    _foreground.transform.localScale = new Vector3(1 - (_enemy._attackCounter / _enemy._attackCooldown), 1, 1);
                break;
        }

    }
}
