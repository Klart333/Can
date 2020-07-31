using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class BuyDevCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static List<GameObject> cardList = new List<GameObject>();

    [SerializeField]
    GameObject cardPanel;
    
    public static Vector4 cardPosition = new Vector4();
    private void Start()
    {
        cardPosition = new Vector4(0, 0, 0.2f, 0.3f);
    }
    public void BuyCard()
    {
        if (true/*PlayerScript.activePlayer.sheepAmount >= 1 && PlayerScript.activePlayer.wheatAmount >= 1 && PlayerScript.activePlayer.stoneAmount >= 1*/)
        {
            ResourceScript.GiveSheep(-1);
            ResourceScript.GiveWheat(-1);
            ResourceScript.GiveStone(-1);

            int randNum = Random.Range(1, 5);
            RectTransform card = ((GameObject)Instantiate(Resources.Load("DevCards/" + randNum.ToString()), cardPanel.transform)).GetComponent<RectTransform>();
            card.anchorMin = new Vector2(cardPosition.x, cardPosition.y);
            card.anchorMax = new Vector2(cardPosition.z, cardPosition.w);

            cardList.Add(card.gameObject);

            cardPosition.x += 0.1f;
            cardPosition.z += 0.1f;
        }
        
    } 

    public void OnPointerEnter(PointerEventData eventData)
    {
        CostPanelScript.CreateCostPanel(new List<Vector2>() { new Vector2(3, 1), new Vector2(4, 1), new Vector2(5, 1) }, "");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CostPanelScript.DeleteCostPanel();

    }

    public static void RemoveCard(GameObject cardToRemove)
    {
        cardPosition.x -= 0.1f;
        cardPosition.z -= 0.1f;

        int x = cardList.IndexOf(cardToRemove);
        cardList.Remove(cardToRemove);
        Destroy(cardToRemove);

        foreach (GameObject card in cardList)
        {
            if (cardList.IndexOf(card) >= x)
            {
                card.GetComponent<RectTransform>().anchorMin = new Vector2(card.GetComponent<RectTransform>().anchorMin.x - 0.1f, card.GetComponent<RectTransform>().anchorMin.y);
                card.GetComponent<RectTransform>().anchorMax = new Vector2(card.GetComponent<RectTransform>().anchorMax.x - 0.1f, card.GetComponent<RectTransform>().anchorMax.y);

            }

        }
    }
}
