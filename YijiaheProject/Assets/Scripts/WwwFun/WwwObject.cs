/*
 * 网络加载基本元件
 */
using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// 网络加载对象
/// </summary>
[System.Serializable]
public class WwwObject
{
    [SerializeField]
    string name = "";
    /// <summary>
    /// 文件名称
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
    bool local = false;
    /// <summary>
    /// 是否为本地资源true是false否
    /// </summary>
    public bool LocalData
    {
        set
        {
            local = value;
        }
        get
        {
            return local;
        }
    }

    [SerializeField]
    string sourceUrl = "";
    /// <summary>
    /// 加载地址
    /// </summary>
    public string SourceUrl
    {
        set
        {
            sourceUrl = value.Replace('\\', '/');
            if (string.IsNullOrEmpty(name))
            {
                string[] str = sourceUrl.Split('/');
                if (str.Length > 0)
                {
                    string[] ss = str[str.Length - 1].Split('.');
                    if (ss.Length > 0)
                        name = str[str.Length - 1].Split('.')[0];
                }
            }
        }
        get
        {
            return sourceUrl;
        }
    }

    [SerializeField]
    LoadState loadState = LoadState.LoadReady;
    /// <summary>
    /// 加载状态
    /// </summary>
    public LoadState LoadState
    {
        set
        {
            loadState = value;
        }
        get
        {
            return loadState;
        }
    }

    [SerializeField]
    float progress = 0;
    /// <summary>
    /// 加载进度
    /// </summary>
    public float Progress
    {
        set
        {
            progress = value;
        }
        get
        {
            return progress;
        }
    }

    [SerializeField]
    int size = 0;
    /// <summary>
    /// 文件大小
    /// </summary>
    public virtual int Size
    {
        set
        {
            size = value;
        }
        get
        {
            return size;
        }
    }

    [SerializeField]
    DateTime loadStartTime = new DateTime();
    /// <summary>
    /// 加载开始时间
    /// </summary>
    public DateTime LoadStartTime
    {
        set
        {
            loadStartTime = value;
        }
        get
        {
            return loadStartTime;
        }
    }

    [SerializeField]
    DateTime loadEndTime = new DateTime();
    /// <summary>
    /// 加载结束时间
    /// </summary>
    public DateTime LoadEndTime
    {
        set
        {
            loadEndTime = value;
        }
        get
        {
            return loadEndTime;
        }
    }

    [SerializeField]
    string loadError = string.Empty;
    /// <summary>
    /// 加载错误信息
    /// </summary>
    public string LoadError
    {
        set
        {
            loadError = value;
        }
        get
        {
            return loadError;
        }
    }

    /// <summary>
    /// 是否错误信息True无错误
    /// </summary>
    public bool NoneError
    {
        //set
        //{
        //    isError = value;
        //}
        get
        {
            return string.IsNullOrEmpty(loadError);
        }
    }

    /// <summary>
    /// 销毁资源占用
    /// </summary>
    public virtual void Dispose()
    {
        size = 0;
        //loadStartTime = new DateTime();
        //loadEndTime = new DateTime();
        loadState = LoadState.LoadReady;
        loadError = "";
    }

}

/// <summary>
/// 网络文本
/// </summary>
[System.Serializable]
public class WwwText : WwwObject
{
    [SerializeField]
    string textContent = "";
    [SerializeField]
    byte[] data = new byte[0];

    /// <summary>
    /// 文本内容
    /// </summary>
    public string TextContent
    {
        set
        {
            textContent = value;
        }
        get
        {
            return textContent;
        }
    }

    /// <summary>
    /// 数据内容
    /// </summary>
    public byte[] Data
    {
        set
        {
            data = value;
        }
        get
        {
            return data;
        }
    }

    public override void Dispose()
    {
        base.Dispose();
        textContent = "";
    }
}

[System.Serializable]
public class WwwImage : WwwObject
{
    [SerializeField]
    Texture2D imageContent = null;
    /// <summary>
    /// 图片内容
    /// </summary>
    public Texture2D ImageContent
    {
        set
        {
            imageContent = value;
        }
        get
        {
            return imageContent;
        }
    }

    public override void Dispose()
    {
        base.Dispose();
        imageContent = null;
    }
}


[System.Serializable]
public class WwwBundle : WwwObject
{
    [SerializeField]
    AssetBundle assetBundle = null;
    /// <summary>
    /// 资源包
    /// </summary>
    public AssetBundle Bundle
    {
        set
        {
            assetBundle = value;
            if (assetBundle != null)
                gameObject = assetBundle.mainAsset as GameObject;
            //			if(gameObject!=null)
            //			assetBundle.Unload(false);
        }
        get
        {
            return assetBundle;
        }
    }

    [SerializeField]
    GameObject gameObject = null;

    /// <summary>
    /// 模型内容
    /// </summary>
    public GameObject BundleContent
    {
        set
        {
            gameObject = value;
        }
        get
        {
            return gameObject;
        }
    }

    public override void Dispose()
    {
        base.Dispose();
        gameObject = null;
        assetBundle.Unload(true);
    }
}


[System.Serializable]
public class WwwAudio : WwwObject
{
    [SerializeField]
    AudioClip audioContent = null;

    /// <summary>
    /// 音频内容
    /// </summary>
    public AudioClip AudioContent
    {
        set
        {
            audioContent = value;
            if (audioContent != null)
                audioTime = audioContent.length;
        }
        get
        {
            return audioContent;
        }
    }

    [SerializeField]
    float audioTime = 0;
    /// <summary>
    /// 音频时间
    /// </summary>
    public float AudioTime
    {
        //set
        //{
        //    audioTime = value;
        //}
        get
        {
            return audioTime;
        }
    }

    [SerializeField]
    bool three3D = false;
    /// <summary>
    /// 3D 音频
    /// </summary>
    public bool Three3D
    {
        set
        {
            three3D = value;
        }
        get
        {
            return three3D;
        }
    }

    [SerializeField]
    bool stream = false;
    /// <summary>
    /// 流下载
    /// </summary>
    public bool Stream
    {
        set
        {
            stream = value;
        }
        get
        {
            return stream;
        }
    }

    public override void Dispose()
    {
        base.Dispose();
        audioContent = null;
    }
}


[System.Serializable]
public class WwwMovie : WwwObject
{
#if !UNITY_ANDROID
    [SerializeField]
    MovieTexture movieContent = null;

    [SerializeField]
    AudioClip movieAudio = null;

    /// <summary>
    /// 视频内容
    /// </summary>
    public MovieTexture MovieContent
    {
        set
        {
            movieContent = value;
            if (movieContent != null)
            {
                movieAudio = movieContent.audioClip;
                movieTime = movieContent.duration;
            }
        }
        get
        {
            return movieContent;
        }
    }

    /// <summary>
    /// 视频中音频
    /// </summary>
    public AudioClip MovieAudio
    {
        get
        {
            return movieAudio;
        }
    }

    [SerializeField]
    float movieTime = 0;
    /// <summary>
    /// 影片时长
    /// </summary>
    public float MovieTime
    {
        //set
        //{
        //    movieTime = value;
        //}
        get
        {
            return movieTime;
        }
    }

//#elif UNITY_ANDROID

//    [SerializeField]
//    string movieUrl = "";
//    public string MovieUrl
//    {
//        set
//        {
//            movieUrl = value;
//        }
//        get
//        {
//            return movieUrl;
//        }
//    }
#endif

    public override void Dispose()
    {
        base.Dispose();
        movieAudio = null;
        movieContent = null;
    }
}

public enum LoadState : int
{
    LoadReady = 0,
    LoadIng = 1,
    LoadComplete = 2,
    LoadFail = -1
}