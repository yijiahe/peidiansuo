using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ScrollToggleView : ScrollView<ScrollToggleItemInfo>
{
    [SerializeField]
    List<ScrollToggleItemInfo> scrollToggleContent = new List<ScrollToggleItemInfo>();
    public List<ScrollToggleItemInfo> ScrollToggleContent
    {
        set
        {
            scrollToggleContent = value;
        }
        get
        {
            return scrollToggleContent;
        }
    }

    [SerializeField]
    ToggleGroup toggleGroup;

    public override void Start()
    {
        base.Start();
        CreateScrollView();
    }

    public void CreateScrollView()
    {
        base.InitScrollView(scrollToggleContent);
    }
}