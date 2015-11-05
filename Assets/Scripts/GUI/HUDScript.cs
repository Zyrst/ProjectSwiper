using UnityEngine;
using UnityEngine.UI;
    
public class HUDScript : MonoBehaviour {

    public Text _currencyTextComponent;
    public string _currencyTextString = "Currency: ";
    public Text _levelTextComponent;
    public string _levelTextString = "Level: ";
    public Text _waveTextComponent;
    public string _waveTextString = "Wave: ";


    // Use this for initialization
    void Start ()
    {
        if (_currencyTextComponent)
            _currencyTextComponent.GetComponent<CurrencyGUI>()._string = _currencyTextString;
        if (_levelTextComponent)
            _levelTextComponent.GetComponent<LevelGUI>()._string = _levelTextString;
        if (_waveTextComponent)
            _waveTextComponent.GetComponent<WaveGUI>()._string = _waveTextString;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
