using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class JsonAnalysis
{
    JsonData jd;
    int status = -1;

    public JsonAnalysis(string message)
    {
        jd = JsonMapper.ToObject(message);
    }

    public JsonDataStatus MessageStatus
    {
        get
        {
            status = int.Parse(jd["Status"].ToString());
            return (JsonDataStatus)status;
        }
    }

    public string MessageContent
    {
        get
        {
            if (status == -1)
                status = int.Parse(jd["Status"].ToString());
            switch (status)
            {
                case (int)JsonDataStatus.s0:
                    return "操作失败";
                case (int)JsonDataStatus.s1:
                    return "操作成功";
                case (int)JsonDataStatus.s2:
                    return "数据请求失败";
                case (int)JsonDataStatus.s3:
                    return "已存在";
                case (int)JsonDataStatus.s4:
                    return "不存在";
                case (int)JsonDataStatus.s5:
                    return "没有数据";
                case (int)JsonDataStatus.s6:
                    return "没有登录";
                case (int)JsonDataStatus.s7:
                    return "密码错误";
                case (int)JsonDataStatus.s8:
                    return "没有足够的积分";
                case (int)JsonDataStatus.s9:
                    return "操作限制";
                case (int)JsonDataStatus.s10:
                    return "验证码错误";
                default:
                    return "操作失败";
            }
        }
    }

    public void SetUserInfo()
    {
        JsonData jm = jd["Message"];
        //UserInfo userinfo = new UserInfo();
        if (jm.Equals("Success"))
        {
            status = 1;
            //JsonData ds = jd["ds"];
        }
        else
            status = 0;
    }

    public override string ToString()
    {
        switch (status)
        {
            case (int)JsonDataStatus.s0:
                return "操作失败";
            case (int)JsonDataStatus.s1:
                return "操作成功";
            case (int)JsonDataStatus.s2:
                return "数据请求失败";
            case (int)JsonDataStatus.s3:
                return "已存在";
            case (int)JsonDataStatus.s4:
                return "不存在";
            case (int)JsonDataStatus.s5:
                return "没有数据";
            case (int)JsonDataStatus.s6:
                return "没有登录";
            case (int)JsonDataStatus.s7:
                return "密码错误";
            case (int)JsonDataStatus.s8:
                return "没有足够的积分";
            case (int)JsonDataStatus.s9:
                return "操作限制";
            case (int)JsonDataStatus.s10:
                return "验证码错误";
            default:
                return base.ToString();
        }
    }

    public static bool HasKey(JsonData jd, string key)
    {
        if (jd == null)
            return false;
        if (!jd.IsObject)
            return false;
        IDictionary idictionary = (IDictionary)jd;
        if (idictionary == null)
            return false;
        return idictionary.Contains(key);
    }
}

public enum JsonDataStatus
{
    /// <summary>
    /// 操作失败
    /// </summary>
    s0,
    /// <summary>
    /// 操作成功
    /// </summary>
    s1,
    /// <summary>
    /// 数据请求失败
    /// </summary>
    s2,
    /// <summary>
    /// 已存在
    /// </summary>
    s3,
    /// <summary>
    /// 不存在
    /// </summary>
    s4,
    /// <summary>
    /// 没有数据
    /// </summary>
    s5,
    /// <summary>
    /// 没有登录
    /// </summary>
    s6,
    /// <summary>
    /// 密码错误
    /// </summary>
    s7,
    /// <summary>
    /// 没有足够的积分
    /// </summary>
    s8,
    /// <summary>
    /// 操作限制
    /// </summary>
    s9,
    /// <summary>
    /// 验证码错误
    /// </summary>
    s10
}