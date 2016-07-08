using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClassifyItem : ScrollItem<ClassifyInfo>
{
    [SerializeField]
    Toggle toggle;
    [SerializeField]
    Text text_Title;
    [SerializeField]
    ClassifyInfo classifyInfo = new ClassifyInfo();

    public override void SetItemInfo(ClassifyInfo classifyinfo, UnityEngine.Events.UnityAction<int> ua)
    {
        base.SetItemInfo(classifyinfo, ua);

        classifyInfo = classifyinfo;
        toggle.onValueChanged.AddListener(OnValueChange);

        InitItem();
    }

    public override void SetState(bool state)
    {
        toggle.isOn = state;
    }

    void InitItem()
    {
        if (classifyInfo.Index == 0)
            toggle.isOn = true;
        else
            toggle.isOn = false;

        text_Title.text = classifyInfo.Name;
    }

    public void OnValueChange(bool arg0)
    {
        if (arg0)
            ActiveEvent(classifyInfo.Index);
    }
}

[System.Serializable]
public class ClassifyInfo : ScrollItemInfo
{
    string parentid = "";
    /// <summary>
    /// 父级分类ID
    /// </summary>
    public string ParentID
    {
        set
        {
            parentid = value;
        }
        get
        {
            return parentid;
        }
    }
}