using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
/// <summary>
/// 所有物体的单位
/// </summary>
public class EObject
{
    string name = "";
    /// <summary>
    /// 物体名称
    /// </summary>
    public string Name
    {
        set
        {
            name = value;
            ActiveEvent();
        }
        get
        {
            return name;
        }
    }

    string id = "";
    /// <summary>
    /// 物体ID
    /// </summary>
    public string ID
    {
        set
        {
            id = value;
            ActiveEvent();
        }
        get
        {
            return id;
        }
    }

    [SerializeField] 
    Transform transform;
    /// <summary>
    /// 物体的transform
    /// </summary>
    public Transform ETransform
    {
        set
        {
            transform = value;
            ActiveEvent();
        }
        get
        {
            return transform;
        }
    }

    /// <summary>
    /// 物体本地位置
    /// </summary>
    public Vector3 Position
    {
        set
        {
            ETransform.position = value;
            ActiveEvent();
        }
        get
        {
            return ETransform.position;
        }
    }

    /// <summary>
    /// 物体本地位置
    /// </summary>
    public Vector3 LocalPosition
    {
        set
        {
            ETransform.localPosition = value;
            ActiveEvent();
        }
        get
        {
            return ETransform.localPosition;
        }
    }

    /// <summary>
    /// 物体欧拉角度
    /// </summary>
    public Vector3 EulerAngles
    {
        set
        {
            ETransform.eulerAngles = value;
            ActiveEvent();
        }
        get
        {
            return ETransform.eulerAngles;
        }
    }

    /// <summary>
    /// 物体父物体
    /// </summary>
    public Transform Parent
    {
        set
        {
            ETransform.SetParent(value);
            ActiveEvent();
        }
        get
        {
            return ETransform.parent;
        }
    }

    /// <summary>
    /// 物体大小
    /// </summary>
    public Vector3 LocalScale
    {
        set
        {
            ETransform.localScale = value;
            ActiveEvent();
        }
        get
        {
            return ETransform.localScale;
        }
    }

    [SerializeField]
    MeshFilter meshFilter;
    /// <summary>
    /// 物体的网格组件
    /// </summary>
    public MeshFilter EMeshFilter
    {
        set
        {
            meshFilter = value;
            ActiveEvent();
        }
        get
        {
            return meshFilter;
        }
    }

    [SerializeField]
    MeshRenderer meshRenderer;
    /// <summary>
    /// 物体的网格渲染组件
    /// </summary>
    public MeshRenderer EMeshRenderer
    {
        set
        {
            meshRenderer = value;
            ActiveEvent();
        }
        get
        {
            return meshRenderer;
        }
    }

    [SerializeField]
    Color color;
    /// <summary>
    /// 物体颜色
    /// </summary>
    public Color EColor
    {
        set
        {
            color = value;
            ActiveEvent();
        }
        get
        {
            return color;
        }
    }

    public UnityEvent OnObjectInfoChanged = new UnityEvent();
    void ActiveEvent()
    {
        OnObjectInfoChanged.Invoke();
    }

    public virtual void OnSelect()
    {

    }



    //[SerializeField]
    //float length = 0;
    ///// <summary>
    ///// 长
    ///// </summary>
    //public float Length
    //{
    //    set
    //    {
    //        length = value;
    //    }
    //    get
    //    {
    //        return length;
    //    }
    //}

    //[SerializeField]
    //float width = 0;
    ///// <summary>
    ///// 宽
    ///// </summary>
    //public float Width
    //{
    //    set
    //    {
    //        width = value;
    //    }
    //    get
    //    {
    //        return width;
    //    }
    //}

    //[SerializeField]
    //float height = 0;
    ///// <summary>
    ///// 高
    ///// </summary>
    //public float Height
    //{
    //    set
    //    {
    //        height = value;
    //    }
    //    get
    //    {
    //        return height;
    //    }
    //}
}