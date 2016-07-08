using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ElementsItem : ScrollItem<ElementsItemInfo>
{
    [SerializeField]
    Button button;

    [SerializeField]
    Text text_Title;

    [SerializeField]
    ElementsItemInfo elementsItemInfo = new ElementsItemInfo();

    public override void SetItemInfo(ElementsItemInfo elementsiteminfo, UnityEngine.Events.UnityAction<int> ua)
    {
        base.SetItemInfo(elementsiteminfo, ua);
        elementsItemInfo = elementsiteminfo;
        button.onClick.AddListener(OnClick);

        InitItem();
    }

    public override void SetState(bool state)
    {
        //if(state)
    }

    void InitItem()
    {
        text_Title.text = elementsItemInfo.Name;
    }

    public void OnClick()
    {
        ActiveEvent(elementsItemInfo.Index);
    }
}

[System.Serializable]
public class ElementsItemInfo : ScrollItemInfo
{
    Texture2D image;
    /// <summary>
    /// 元件名称
    /// </summary>
    public Texture2D Image
    {
        set
        {
            image = value;
        }
        get
        {
            return image;
        }
    }
}