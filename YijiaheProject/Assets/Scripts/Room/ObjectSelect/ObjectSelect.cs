using UnityEngine;
using System.Collections;

public class ObjectSelect : MonoBehaviour
{
    static ObjectSelect instance;

    [SerializeField]
    EObject selectObject;
    /// <summary>
    /// 选中的物体
    /// </summary>
    public EObject SelectObject
    {
        set
        {
            selectObject = value;
        }
        get
        {
            return selectObject;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
