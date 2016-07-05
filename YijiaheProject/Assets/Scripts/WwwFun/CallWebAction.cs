using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CallWebAction : MonoBehaviour
{
    public static WebEvent OnCallFromWebEvent = new global::WebEvent();

    // Use this for initialization
    void Start()
    {

    }

    public static void SendToWebPage(string message)
    {
        Application.ExternalCall("CallFromUnity", message);
    }

    public void CallFromWebPage(string message)
    {
        //MessageBox.Show(message);
        OnCallFromWebEvent.Invoke(message);
    }

    public static void FullScreen(bool state)
    {
        Application.ExternalCall("ToFull", state);
    }
}

public class WebEvent : UnityEvent<string> { }