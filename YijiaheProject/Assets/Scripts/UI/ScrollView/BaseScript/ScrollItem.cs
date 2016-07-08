using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ScrollItem<T> : MonoBehaviour where T : ScrollItemInfo
{
    ScrollValueEvent scrollValueEvent = new ScrollValueEvent();


    // Use this for initialization
    void Start()
    {

    }

    public virtual void SetItemInfo(T scrolliteminfo, UnityAction<int> ua)
    {
        if (ua != null)
            scrollValueEvent.AddListener(ua);
    }

    public virtual void SetState(bool state)
    {

    }

    public virtual void ActiveEvent(int i)
    {
        scrollValueEvent.Invoke(i);
    }

    public virtual void Dispose()
    {
        scrollValueEvent.RemoveAllListeners();
    }
}

[System.Serializable]
public class ScrollValueEvent : UnityEvent<int> { }

[System.Serializable]
public class ScrollItemInfo
{
    [SerializeField]
    int index = -1;
    /// <summary>
    /// 序号
    /// </summary>
    public int Index
    {
        set
        {
            index = value;
        }
        get
        {
            return index;
        }
    }

    [SerializeField]
    string id;
    /// <summary>
    /// 标题ID
    /// </summary>
    public string ID
    {
        set
        {
            id = value;
        }
        get
        {
            return id;
        }
    }

    [SerializeField]
    string name;
    /// <summary>
    /// 标题名称
    /// </summary>
    public string Name
    {
        set
        {
            name = value;
        }
        get
        {
            return name;
        }
    }

    [SerializeField]
    string description;
    /// <summary>
    /// 描述
    /// </summary>
    public string Description
    {
        set
        {
            description = value;
        }
        get
        {
            return description;
        }
    }

    public ScrollItemInfo()
    {

    }

    public virtual void SetItemInfo()
    {

    }
}
