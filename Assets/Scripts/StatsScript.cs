using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Globalization;

public class StatsScript : MonoBehaviour {

    public Text moneyCollected;
    public Text moneySpent;
    public Text damageReceived;
    public Text damageDelt;
    public Text enemiesKilled;
    public Text timesEnemiesKilled;
    public Text timeSpentPlaying;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        moneyCollected.text = References.Instance._stats.moneyCollected.ToString();
        moneySpent.text = References.Instance._stats.moneySpent.ToString();
        damageReceived.text = References.Instance._stats.damageRecived.ToString();
        damageDelt.text = References.Instance._stats.damageDelt.ToString();
        enemiesKilled.text = References.Instance._stats.enemiesKilled.ToString();
        timesEnemiesKilled.text = References.Instance._stats.timesEnemiesKilled.ToString();

        TimeSpan timeSpan = TimeSpan.FromSeconds(References.Instance._stats.timeSpentPlayingSeconds);
        string timeText = References.Instance._stats.timeSpentPlayingDays.ToString() + ":" + 
            string.Format("{0:D2}:{1:D2}", timeSpan.Hours, timeSpan.Minutes);
        timeSpentPlaying.text = timeText;
	}

    public void Exit()
    {
        Sounds.OneShot(Sounds.Instance.ui.buttonClick);
        Destroy(this.gameObject);
    }
}
