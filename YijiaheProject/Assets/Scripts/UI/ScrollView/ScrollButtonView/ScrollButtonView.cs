using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ScrollButtonView : ScrollView<ScrollButtonItemInfo>
{
    [SerializeField]
    List<ScrollButtonItemInfo> scrollButtonContent = new List<ScrollButtonItemInfo>();

    public override void Start()
    {
        base.Start();
        //CreateScrollView();
    }

    public void CreateScrollView()
    {
        base.InitScrollView(scrollButtonContent);
    }
}