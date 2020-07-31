using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DieRoll : MonoBehaviour
{
    public static bool rolled = false;

    public void RollDice()
    {
        if (!rolled)
        {
            int totalNum = 0;
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;

                if (child.GetComponent<Animator>().enabled)
                {
                    child.GetComponent<Animator>().enabled = false;

                    int dieResult = Random.Range(1, 7);
                    child.GetComponent<Image>().sprite = Resources.Load<Sprite>("Tärningar/Tärning" + dieResult);

                    if (totalNum != 0) // WHEN ROLLED
                    {
                        rolled = true;
                        totalNum += dieResult;
                        ResourceDividense.Distribution(totalNum);
                        if (totalNum == 7)
                        {
                            ThiefScript.PlaceThief();
                            if (PlayerScript.activePlayer.isBot)
                            {
                                BotScript.BotPlaceThief();
                            }
                        }
                    }
                    else
                    {
                        totalNum += dieResult;
                    }
                }
                else if (!child.GetComponent<Animator>().enabled)
                {
                    child.GetComponent<Animator>().enabled = true;
                }
            }
        }
        
    }
}
