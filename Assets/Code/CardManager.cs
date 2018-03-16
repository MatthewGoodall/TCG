using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardManager : MonoBehaviour
{

    const int handSize = 7;
    const int startingHandSize = 3;
    public List<Card> playerHand = new List<Card>();
    public GameObject cardPrefab;
    public GameObject handPanel;
    public CardContainer cardCollection;

    void Start()
    {
        cardCollection = CardContainer.Load(Application.streamingAssetsPath + "/XML/Card.xml");
        DrawStartingHand();
    }


    public int GetCardIndex(string name)
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            Card currentCard = playerHand[i];
            if (currentCard != null)
            {
                if (currentCard.Name == name)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    public void DrawStartingHand()
    {
        for (int i = 0; i < startingHandSize; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        int num = Random.Range(0, cardCollection.allCards.Count);
        Card currentCard = cardCollection.allCards[num];
        CreateCardPrefab(currentCard);
        playerHand.Add(cardCollection.allCards[num]);
    }

    public void CreateCardPrefab(Card currentCard)
    {
        Monster monster = currentCard as Monster;

        if (monster != null)
        {
            Debug.Log("Name:" + monster.Name + ", Attack:" + monster.Attack + ", Health:" + monster.Health);
            GameObject card = Instantiate(cardPrefab, handPanel.transform.position, handPanel.transform.rotation);
            card.transform.SetParent(handPanel.transform);
            card.transform.GetChild(0).GetComponent<Text>().text = currentCard.Name;
            card.transform.GetChild(2).GetComponent<Text>().text = monster.Desc;
        }
    }
}



