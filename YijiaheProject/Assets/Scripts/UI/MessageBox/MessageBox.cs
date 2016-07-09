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
        messageBoxContent.warning.SetActive(false);
        messageBoxContent.progressBar.gameObject.SetActive(false);
        messageBoxContent.button_OK.onClick.AddListener(OnOkClick);
        messageBoxContent.button_Cancel.onClick.AddListener(OnCancelClick);
    }

    void Start()
    {

    }

    private void OnOkClick()
    {
        messageBoxContent.messageEvent.Invoke(MessageResult.OK);
        Display(false);
    }

    private void OnCancelClick()
    {
        messageBoxContent.messageEvent.Invoke(MessageResult.Cancel);
        Display(false);
    }

    /// <summary>
    /// 显示隐藏消息提示框
    /// </summary>
    /// <param name="state"></param>
    public static void Display(bool state)
    {
        instance.messageBoxContent.boxContent.SetActive(state);
        if (state)
        {

        }
        else
        {
            instance.messageBoxContent.warning.SetActive(false);
            instance.messageBoxContent.progressBar.gameObject.SetActive(false);
            instance.messageBoxContent.messageEvent.RemoveAllListeners();
        }
    }

    /// <summary>
    /// 显示简单消息提示框
    /// </summary>
    /// <param name="message"></param>
    public static void Display(string message)
    {
        Display("提示", message);
    }

    /// <summary>
    /// 显示带标题的消息对话框
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    public static void Display(string title, string message)
    {
        Display(title, message, new string[] { "确定", "取消" });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="buttonname"></param>
    public static void Display(string title, string message, string[] buttonname)
    {
        Display(title, message, buttonname, null);
    }

    /// <summary>
    /// 显示支持回调的消息提示框
    /// </summary>
    /// <param name="message"></param>
    /// <param name="callback"></param>
    public static void Display(string message, UnityAction<MessageResult> callback)
    {
        Display("提示", message, callback);
    }

    /// <summary>
    /// 显示带标题的支持回调的消息提示框
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="callback"></param>
    public static void Display(string title, string message, UnityAction<MessageResult> callback)
    {
        Display(title, message, new string[] { "确定", "取消" }, callback);
    }

    /// <summary>
    /// 显示带标题的带按钮支持回调的消息提示框
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="buttonname"></param>
    /// <param name="callback"></param>
    public static void Display(string title, string message, string[] buttonname, UnityAction<MessageResult> callback)
    {
        Display(true);

        instance.messageBoxContent.title.text = title;
        instance.messageBoxContent.Message.text = message;

        instance.messageBoxContent.button_OK.gameObject.SetActive(false);
        instance.messageBoxContent.button_Cancel.gameObject.SetActive(false);

        if (buttonname != null)
        {
            if (buttonname.Length > 0)
            {
                instance.messageBoxContent.buttonOK_Content.text = buttonname[0];
                instance.messageBoxContent.button_OK.gameObject.SetActive(true);
            }
            if (buttonname.Length > 1)
            {
                instance.messageBoxContent.buttonCancel_Content.text = buttonname[1];
                instance.messageBoxContent.button_Cancel.gameObject.SetActive(true);
            }
        }

        if (callback != null)
            instance.messageBoxContent.messageEvent.AddListener(callback);

    }

    /// <summary>
    /// 显示定时关闭的消息显示框
    /// </summary>
    /// <param name="message"></param>
    /// <param name="delaytime"></param>
    /// <param name="callback"></param>
    public static void Display(string message, float delaytime, UnityAction<MessageResult> callback)
    {
        Display("提示", message, null, callback);
        instance.WaitForEnd(delaytime);
    }

    float waitingTime = 0;

    void WaitForEnd(float time)
    {
        waitingTime = time;
        StartCoroutine("WaitForEndAnysc");
    }

    IEnumerator WaitForEndAnysc()
    {
        yield return new WaitForSeconds(waitingTime);
        messageBoxContent.messageEvent.Invoke(MessageResult.None);

        Display(false);
    }

    /// <summary>
    /// 显示进度条进度显示框
    /// </summary>
    /// <param name="message"></param>
    /// <param name="progress"></param>
    public static void Display(string message, float progress)
    {
        Display("加载中", message, progress);
    }

    /// <summary>
    /// 显示带标题的进度条进度显示框
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="progress"></param>
    public static void Display(string title, string message, float progress)
    {
        Display(title, message, null, null);
        instance.messageBoxContent.progressBar.gameObject.SetActive(true);
        instance.messageBoxContent.progressBar.value = progress;
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

    [SerializeField]
    Text message;

    /// <summary>
    /// 消息内容
    /// </summary>
    public Text Message
    {
        set
        {
            message = value;
        }
        get
        {
            return message;
        }
    }

    public Button button_OK;

    public Text buttonOK_Content;

    public Button button_Cancel;

    public Text buttonCancel_Content;

    public MessageEvent messageEvent = new MessageEvent();
}

public enum MessageResult
{
    None,
    OK,
    Cancel,
}

[System.Serializable]
public class MessageEvent : UnityEvent<MessageResult> { };