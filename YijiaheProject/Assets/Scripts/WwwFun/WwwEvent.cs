using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;


[Serializable]
public class WwwEvent : UnityEvent<float> { }

/// <summary>
/// 网络加载回调时间
/// </summary>
public class WwwCallBack
{
    public WwwCallBack() { }

    public WwwCallBack(UnityAction<float> uai, UnityAction<float> uae)
    {
        AddIngEvent(uai);
        AddEndEvent(uae);
    }

    /// <summary>
    /// 加载中事件
    /// </summary>
    WwwEvent LoadingEvent = new WwwEvent();

    /// <summary>
    /// 执行加载中事件
    /// </summary>
    /// <param name="clear">清空加载事件</param>
    public void ActiveIngEvent(bool clear)
    {
        ActiveIngEvent(clear, 0);
    }

    /// <summary>
    /// 执行加载中事件
    /// </summary>
    /// <param name="clear">清空加载事件</param>
    /// <param name="obj"></param>
    public void ActiveIngEvent(bool clear, float obj)
    {
        if (LoadingEvent != null)
            LoadingEvent.Invoke(obj);
        if (clear)
            if (LoadendEvent != null)
                LoadingEvent.RemoveAllListeners();
    }

    /// <summary>
    /// 添加加载中事件
    /// </summary>
    /// <param name="ua"></param>
    public void AddIngEvent(UnityAction<float> ua)
    {
        if (ua != null)
            LoadingEvent.AddListener(ua);
    }

    //public void AddIngEvent(UnityAction<float>[] ua)
    //{
    //    for (int i = 0; i < ua.Length; i++)
    //    {
    //        if (ua[i] != null)
    //            LoadingEvent.AddListener(ua[i]);
    //    }
    //}

    /// <summary>
    /// 加载完成事件
    /// </summary>
    WwwEvent LoadendEvent = new WwwEvent();

    /// <summary>
    /// 执行加载完成事件
    /// </summary>
    /// <param name="clear"></param>
    public void ActiveEndEvent(bool clear)
    {
        ActiveEndEvent(clear, 0);
    }

    /// <summary>
    /// 执行加载完成事件
    /// </summary>
    /// <param name="clear"></param>
    /// <param name="obj"></param>
    public void ActiveEndEvent(bool clear, float obj)
    {
        if (LoadendEvent != null)
        {
            LoadendEvent.Invoke(obj);
        }
        if (clear)
            if (LoadendEvent != null)
                LoadendEvent.RemoveAllListeners();
    }

    /// <summary>
    /// 添加加载完成事件
    /// </summary>
    /// <param name="ua"></param>
    public void AddEndEvent(UnityAction<float> ua)
    {
        if (ua != null)
            LoadendEvent.AddListener(ua);
    }

    //public void AddEndEvent(UnityAction<float>[] ua)
    //{
    //    for (int i = 0; i < ua.Length; i++)
    //    {
    //        if (ua[i] != null)
    //            LoadendEvent.AddListener(ua[i]);
    //    }
    //}
}