using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClassifyEditorPanel : Page
{
    [SerializeField]
    InputField classifyName;
    [SerializeField]
    Button button_Add;
    [SerializeField]
    Button button_Cancel;

    [SerializeField]
    string parentID;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        button_Add.onClick.AddListener(OnAddClick);
        button_Cancel.onClick.AddListener(OnCancelClick);
    }

    public void SetParentID(string parentid)
    {
        parentID = parentid;
        Display(true);
    }

    private void OnAddClick()
    {
        if (string.IsNullOrEmpty(classifyName.text))
        {
            MessageBox.Display("分类名不能为空！", 1.5f, null);
            return;
        }

        AddClassifyToDatabase();
    }

    private void AddClassifyToDatabase()
    {
        DataCell_classify dc = new DataCell_classify();
        dc.Classify_name = classifyName.text;
        dc.Classify_parentID = int.Parse(parentID);

        if (SQLDataInterface.AddClassifyInfo(dc))
        {
            MessageBox.Display("添加成功", 1.5f, null);
        }
        else
        {
            MessageBox.Display("添加失败");

        }
    }

    private void OnCancelClick()
    {
        Display(false);
    }

}
