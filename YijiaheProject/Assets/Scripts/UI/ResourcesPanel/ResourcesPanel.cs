using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ResourcesPanel : Page
{
    [SerializeField]
    ClassifyEditorPanel classifyEditorPanel;
    [SerializeField]
    ElementsEditorPanel elementsEditorPanel;

    [Space(5)]
    //[SerializeField]
    //List<ScrollToggleItemInfo> ClassifyOneList = new List<ScrollToggleItemInfo>();
    [SerializeField]
    ClasssifyScrollView classifyOnePanel;
    [SerializeField]
    Button button_AddClassifyOne;

    [Space(5)]
    //[SerializeField]
    //List<ScrollToggleItemInfo> ClassifyTwoList = new List<ScrollToggleItemInfo>();
    [SerializeField]
    ClasssifyScrollView classifyTwoPanel;
    [SerializeField]
    Button button_AddClassifyTwo;

    [Space(5)]
    [SerializeField]
    ElementsScrollView elementsScrollView;
    [SerializeField]
    Button button_AddElement;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        //绑定一级菜单事件
        classifyOnePanel.OnScrollValueChanged.AddListener(OnClassifyOneValueChanges);
        //绑定一级菜单事件
        classifyTwoPanel.OnScrollValueChanged.AddListener(OnClassifyTwoValueChanges);
        //绑定元件出发事件
        elementsScrollView.OnScrollValueChanged.AddListener(OnElementValueCahnged);
        //绑定添加一级分类按钮
        button_AddClassifyOne.onClick.AddListener(OnClassifyOneClick);
        //绑定添加二级分类按钮
        button_AddClassifyTwo.onClick.AddListener(OnClassifyTwoClick);

        UpdateClassifyOnePanel();
    }

    /// <summary>
    /// 添加一级分类
    /// </summary>
    private void OnClassifyOneClick()
    {
        classifyEditorPanel.SetParentID("0");
    }

    /// <summary>
    /// 添加二级分类
    /// </summary>
    private void OnClassifyTwoClick()
    {
        if (classifyOnePanel.Value < 0)
            return;
        classifyEditorPanel.SetParentID(classifyOnePanel.CassifyContent[classifyOnePanel.Value].ParentID);
    }

    public override void Display(bool state)
    {
        base.Display(state);

    }

    /// <summary>
    /// 一级菜单触发
    /// </summary>
    /// <param name="arg0"></param>
    private void OnClassifyOneValueChanges(int arg0)
    {
        if (arg0 < 0)
            return;
        UpdateClassifyTwoPanel(classifyOnePanel.CassifyContent[arg0].ID);
    }

    /// <summary>
    /// 更新一级菜单内容
    /// </summary>
    void UpdateClassifyOnePanel()
    {
        classifyOnePanel.CassifyContent.Clear();
        List<DataCell_classify> classifyOneList = SQLDataInterface.SelectClassifyListInfo(0);
        for (int i = 0; i < classifyOneList.Count; i++)
        {
            ClassifyInfo ci = new ClassifyInfo();
            ci.Index = i;// classifyOneList[i].Classify_numpos;
            ci.ID = classifyOneList[i].Classify_id.ToString();
            ci.Name = classifyOneList[i].Classify_name;
            ci.ParentID = classifyOneList[i].Classify_parentID.ToString();
            classifyOnePanel.CassifyContent.Add(ci);
        }
        classifyOnePanel.CreateScrollView();
    }

    /// <summary>
    /// 二级菜单触发
    /// </summary>
    /// <param name="arg0"></param>
    private void OnClassifyTwoValueChanges(int arg0)
    {
        if (arg0 < 0)
            return;
        UpdateElementsPanel(classifyTwoPanel.CassifyContent[arg0].Name);
    }

    /// <summary>
    /// 更新二级菜单内容
    /// </summary>
    void UpdateClassifyTwoPanel(string parentid)
    {
        classifyTwoPanel.CassifyContent.Clear();
        List<DataCell_classify> classifyOneList = SQLDataInterface.SelectClassifyListInfo(int.Parse(parentid));
        for (int i = 0; i < classifyOneList.Count; i++)
        {
            ClassifyInfo ci = new ClassifyInfo();
            ci.Index = i;// classifyOneList[i].Classify_numpos;
            ci.ID = classifyOneList[i].Classify_id.ToString();
            ci.Name = classifyOneList[i].Classify_name;
            ci.ParentID = classifyOneList[i].Classify_parentID.ToString();
            classifyTwoPanel.CassifyContent.Add(ci);
        }
        classifyTwoPanel.CreateScrollView();
    }

    /// <summary>
    /// 元件面板触发
    /// </summary>
    /// <param name="arg0"></param>
    private void OnElementValueCahnged(int arg0)
    {
        if (arg0 < 0 || classifyTwoPanel.Value < 0)
            return;
        elementsEditorPanel.AddElement(classifyTwoPanel.CassifyContent[classifyTwoPanel.Value].Name);
    }

    /// <summary>
    /// 更新元件面板
    /// </summary>
    /// <param name="classifyname"></param>
    void UpdateElementsPanel(string classifyname)
    {
        elementsScrollView.ElementsContent.Clear();
        List<DataCell_model> elements = SQLDataInterface.SelectModelListInfo(classifyname);
        for (int i = 0; i < elements.Count; i++)
        {
            ElementsItemInfo ei = new ElementsItemInfo();
            ei.Index = i;// elements[i].Classify_numpos;
            ei.ID = elements[i].Model_id.ToString();
            ei.Name = elements[i].Model_name;
            //ei.Image = elements[i].Modle_ThumbnailAddress;
            elementsScrollView.ElementsContent.Add(ei);
        }
        elementsScrollView.CreateScrollView();
    }

}
