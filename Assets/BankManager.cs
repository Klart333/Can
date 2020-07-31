using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
public class BankManager : MonoBehaviour
{
    public static string resourceToGive = "";
    public static string resourceToGet = "";

    public static GameObject pushedPanelGive;
    public static GameObject pushedPanelGet;

    public void ConfirmExchange()
    {
        if (resourceToGet != "" && resourceToGive != "")
        {
            PlayerScript playerScript = new PlayerScript();
            PlayerScript.Player player = (PlayerScript.Player)playerScript.GetType().GetTypeInfo().GetField("activePlayer").GetValue(this);

            
            if ((int)player.GetType().GetTypeInfo().GetProperty(resourceToGive.ToLower() + "Amount").GetValue(player) >= 4)
            {
                

                ResourceScript script = new ResourceScript();

                MethodInfo method = script.GetType().GetTypeInfo().GetMethod("Give" + resourceToGive);

                object[] parameter = new object[] { -4 };
                method.Invoke(script.GetType(), parameter);



                MethodInfo method2 = script.GetType().GetTypeInfo().GetMethod("Give" + resourceToGet);

                object[] parameter2 = new object[] { 1 };
                method2.Invoke(script.GetType(), parameter2);
            }
            

        }

    }
}
