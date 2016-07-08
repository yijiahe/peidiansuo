using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollButtonItem : ScrollItem<ScrollButtonItemInfo>
{
    [SerializeField]
    Button button;

    [SerializeField]
    Text text_Title;

    [SerializeField]
    ScrollButtonItemInfo scrollButtonItemInfo = new ScrollButtonItemInfo();

    public override void SetItemInfo(ScrollButtonItemInfo scrolliteminfo, UnityEngine.Events.UnityAction<int> ua)
    {
        base.SetItemInfo(scrolliteminfo, ua);
        scrollButtonItemInfo = scrolliteminfo;
        button.onClick.AddListener(OnClick);

        InitItem();
    }

    public override void SetState(bool state)
    {
        //if(state)
    }

    void InitItem()
    {
        text_Title.text = scrollButtonItemInfo.Name;
    }

    public void OnClick()
    {
        ActiveEvent(scrollButtonItemInfo.Index);
    }
}

[System.Serializable]
public class ScrollButtonItemInfo : ScrollItemInfo
{

}