using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class MessageBox : MonoBehaviour
{
    static MessageBox instance;

    [SerializeField]
    MessageBoxContent messageBoxContent;

    /// <summary>
    /// 消息盒子实例
    /// </summary>
    public static MessageBox Instance
    {
        internal set
        {
            instance = value;
        }
        get
        {

            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    /// <summary>
    /// 显示隐藏消息提示框
    /// </summary>
    /// <param name="state"></param>
    public static void Display(bool state)
    {

    }

    /// <summary>
    /// 显示简单消息提示框
    /// </summary>
    /// <param name="message"></param>
    public static void Display(string message)
    {

    }

    /// <summary>
    /// 显示带标题的消息对话框
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    public static void Dispaly(string title, string message)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="buttonname"></param>
    public static void Dispaly(string title, string message, string[] buttonname)
    {

    }

    /// <summary>
    /// 显示支持回调的消息提示框
    /// </summary>
    /// <param name="message"></param>
    /// <param name="callback"></param>
    public static void Display(string message, UnityAction<MessageResult> callback)
    {

    }

    /// <summary>
    /// 显示带标题的支持回调的消息提示框
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="callback"></param>
    public static void Dispaly(string title, string message, UnityAction<MessageResult> callback)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="buttonname"></param>
    /// <param name="callback"></param>
    public static void Dispaly(string title, string message, string[] buttonname, UnityAction<MessageResult> callback)
    {

    }

    /// <summary>
    /// 显示定时关闭的消息显示框
    /// </summary>
    /// <param name="message"></param>
    /// <param name="delaytime"></param>
    /// <param name="callback"></param>
    public static void Display(string message, float delaytime, UnityAction<MessageResult> callback)
    {

    }

    /// <summary>
    /// 显示进度条进度显示框
    /// </summary>
    /// <param name="message"></param>
    /// <param name="progress"></param>
    public static void Display(string message, float progress)
    {

    }

    /// <summary>
    /// 显示带标题的进度条进度显示框
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="progress"></param>
    public static void Display(string title, string message, float progress)
    {

    }
}

[System.Serializable]
public class MessageBoxContent
{
    public GameObject boxContent;
    public GameObject warning;
    public Slider progressBar;
    public ScrollRect scrollRect;
    public Text title;
    public Text content;
    public Button button_OK;
    public Text buttonOK_Content;
    public Button button_Cancel;
    public Text buttonCancel_Content;
}

public enum MessageResult
{
    None,
    OK,
    Cancel,
}

public class MessageEvent : UnityEvent<MessageResult> { };