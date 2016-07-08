using UnityEngine;
using System.Collections;

/// <summary>
/// 元件
/// </summary>
public class DataCell_model : DataCell
{

    private int model_id;
    /// <summary>
    /// 模型元件ID
    /// </summary>
    public int Model_id
    {
        get { return model_id; }
        set { model_id = value; }
    }

    private string model_num;
    /// <summary>
    /// 模型元件编号
    /// </summary>
    public string Model_num
    {
        get { return model_num; }
        set { model_num = value; }
    }

    private string model_name;
    /// <summary>
    /// 模型元件名称
    /// </summary>
    public string Model_name
    {
        get { return model_name; }
        set { model_name = value; }
    }

    private string model_address;
    /// <summary>
    /// 模型文件地址
    /// </summary>
    public string Model_address
    {
        get { return model_address; }
        set { model_address = value; }
    }

    private string modle_ThumbnailAddress;
    /// <summary>
    /// 缩略图地址
    /// </summary>
    public string Modle_ThumbnailAddress
    {
        get { return modle_ThumbnailAddress; }
        set { modle_ThumbnailAddress = value; }
    }

    private string model_Introduction;
    /// <summary>
    /// 模型文件文字描述
    /// </summary>
    public string Model_Introduction
    {
        get { return model_Introduction; }
        set { model_Introduction = value; }
    }

    private string model_classify_name;

    /// <summary>
    /// 模型文件属于哪个分类
    /// </summary>
    public string Model_classify_name
    {
        get { return model_classify_name; }
        set { model_classify_name = value; }
    }


    private string model_type;

    public string Model_type
    {
        get { return model_type; }
        set { model_type = value; }
    }

   

    public DataCell_model()
    {
        Model_num = "";
        Model_name = "";
        model_address = "";
        modle_ThumbnailAddress = "";
        model_Introduction = "";
        model_classify_name = "";
        model_type = "";
    }
}
