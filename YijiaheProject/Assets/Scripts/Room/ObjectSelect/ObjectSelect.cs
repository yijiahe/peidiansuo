using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ObjectSelect : MonoBehaviour
{
    static ObjectSelect instance;
    public static ObjectSelect Instance
    {
        internal set
        {
            instance = value;
        }
        get
        {
            if (instance == null)
                new GameObject("ObjectSelect", typeof(ObjectSelect));
            return instance;
        }
    }

    [SerializeField]
    SelectObject selectObject = new SelectObject();
    /// <summary>
    /// 当前选择实例
    /// </summary>
    public static SelectObject CurrentSelectObject
    {
        internal set
        {
            instance.selectObject = value;
        }
        get
        {
            return instance.selectObject;
        }
    }

    [SerializeField]
    List<SelectObject> selectObjectList = new List<SelectObject>();

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        selectObject.SelectedEvent.AddListener(OnSelected);
    }

    private void OnSelected(SelectType arg0, EBehaviour arg1)
    {
        Debug.Log(arg0 + ":" + arg1 != null ? arg1.name : "Null");
    }

    // Update is called once per frame
    void Update()
    {
        selectObject.SetRay();
        selectObject.UpdateSelect();
    }

    /// <summary>
    /// 添加选择物体实例
    /// </summary>
    /// <param name="item"></param>
    public static void AddSelectObjectToList(SelectObject item)
    {
        instance.selectObjectList.Add(item);
    }
}

[System.Serializable]
public class SelectObject
{
    [SerializeField]
    LayerMask layerFilter = new LayerMask();
    /// <summary>
    /// 射线过滤
    /// </summary>
    public LayerMask LayerFilter
    {
        set
        {
            layerFilter = value;
        }
        get
        {
            return layerFilter;
        }
    }

    [SerializeField]
    EBehaviour selectedObject;
    /// <summary>
    /// 选中的物体
    /// </summary>
    public EBehaviour SelectedObject
    {
        set
        {
            selectedObject = value;
        }
        get
        {
            return selectedObject;
        }
    }

    bool activeEvent = false;

    /// <summary>
    /// 选择物体后的事件
    /// </summary>
    public SelectedEvent SelectedEvent = new SelectedEvent();

    Ray ray = new Ray();
    RaycastHit raycastHit = new RaycastHit();
    float maxDistance = 1000;

    /// <summary>
    /// 检测射线选择物体
    /// </summary>
    /// <param name="target"></param>
    public void SetRay(Vector3 target)
    {
        ray = new Ray(Camera.main.transform.position, (target - Camera.main.transform.position).normalized);
    }

    /// <summary>
    /// 检测射线选择物体
    /// </summary>
    /// <param name="target"></param>
    public void SetRay()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    /// <summary>
    /// 检测射线选择物体
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="direction"></param>
    public void UpdateSelect()
    {
#if UNITY_EDITOR
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
#endif
        if (Physics.Raycast(ray, out raycastHit, maxDistance, layerFilter))
        {
            if (selectedObject == null)
                selectedObject = raycastHit.transform.GetComponent<EBehaviour>();
            else
            {
                if (selectedObject == raycastHit.transform.GetComponent<EBehaviour>())
                {
                    ActiveSelectedEvent(SelectType.Over, selectedObject);
                }
                else
                {
                    ActiveSelectedEvent(SelectType.Exit, selectedObject);
                    selectedObject = raycastHit.transform.GetComponent<EBehaviour>();
                    ActiveSelectedEvent(SelectType.Enter, selectedObject);
                }
            }
            if (!activeEvent)
            {
                activeEvent = true;
                ActiveSelectedEvent(SelectType.Enter, selectedObject);
            }
        }
        else
        {
            if (activeEvent)
            {
                activeEvent = false;
                ActiveSelectedEvent(SelectType.Exit, selectedObject);
                selectedObject = null;
            }
        }
    }

    void ActiveSelectedEvent(SelectType selecttype, EBehaviour eobject)
    {
        SelectedEvent.Invoke(selecttype, eobject);
    }
}

/// <summary>
/// 模型选择事件
/// </summary>
[System.Serializable]
public class SelectedEvent : UnityEvent<SelectType, EBehaviour> { }

public enum SelectType
{
    Enter,
    Over,
    Exit
}