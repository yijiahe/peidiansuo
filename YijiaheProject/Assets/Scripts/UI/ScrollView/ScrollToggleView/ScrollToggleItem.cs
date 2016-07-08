using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollToggleItem : ScrollItem<ScrollToggleItemInfo>
{
    [SerializeField]
    Toggle toggle;
    [SerializeField]
    Text text_Title;
    [SerializeField]
    ScrollToggleItemInfo scrollToggleItemInfo = new ScrollToggleItemInfo();

    public override void SetItemInfo(ScrollToggleItemInfo scrolliteminfo, UnityEngine.Events.UnityAction<int> ua)
    {
        base.SetItemInfo(scrolliteminfo, ua);

        scrollToggleItemInfo = scrolliteminfo;
        toggle.onValueChanged.AddListener(OnValueChange);

        InitItem();
    }

    public override void SetState(bool state)
    {
        toggle.isOn = state;
    }

    void InitItem()
    {
        if (scrollToggleItemInfo.Index == 0)
            toggle.isOn = true;
        else
            toggle.isOn = false;

        text_Title.text = scrollToggleItemInfo.Name;
    }

    public void OnValueChange(bool arg0)
    {
        if (arg0)
            ActiveEvent(scrollToggleItemInfo.Index);
    }
}

[System.Serializable]
public class ScrollToggleItemInfo : ScrollItemInfo
{

}