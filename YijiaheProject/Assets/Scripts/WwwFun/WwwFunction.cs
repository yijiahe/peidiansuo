/*
 * 网络上传与下载
 */
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

/// <summary>
/// 网络下载类
/// </summary>
public class WwwLoad
{
    /// <summary>
    /// 加载文本
    /// </summary>
    /// <param name="tc">文本内容</param>
    /// <param name="uaing">加载中回调</param>
    /// <param name="uaend">加载结束回调</param>
    public static void LoadText(WwwText tc, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        LoadText(tc, MonoBehaviourAnysc.AnyscMonoBehaviour, uaing, uaend);
    }

    /// <summary>
    /// 加载文本
    /// </summary>
    /// <param name="tc">文本内容</param>
    /// <param name="uaing">加载中回调</param>
    /// <param name="uaend">加载结束回调</param>
    public static void LoadText(WwwText tc, MonoBehaviour mb, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        mb.StartCoroutine(InvokeLoadText(tc, uaing, uaend));
    }

    static IEnumerator InvokeLoadText(WwwText tc, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        //注册回调事件
        WwwCallBack wle = new WwwCallBack();
        if (uaing != null)
            wle.AddIngEvent(uaing);
        if (uaend != null)
            wle.AddEndEvent(uaend);

        tc.LoadState = LoadState.LoadIng;

        //记录开始加载时间
        tc.LoadStartTime = DateTime.Now;
        //开始下载资源
        WWW www = new WWW(tc.SourceUrl);

        while (!www.isDone)// || www.progress <= 1)
        {
            float o = www.progress;
            tc.Progress = www.progress;
            wle.ActiveIngEvent(false, o);
            yield return null;
        }
        float o1 = www.progress;
        wle.ActiveIngEvent(true, o1);
        tc.Progress = www.progress;

        //加载错误
        tc.LoadError = www.error;
        if (www.error != null)
        {
            tc.LoadState = LoadState.LoadFail;
            Debug.Log("Load Error:" + www.error);
        }
        else
        {
            tc.Size = www.size;
            tc.Data = www.bytes;
            tc.TextContent = www.text;

            tc.LoadState = LoadState.LoadComplete;
        }

        tc.LoadEndTime = DateTime.Now;
        wle.ActiveEndEvent(true);
    }

    /// <summary>
    /// 加载图片
    /// </summary>
    /// <param name="ic">图片内容</param>
    /// <param name="mb">MonoBehaviour</param>
    /// <param name="uaing">加载中回调</param>
    /// <param name="uaend">加载结束回调</param>
    public static void LoadImage(WwwImage ic, MonoBehaviour mb, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        mb.StartCoroutine(InvokeLoadImage(ic, uaing, uaend));
    }

    /// <summary>
    /// 加载图片
    /// </summary>
    /// <param name="ic">图片内容</param>
    /// <param name="uaing">加载中回调</param>
    /// <param name="uaend">加载结束回调</param>
    public static void LoadImage(WwwImage ic, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        LoadImage(ic, MonoBehaviourAnysc.AnyscMonoBehaviour, uaing, uaend);
    }

    static IEnumerator InvokeLoadImage(WwwImage ic, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        //注册回调事件
        WwwCallBack wle = new WwwCallBack();
        if (uaing != null)
            wle.AddIngEvent(uaing);
        if (uaend != null)
            wle.AddEndEvent(uaend);

        ic.LoadState = LoadState.LoadIng;

        ic.LoadStartTime = DateTime.Now;
        //开始下载资源
        WWW www = new WWW(ic.SourceUrl);

        while (!www.isDone)// || www.progress <= 1)
        {
            float o = www.progress;
            ic.Progress = www.progress;
            wle.ActiveIngEvent(false, o);
            yield return null;
        }
        float o1 = www.progress;
        ic.Progress = www.progress;
        wle.ActiveIngEvent(true, o1);

        //加载错误
        ic.LoadError = www.error;
        if (www.error != null)
        {
            ic.LoadState = LoadState.LoadFail;
            Debug.Log("Load Error:" + ic.SourceUrl + ":" + www.error);

            //MessageBox.ShowInEditor(www.error);
        }
        else
        {
            ic.Size = www.size;


            if (ic.SourceUrl.Contains(".gif"))
            {
                ic.ImageContent = AnalysisPage.GetGifImage(www.bytes, 0);
            }
            else
            {
                ic.ImageContent = www.texture;
            }

            ic.LoadState = LoadState.LoadComplete;
        }

        ic.LoadEndTime = DateTime.Now;
        wle.ActiveEndEvent(true);
    }

    /// <summary>
    /// 加载模型或场景文件
    /// </summary>
    /// <param name="bc">模型或场景文件内容</param>
    /// <param name="uaing">加载中回调</param>
    /// <param name="uaend">加载结束回调</param>
    public static void LoadBundle(WwwBundle bc, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        LoadBundle(bc, MonoBehaviourAnysc.AnyscMonoBehaviour, uaing, uaend, ThreadPriority.Normal);
    }

    /// <summary>
    /// 加载模型或场景文件
    /// </summary>
    /// <param name="bc">模型或场景文件内容</param>
    /// <param name="mb">MonoBehaviour</param>
    /// <param name="uaing">加载中回调</param>
    /// <param name="uaend">加载结束回调</param>
    /// <param name="threadPriority">优先级别</param>
    public static void LoadBundle(WwwBundle bc, MonoBehaviour mb, UnityAction<float> uaing, UnityAction<float> uaend, ThreadPriority threadPriority)
    {
        mb.StartCoroutine(InvokeLoadbundle(bc, uaing, uaend, threadPriority));
    }

    static IEnumerator InvokeLoadbundle(WwwBundle bc, UnityAction<float> uaing, UnityAction<float> uaend, ThreadPriority threadPriority)
    {
        //注册回调事件
        WwwCallBack wle = new WwwCallBack();
        if (uaing != null)
            wle.AddIngEvent(uaing);
        if (uaend != null)
            wle.AddEndEvent(uaend);

        bc.LoadState = LoadState.LoadIng;

        bc.LoadStartTime = DateTime.Now;
        //开始下载资源
        WWW www = new WWW(bc.SourceUrl);
        www.threadPriority = threadPriority;

        while (!www.isDone)// || www.progress <= 1)
        {
            float o = www.progress;
            bc.Progress = www.progress;
            wle.ActiveIngEvent(false, o);
            yield return null;
        }
        float o1 = www.progress;
        bc.Progress = www.progress;
        wle.ActiveIngEvent(true, o1);

        //加载错误
        bc.LoadError = www.error;
        if (www.error != null)
        {
            bc.LoadState = LoadState.LoadFail;
            Debug.Log("Load Error:" + bc.SourceUrl + ":" + www.error);

            //MessageBox.ShowInEditor(www.error);
        }
        else
        {
            bc.Size = www.size;

            bc.Bundle = www.assetBundle;

            bc.LoadState = LoadState.LoadComplete;
        }

        bc.LoadEndTime = DateTime.Now;
        wle.ActiveEndEvent(true);
    }

    /// <summary>
    /// 加载音频
    /// </summary>
    /// <param name="ac">音频内容</param>
    /// <param name="mb">MonoBehaviour</param>
    /// <param name="uaing">加载中回调</param>
    /// <param name="uaend">加载结束回调</param>
    public static void LoadAudio(WwwAudio ac, MonoBehaviour mb, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        mb.StartCoroutine(InvokeLoadaudio(ac, uaing, uaend));
    }

    /// <summary>
    /// 加载音频
    /// </summary>
    /// <param name="ac">音频内容</param>
    /// <param name="uaing">加载中回调</param>
    /// <param name="uaend">加载结束回调</param>
    public static void LoadAudio(WwwAudio ac, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        LoadAudio(ac, MonoBehaviourAnysc.AnyscMonoBehaviour, uaing, uaend);
    }

    static IEnumerator InvokeLoadaudio(WwwAudio ac, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        //注册回调事件
        WwwCallBack wle = new WwwCallBack();
        if (uaing != null)
            wle.AddIngEvent(uaing);
        if (uaend != null)
            wle.AddEndEvent(uaend);

        ac.LoadState = LoadState.LoadIng;
        ac.LoadStartTime = DateTime.Now;
        //开始下载资源
        WWW www = new WWW(ac.SourceUrl);

        ac.AudioContent = www.GetAudioClip(ac.Three3D);

        while (!www.isDone)// || www.progress <= 1)
        {
            float o = www.progress;
            ac.Progress = www.progress;
            wle.ActiveIngEvent(false, o);
            yield return null;
        }
        float o1 = www.progress;
        ac.Progress = www.progress;
        wle.ActiveIngEvent(true, o1);

        ac.LoadError = www.error;
        if (www.error != null)
        {
            ac.LoadState = LoadState.LoadFail;
            Debug.Log("Load Error:" + www.error);

            //MessageBox.ShowInEditor(www.error);
        }
        else
        {
            ac.Size = www.size;

            ac.LoadState = LoadState.LoadComplete;
        }

        ac.LoadEndTime = DateTime.Now;
        wle.ActiveEndEvent(true);
    }

    /// <summary>
    /// 加载视频
    /// </summary>
    /// <param name="mc">视频内容</param>
    /// <param name="mb">MonoBehaviour</param>
    /// <param name="uaing">加载中回调</param>
    /// <param name="uaend">加载结束回调</param>
    public static void LoadMovie(WwwMovie mc, MonoBehaviour mb, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        mb.StartCoroutine(InvokeLoadmovie(mc, uaing, uaend));
    }

    ///<summary>
    /// 加载视频
    ///</summary>
    ///<param name="mc">视频内容</param>
    ///<param name="uaing">加载中回调</param>
    ///<param name="uaend">加载结束回调</param>
    public static void LoadMovie(WwwMovie mc, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        LoadMovie(mc, MonoBehaviourAnysc.AnyscMonoBehaviour, uaing, uaend);
    }

    static IEnumerator InvokeLoadmovie(WwwMovie mc, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        //注册回调事件
        WwwCallBack wle = new WwwCallBack();
        if (uaing != null)
            wle.AddIngEvent(uaing);
        if (uaend != null)
            wle.AddEndEvent(uaend);

        mc.LoadState = LoadState.LoadIng;
        mc.LoadStartTime = DateTime.Now;
        //开始下载资源
        WWW www = new WWW(mc.SourceUrl);

        mc.MovieContent = www.movie;
        while (!www.isDone)// || www.progress <= 1)
        {
            float o = www.progress;
            mc.Progress = www.progress;
            wle.ActiveIngEvent(false, o);
            yield return null;
        }
        float o1 = www.progress;
        mc.Progress = www.progress;
        wle.ActiveIngEvent(true, o1);
        mc.LoadState = LoadState.LoadComplete;

        mc.LoadError = www.error;
        if (www.error != null)
        {
            mc.LoadState = LoadState.LoadFail;
            Debug.Log("Load Error:" + www.error);
            //MessageBox.ShowInEditor(www.error);
        }
        else
        {
            mc.Size = www.size;
        }

        mc.LoadEndTime = DateTime.Now;
        wle.ActiveEndEvent(true);
    }

}

/// <summary>
/// 网络上传类
/// </summary>
public class WwwUpload
{
    public static Dictionary<string, string> dictionary = new Dictionary<string, string>();
    public static float TimeOut = 5f;

    public static void Submit(WwwText wt, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        if (wt.SourceUrl == null || wt.SourceUrl.Length < 1)
        {
            Debug.LogWarning("请确认网址正确");
            return;
        }
        MonoBehaviourAnysc.AnyscMonoBehaviour.StartCoroutine(SubmitToServer(wt, null, uaing, uaend));
    }

    public static void Submit(WwwText wt, WWWForm wf, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        if (wt.SourceUrl == null || wt.SourceUrl.Length < 1)
        {
            Debug.LogWarning("请确认网址正确");
            return;
        }
        MonoBehaviourAnysc.AnyscMonoBehaviour.StartCoroutine(SubmitToServer(wt, wf, uaing, uaend));
    }

    static IEnumerator SubmitToServer(WwwText wt, WWWForm wf, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        yield return new WaitForFixedUpdate();
        //注册回调事件
        WwwCallBack wle = new WwwCallBack();
        if (uaing != null)
            wle.AddIngEvent(uaing);
        if (uaend != null)
            wle.AddEndEvent(uaend);
        wt.LoadState = LoadState.LoadIng;

        //开始提交资源
        WWW www;

        if (wf == null)
            www = new WWW(wt.SourceUrl);
        else
            www = new WWW(wt.SourceUrl, wf);

        wt.LoadStartTime = DateTime.Now;

        bool chaoshi = false;
        while (!www.isDone)// || www.progress <= 1)
        {
            float o = www.progress;
            wt.Progress = www.progress;
            wle.ActiveIngEvent(false, o);

            DateTime temptime = DateTime.Now;
            TimeSpan ts = new TimeSpan(temptime.Ticks);
            TimeSpan ts1 = new TimeSpan(wt.LoadStartTime.Ticks);
            TimeSpan cha = ts.Subtract(ts1).Duration();
            if (cha.TotalSeconds > TimeOut)
            {
                chaoshi = true;
                break;
            }
            yield return null;
        }
        if (!chaoshi)
        {
            float o1 = www.progress;
            wt.Progress = www.progress;
            wle.ActiveIngEvent(true, o1);

            wt.LoadError = www.error;
            if (www.error != null)
            {
                wt.LoadState = LoadState.LoadFail;
                Debug.Log("UpLoad Error:" + www.error);
                //MessageBox.ShowInEditor(www.error);
            }
            else
            {
                wt.Size = www.size;

                wt.TextContent = www.text;

                wt.LoadState = LoadState.LoadComplete;

            }
        }
        else
        {
            //wt.Dispose();
            wt.LoadState = LoadState.LoadFail;
            wt.LoadError = "out time";
            //MessageBox.Show("超时");
        }

        wt.LoadEndTime = DateTime.Now;
        wle.ActiveEndEvent(true);
    }

    public static void Post(WwwText wt, WWWForm wf, UnityAction<float> uaend)
    {
        Post(wt, wf, null, uaend);
    }

    public static void Post(WwwText wt, WWWForm wf, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        if (wt.SourceUrl == null || wt.SourceUrl.Length < 1)
        {
            Debug.LogWarning("请确认网址正确");
            return;
        }
        MonoBehaviourAnysc.AnyscMonoBehaviour.StartCoroutine(UpLoad(wt, wf, uaing, uaend));
    }

    public static void Get(WwwText wt, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        if (wt.SourceUrl == null || wt.SourceUrl.Length < 1)
        {
            Debug.LogWarning("请确认网址正确");
            return;
        }
        MonoBehaviourAnysc.AnyscMonoBehaviour.StartCoroutine(UpLoad(wt, null, uaing, uaend));
    }

    public static void PostImage(WwwText wt, WWWForm wf, UnityAction<float> uaend)
    {
        MonoBehaviourAnysc.AnyscMonoBehaviour.StartCoroutine(UpLoadImage(wt, wf, null, uaend));
    }

    static IEnumerator UpLoadImage(WwwText wt, WWWForm wf, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        yield return new WaitForFixedUpdate();
        //注册回调事件
        WwwCallBack wle = new WwwCallBack();
        if (uaing != null)
            wle.AddIngEvent(uaing);
        if (uaend != null)
            wle.AddEndEvent(uaend);
        wt.LoadState = LoadState.LoadIng;

        Dictionary<string, string> headers = new Dictionary<string, string>();
        if (dictionary.ContainsKey("authorization"))
        {
            headers.Add("Cookie", ".AuthCookie=" + dictionary["authorization"]);
            headers.Add("Content-Disposition", "form-data");
            headers.Add("Content-Type", "image/png");

            WWW www = new WWW(wt.SourceUrl, wf.data, headers);
            yield return www;
            wt.LoadError = www.error;
            wt.LoadState = LoadState.LoadComplete;
            if (string.IsNullOrEmpty(wt.LoadError))
                wt.TextContent = www.text;
        }
        else
        {
            wt.LoadError = "nologin";
            wt.LoadState = LoadState.LoadComplete;
            wt.TextContent = "";
        }
        wt.LoadEndTime = DateTime.Now;
        wle.ActiveEndEvent(true);
    }

    /// <summary> 
    /// 上传图片文件 
    /// </summary> 
    /// <param name="url">提交的地址</param> 
    /// <param name="poststr">发送的文本串   比如：user=eking&pass=123456  </param> 
    /// <param name="fileformname">文本域的名称  比如：name="file"，那么fileformname=file  </param> 
    /// <param name="filepath">上传的文件路径  比如： c:\12.jpg </param> 
    /// <param name="cookie">cookie数据</param> 
    /// <param name="refre">头部的跳转地址</param> 
    /// <returns></returns> 
    public static string HttpUploadFile(string url, string poststr, string fileformname, string filepath, string cookie, string refre)
    {

        // 这个可以是改变的，也可以是下面这个固定的字符串 
        string boundary = "—————————7d930d1a850658";

        // 创建request对象 
        HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
        webrequest.ContentType = "multipart/form-data; boundary=" + boundary;
        webrequest.Method = "POST";
        webrequest.Headers.Add("Cookie: " + cookie);
        webrequest.Referer = refre;

        // 构造发送数据 
        StringBuilder sb = new StringBuilder();

        if (poststr != null)
        {
            // 文本域的数据，将user=eking&pass=123456  格式的文本域拆分 ，然后构造 
            foreach (string c in poststr.Split('&'))
            {
                string[] item = c.Split('=');
                if (item.Length != 2)
                {
                    break;
                }
                string name = item[0];
                string value = item[1];
                sb.Append("–" + boundary);
                sb.Append("\r\n");
                sb.Append("Content-Disposition: form-data; name=\"" + name + "\"");
                sb.Append("\r\n\r\n");
                sb.Append(value);
                sb.Append("\r\n");
            }
        }

        // 文件域的数据 
        sb.Append("–" + boundary);
        sb.Append("\r\n");
        sb.Append("Content-Disposition: form-data; name=\"icon\";filename=\"" + filepath + "\"");
        sb.Append("\r\n");

        sb.Append("Content-Type: ");
        sb.Append("imagepeg");
        sb.Append("\r\n\r\n");

        string postHeader = sb.ToString();
        byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);

        //构造尾部数据 
        byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n–" + boundary + "–\r\n");

        FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);

        long length = postHeaderBytes.Length + fileStream.Length + boundaryBytes.Length;
        webrequest.ContentLength = length;

        Stream requestStream = webrequest.GetRequestStream();

        // 输入头部数据 
        requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

        // 输入文件流数据 
        byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
        int bytesRead = 0;
        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            requestStream.Write(buffer, 0, bytesRead);

        // 输入尾部数据 
        requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
        WebResponse responce = webrequest.GetResponse();
        Stream s = responce.GetResponseStream();
        StreamReader sr = new StreamReader(s);

        // 返回数据流(源码) 
        return sr.ReadToEnd();
    }

    static IEnumerator UpLoad(WwwText wt, WWWForm wf, UnityAction<float> uaing, UnityAction<float> uaend)
    {
        yield return new WaitForFixedUpdate();
        //注册回调事件
        WwwCallBack wle = new WwwCallBack();
        if (uaing != null)
            wle.AddIngEvent(uaing);
        if (uaend != null)
            wle.AddEndEvent(uaend);
        wt.LoadState = LoadState.LoadIng;

        #region UnityWWW
        //开始提交资源
        // WWW www;

        // if (wf == null)
        //     www = new WWW(wt.SourceUrl, wf.SubmitForm);
        // else
        //     www = new WWW(wt.SourceUrl, wf.SubmitForm);

        // wt.LoadStartTime = DateTime.Now;

        // bool chaoshi = false;
        // while (!www.isDone)// || www.progress <= 1)
        // {
        //     float o = (float)www.progress;
        //     wt.Progress = www.progress;
        //     wle.ActiveIngEvent(false, o);

        //     DateTime temptime = DateTime.Now;
        //     TimeSpan ts = new TimeSpan(temptime.Ticks);
        //     TimeSpan ts1 = new TimeSpan(wt.LoadStartTime.Ticks);
        //     TimeSpan cha = ts.Subtract(ts1).Duration();
        //     if (cha.TotalSeconds > 5)
        //     {
        //         chaoshi = true;
        //         break;
        //     }
        //     yield return null;
        // }
        // if (!chaoshi)
        // {
        //     float o1 = (float)(www.progress);
        //     wt.Progress = www.progress;
        //     wle.ActiveIngEvent(true, o1);

        //     wt.LoadError = www.error;
        //     if (www.error != null)
        //     {
        //         wt.LoadState = LoadState.LoadFail;
        //         Debug.Log("UpLoad Error:" + www.error);
        //         MessageBox.ShowInEditor(www.error);
        //     }
        //     else
        //     {
        //         foreach (KeyValuePair<string, string> pair in www.responseHeaders)
        //         {
        //             Debug.Log("key:" + pair.Key + ":value:" + pair.Value);
        //         }
        //         Debug.Log("------------------------------------------------");
        //         string temp = www.responseHeaders["SET-COOKIE"];
        //         temp = temp.Substring(0, temp.IndexOf(';'));
        //         if (dictionary.ContainsKey("sAuthorization"))
        //         {
        //             dictionary["sAuthorization"] = temp;
        //         }
        //         else
        //         {
        //             dictionary.Add("sAuthorization", temp);
        //         }
        //         wt.Size = www.size;

        //         wt.TextContent = www.text;

        //         wt.LoadState = LoadState.LoadComplete;

        //     }
        //
        // yield return null;
        ////Debug.Log( GetHttpWebRequestMethod("",wt.SourceUrl,wf.SubmitForm.headers.));


        //     
        // }
        // else
        // {
        //     wt.Dispose();
        //     MessageBox.Show("超时");
        // }
        #endregion

        string request = "";
        if (wf == null)
            request = GetHttpWebRequestMethod("GET", wt.SourceUrl, "", dictionary.ContainsKey("authorization") == true ? dictionary["authorization"] : "");
        else
            request = GetHttpWebRequestMethod("POST", wt.SourceUrl, wf.data, dictionary.ContainsKey("authorization") == true ? dictionary["authorization"] : "");
        yield return request;
        if (request.Contains("Failed") || request.Contains("Error"))
            wt.LoadError = request;
        else
        {
            wt.TextContent = request;
            wt.LoadError = null;
        }
        wt.Progress = 1;
        wt.LoadState = LoadState.LoadComplete;
        wt.LoadEndTime = DateTime.Now;
        wle.ActiveEndEvent(true);
    }

    /// <summary>
    /// C# Http协议请求（GET、POST）方法
    /// </summary>
    /// <param name="method">请求的方法名称 例如：GET、POST</param>
    /// <param name="sUrl">请求的url地址 例如：http://api.zidiv.com:9004/user/info </param>
    /// <param name="sEntity">请求的实体字符串 例如：loginname=15255131592&loginpwd=123456}</param>
    /// <param name="sAuthorization">身份验证字符串 解释：身份验证字符串一般sdk开发包的http协议会自动封装好，如未封装好参照如下(Demo1.0代码)，获取身份验证字符串</param>
    /// <returns>执行完成后的结果字符串</returns>
    public static string GetHttpWebRequestMethod(string method, string sUrl, string sEntity, string sAuthorization)
    {
        byte[] bs = Encoding.UTF8.GetBytes(sEntity);
        return GetHttpWebRequestMethod(method, sUrl, bs, sAuthorization);
    }
    public static string GetHttpWebRequestMethod(string method, string sUrl, byte[] sEntity, string sAuthorization)
    {

        try
        {
            string sResult = "";

            WebResponse response = null;
            StreamReader reader = null;

            //string For = Convert.ToBase64String(Encoding.UTF8.GetBytes(sEntity));
            try
            {
                System.GC.Collect();
                System.Net.ServicePointManager.DefaultConnectionLimit = 50;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sUrl);
                request.Proxy = null;
                request.Method = method;
                //POST方法请求
                if (method == "POST")
                {
                    byte[] bs = sEntity;

                    request.ContentType = "text/xml";
                    request.ContentLength = bs.Length;
                    request.Headers.Add("Cookie", ".AuthCookie=" + sAuthorization);

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(bs, 0, bs.Length);
                    }
                    response = request.GetResponse();

                    #region Demo1.0代码
                    //身份验证字符串获取
                    if (string.IsNullOrEmpty(sAuthorization))
                    {
                        string temp = response.Headers["Set-Cookie"].Substring(response.Headers["Set-Cookie"].IndexOf(".AuthCookie=") + 12);
                        temp = temp.Substring(0, temp.IndexOf(';'));

                        if (dictionary.ContainsKey("authorization"))
                        {
                            dictionary["authorization"] = temp;
                        }
                        else
                        {
                            dictionary.Add("authorization", temp);
                        }
                    }
                    #endregion

                    reader = new StreamReader(stream: response.GetResponseStream(), encoding: Encoding.UTF8);
                    sResult = reader.ReadToEnd();
                    return sResult;
                }
                else //GET方法请求
                {
                    request.Headers["Cookie"] = ".AuthCookie=" + sAuthorization;
                    response = request.GetResponse();
                    reader = new StreamReader(stream: response.GetResponseStream(), encoding: Encoding.UTF8);
                    sResult = reader.ReadToEnd();
                    return sResult;
                }
            }
            catch (WebException ex)
            {
                //var rsp = ex.Response as HttpWebResponse;
                //var httpStatusCode = (int)rsp.StatusCode;
                //var authenticate = rsp.Headers.Get("WWW-Authenticate");

                return "Failed:" + ex.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (response != null)
                    response.Close();
            }

        }
        catch (Exception ex)
        {
            return "Failed:" + ex.Message;
        }

    }
}

/// <summary>
/// 异步加载固件
/// </summary>
public class MonoBehaviourAnysc
{
    private MonoBehaviourAnysc() { }

    static MonoBehaviour monoBehaviourAnysc = null;

    public static MonoBehaviour AnyscMonoBehaviour
    {
        get
        {
            if (monoBehaviourAnysc == null)
            {
                GameObject go = new GameObject("MonoBehaviourAnysc", typeof(MonoBehaviour));
                go.hideFlags = HideFlags.HideInHierarchy;
                monoBehaviourAnysc = go.GetComponent<MonoBehaviour>();
            }
            return monoBehaviourAnysc;
        }
    }
}