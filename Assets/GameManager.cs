using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int playerMana = 0;
    public Text manaText;

    public void AddMana()
    {
        playerMana += 1;
    }
    public void RemoveMana(int cardCost)
    {
        playerMana -= cardCost;
    }

    public void Update()
    {
        if(manaText.text != playerMana.ToString())
        {
            manaText.text = playerMana.ToString();
        }
    }
}
