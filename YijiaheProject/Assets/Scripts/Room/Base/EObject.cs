using UnityEngine;
using System.Collections;

/// <summary>
/// 所有物体的单位
/// </summary>
public class EObject
{
    [SerializeField]
    Transform transform;
    public Transform ETransform
    {
        set
        {
            transform = value;
        }
        get
        {
            return transform;
        }
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