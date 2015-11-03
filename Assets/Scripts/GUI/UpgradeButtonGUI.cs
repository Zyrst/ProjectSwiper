using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeButtonGUI : Button {

    public override void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        upgradePlayer();
    }

    private void upgradePlayer()
    {
        if (Game.Instance._gameCurrency >= 100)
        {
            Sounds.OneShot(Sounds.Instance.ui.upgradeBuy);
            References.Instance._currentPlayer.GetComponent<Player>()._damage += 1;
            References.Instance._currentPlayer.GetComponent<Player>()._maxHealth += 10;
            Game.Instance._gameCurrency -= 100;
            Game.Instance._level += 1;
            SaveManager.Save();
            Debug.Log("Upgraded player");
        }
        else
        {
            Debug.Log("Not enough currency");
        }
    }
}
