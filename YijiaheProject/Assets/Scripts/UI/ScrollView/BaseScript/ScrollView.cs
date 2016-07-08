using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ScrollView<T> : MonoBehaviour where T : ScrollItemInfo
{
    [SerializeField]
    ScrollRect scrollrect;

    [SerializeField]
    RectTransform scrollItemPrefab;

    /// <summary>
    /// 是否自动隐藏滚动条
    /// </summary>
    [SerializeField]
    bool autoHideScrollbar = false;
    /// <summary>
    /// 是否自动隐藏滚动条
    /// </summary>
    public bool AutoHideScrollbar
    {
        set
        {
            autoHideScrollbar = value;
        }
        get
        {
            return autoHideScrollbar;
        }
    }

    /// <summary>
    /// 当前值
    /// </summary>
    [SerializeField]
    int value = -1;
    public int Value
    {
        set
        {
            this.value = value;

            for (int i = 0; i < allScrollItemList.Count; i++)
            {
                if (i == value)
                    allScrollItemList[i].GetComponent<ScrollItem<T>>().SetState(true);
                else
                    allScrollItemList[i].GetComponent<ScrollItem<T>>().SetState(false);
            }

            OnScrollValueChanged.Invoke(this.value);
        }
        get
        {
            return value;
        }
    }

    public ScrollValueEvent OnScrollValueChanged = new ScrollValueEvent();

    /// <summary>
    /// 滚动视图的项目列表
    /// </summary>
    [SerializeField]
    List<RectTransform> allScrollItemList = new List<RectTransform>();

    public virtual void Start()
    {
        //注册值改变事件
        scrollrect.onValueChanged.AddListener(OnScrollRectValueChanged);
        if (scrollItemPrefab)
            scrollItemPrefab.gameObject.SetActive(false);
    }

    /// <summary>
    /// ScrollView值改变的时候调用
    /// </summary>
    /// <param name="arg0"></param>
    public virtual void OnScrollRectValueChanged(Vector2 arg0)
    {
        //if (scrollrect.verticalScrollbar.size >= 0.999f)
        if (scrollrect.verticalScrollbar != null)
            scrollrect.verticalScrollbar.gameObject.SetActive(true);
    }

    public virtual void DisplayScrollView(bool show)
    {
        scrollrect.gameObject.SetActive(show);
    }

    public virtual void LocationCurrentIndex()
    {
        scrollrect.verticalScrollbar.value = Value / allScrollItemList.Count;
    }

    /// <summary>
    /// 初始化ScrollView列表
    /// </summary>
    public virtual void InitScrollView(List<T> scrollContent)// where T : ScrollItemInfo
    {
        ClearList();
        if (scrollrect.verticalScrollbar != null)
            scrollrect.verticalScrollbar.gameObject.SetActive(!autoHideScrollbar);
        for (int i = 0; i < scrollContent.Count; i++)
        {
            RectTransform scrollitem = Instantiate(scrollItemPrefab) as RectTransform;
            scrollitem.SetParent(scrollrect.content);
            scrollitem.localPosition = Vector3.zero;
            scrollitem.localRotation = Quaternion.Euler(Vector3.zero);
            scrollitem.localScale = Vector3.one;
            ScrollItem<T> type = scrollitem.gameObject.GetComponent<ScrollItem<T>>();
            if (type == null)
                type = scrollitem.gameObject.AddComponent<ScrollItem<T>>();
            T info = scrollContent[i];
            type.SetItemInfo(info, OnScrollEventActive);
            scrollitem.gameObject.SetActive(true);
            allScrollItemList.Add(scrollitem);
        }

        Value = -1;
        DisplayScrollView(true);
    }

    void OnScrollEventActive(int i)
    {
        Value = i;
    }

    /// <summary>
    /// 清除ScrollView列表
    /// </summary>
    public virtual void ClearList()
    {
        for (int i = 0; i < allScrollItemList.Count; i++)
        {
            if (allScrollItemList[i] != null)
                DestroyImmediate(allScrollItemList[i].gameObject);
        }
        allScrollItemList.Clear();
    }
}