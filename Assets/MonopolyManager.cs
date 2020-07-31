using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class MonopolyManager : MonoBehaviour
{
    public static int resourceToSwitch = 0;

    public static string resourceToGet1 = "";
    public static string resourceToGet2 = "";

    public static GameObject pushedPanelGet1;
    public static GameObject pushedPanelGet2;

    public void ConfirmExchange()
    {
        if (resourceToGet1 != "" && resourceToGet2 != "")
        {
            PlayerScript playerScript = new PlayerScript();
            ResourceScript script = new ResourceScript();

            MethodInfo method = script.GetType().GetTypeInfo().GetMethod("Give" + resourceToGet2);

            object[] parameter = new object[] { 1 };
            method.Invoke(script.GetType(), parameter);

            MethodInfo method2 = script.GetType().GetTypeInfo().GetMethod("Give" + resourceToGet1);

            object[] parameter2 = new object[] { 1 };
            method2.Invoke(script.GetType(), parameter2);

            Destroy(transform.parent.gameObject);

        }

    }
}
