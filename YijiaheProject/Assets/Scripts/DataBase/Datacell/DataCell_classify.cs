using UnityEngine;
using System.Collections;

/// <summary>
/// 分类的管理
/// </summary>
public class DataCell_classify :DataCell
{
    private int classify_id;

    public int Classify_id
    {
        get { return classify_id; }
        set { classify_id = value; }
    }

    private string classify_name;
    /// <summary>
    /// 分类名称
    /// </summary>
    public string Classify_name
    {
        get { return classify_name; }
        set { classify_name = value; }
    }

    private int classify_numpos;

    /// <summary>
    /// 同级中的位置编号
    /// </summary>
    public int Classify_numpos
    {
        get { return classify_numpos; }
        set { classify_numpos = value; }
    }


    private int classify_parentID;
    /// <summary>
    ///分类ID
    /// </summary>
    public int Classify_parentID
    {
        get { return classify_parentID; }
        set { classify_parentID = value; }
    }

    public  DataCell_classify()
    {
        Classify_id = 0;
        Classify_parentID = 0;
        Classify_numpos = 0;
    }
}
