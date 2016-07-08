using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ElementsScrollView : ScrollView<ElementsItemInfo>
{
    [SerializeField]
    List<ElementsItemInfo> elementsContent = new List<ElementsItemInfo>();

    public List<ElementsItemInfo> ElementsContent
    {
        set
        {
            elementsContent = value;
        }
        get
        {
            return elementsContent;
        }
    }

    public override void Start()
    {
        base.Start();
        //CreateScrollView();
    }

    public void CreateScrollView()
    {
        base.InitScrollView(elementsContent);
    }
}