using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ClasssifyScrollView : ScrollView<ClassifyInfo>
{
    [SerializeField]
    List<ClassifyInfo> classifyContent = new List<ClassifyInfo>();
    public List<ClassifyInfo> CassifyContent
    {
        set
        {
            classifyContent = value;
        }
        get
        {
            return classifyContent;
        }
    }

    [SerializeField]
    ToggleGroup toggleGroup;

    public override void Start()
    {
        base.Start();
        //CreateScrollView();
    }

    public void CreateScrollView()
    {
        base.InitScrollView(classifyContent);
    }
}