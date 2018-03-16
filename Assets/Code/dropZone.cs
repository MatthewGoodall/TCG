using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class dropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "Was dropped on: " + gameObject.name);
        CardObject cardObject = eventData.pointerDrag.GetComponent<CardObject>();
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(cardObject != null && gameManager.playerMana >= cardObject.cardCost)
        {
            cardObject.parentToReturnTo = this.transform;
            gameManager.RemoveMana(cardObject.cardCost);
            Card currentCard = cardObject.currentCard;
            Monster currentMonster = currentCard as Monster;
            MonsterEvents(currentMonster);
            
        }
        else
        {
            Debug.Log("Not enough mana");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
    public void MonsterEvents(Monster currentMonster)
    {
        string[] enums = Enum.GetNames(typeof(Monster.Abilities));
        for (int i = 0; i < enums.Length; i++)
        {
            
            if (enums[i] == currentMonster.Ability)
            {
                Debug.Log(enums[i]);
            }

        }
    }
}
