/*
 * 网络接口地址
 * */
using UnityEngine;
using System.Collections;

/// <summary>
/// 网络接口地址
/// </summary>
public class WebPath
{
    /*http://jinju3d.xicp.net:28941/forestry//sys/forestry/getForestryTime */
    static string defaultPath = "http://120.25.247.226";
    /// <summary>
    /// 默认地址
    /// </summary>
    public static string DefaultPath
    {
        set
        {
            defaultPath = value;
        }
        get
        {
            return defaultPath;
        }
    }

    #region 地址接口
    /// <summary>
    /// 省信息地址
    /// </summary>
    public static string ProvincePath
    {
        get
        {
            return defaultPath + "/Area/List";
        }
    }

    /// <summary>
    /// 市信息地址
    /// </summary>
    public static string CityPath
    {
        get
        {
            return defaultPath + "/Area/List";
        }
    }

    /// <summary>
    /// 县信息地址
    /// </summary>
    public static string CountyPath
    {
        get
        {
            return defaultPath + "/Area/List";
        }
    }
    #endregion

    /// <summary>
    /// 工程时间地址
    /// </summary>
    public static string GetProjectCompassTime
    {
        get
        {
            return defaultPath + "/forestry/sys/forestry/getForestryTime";
        }
    }

    /// <summary>
    /// 工程概况数据地址
    /// </summary>
    public static string GetProjectOverView
    {
        get
        {
            return defaultPath + "/forestry/sys/forestry/getForestryList";
        }
    }

    /// <summary>
    /// 顶进信息数据
    /// </summary>
    public static string GetDingjinInfo
    {
        get
        {
            return defaultPath + "/forestry/sys/forestrytype/getForestryTypeApi";
        }
    }

    /// <summary>
    /// 课程信息
    /// </summary>
    public static string GetCourseInformation
    {
        get
        {
            return defaultPath + "/forestrytwo/sys/forestrytype/getForestryTypeOneName";
        }
    }

    /// <summary>
    /// 1：实训概述；2：实训准备；3：实训回顾
    /// </summary>
    public static string GetCourseDescription
    {
        get
        {
            return defaultPath + "/forestrytwo/sys/attachment/getSpreadAttachment";
        }
    }

    /// <summary>
    /// 互动操作工序列表地址
    /// </summary>
    public static string GetProjectOperation
    {
        get
        {
            return defaultPath + "/forestrytwo/sys/forestry/getSpreadForestry";
        }
    }

    public static string GetWareHouseToolTypeDepotListName
    {
        get
        {
            return defaultPath + "/forestrytwo/sys/forestrytype/getForestryTypeDepotListName";
        }
    }

    public static string GetToolContentList
    {
        get
        {
            return defaultPath + "/forestrytwo/sys/forestrytype/getForestryTypeContentList";
        }
    }

    public static string GetToolsPath
    {
        get
        {
            return defaultPath + "/forestrytwo/sys/forestry/getForestryTypeContentOne";
        }
    }

}

public class ResourcesPath
{

    public class ResourcesType
    {
        private ResourcesType() { }

        public const string Scene = ".scene";
        public const string GameObject = ".unity3d";
        public const string Texture = ".png";
        public const string Movie = ".ogg";
        public const string Audio = ".ogg";
        public const string Text = ".txt";
    }

    /// <summary>
    /// 默认地址
    /// </summary>
#if UNITY_EDITOR
    static string defaultPath = "file:///G:/2016Project/Jurun/HuangProject/jurunProject_Huang/Builds";
#elif !UNITY_EDITOR
     static string defaultPath = Application.dataPath;
#endif
    /// <summary>
    /// 资源包地址
    /// </summary>
    public static string GetAssetBundlePath(string name)
    {
        return defaultPath + "/AssetBundles/" + name + ResourcesType.GameObject;
    }

    /// <summary>
    /// 场景包地址
    /// </summary>
    public static string GetScenePath(string name)
    {
        return defaultPath + "/AssetBundles/Scenes/" + name + ResourcesType.Scene;
    }

    /// <summary>
    /// 文本包地址
    /// </summary>
    public static string GetTextPath(string name)
    {
        return defaultPath + "/AssetBundles/Texts/" + name + ResourcesType.Text;
    }

    /// <summary>
    /// 图片包地址
    /// </summary>
    public static string GetTexturePath(string name)
    {
        return defaultPath + "/AssetBundles/Textures/" + name + ResourcesType.Texture;
    }

    /// <summary>
    /// 模型包地址
    /// </summary>
    public static string GetGameObjectPath(string name)
    {
        return defaultPath + "/AssetBundles/GameObjects/" + name + ResourcesType.GameObject;
    }

    /// <summary>
    /// 音频包地址
    /// </summary>
    public static string GetAudioPath(string name)
    {
        return defaultPath + "/AssetBundles/Audios/" + name + ResourcesType.Audio;
    }

    /// <summary>
    /// 视频包地址
    /// </summary>
    public static string GetMoviePath(string name)
    {
        return defaultPath + "/AssetBundles/Movies/" + name + ResourcesType.Movie;
    }
}