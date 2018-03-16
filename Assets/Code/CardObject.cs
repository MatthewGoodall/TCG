using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public string cardName;
    public int cardCost;
    public Card currentCard;

    public Transform parentToReturnTo = null;

    GameObject placeholder = null;
    CardManager cardManager;


    public void Start()
    {
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        currentCard = cardManager.playerHand[cardManager.GetCardIndex(this.transform.GetChild(0).GetComponent<Text>().text)];
        cardCost = currentCard.Cost;
        cardName = currentCard.Name;

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;
        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());


        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeholder);
    }

   
    
}
