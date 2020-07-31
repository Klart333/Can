using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBotAmount : MonoBehaviour
{
    public void BotAmountSetted()
    {
        BotScript.botAmount = int.Parse(gameObject.name);
    }
}
