using UnityEngine;
using System.Collections;

public class Page : MonoBehaviour, IPage
{
    [SerializeField]
    GameObject pageRoot;

    [SerializeField]
    Page upPage;

    [SerializeField]
    Page nextPage;

    // Use this for initialization
    public virtual void Start()
    {

    }

    /// <summary>
    /// 显示隐藏
    /// </summary>
    /// <param name="state"></param>
    public virtual void Display(bool state)
    {
        pageRoot.SetActive(state);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="state"></param>
    /// <param name="page"></param>
    public virtual void Display(bool state, Page page)
    {
        //if (state)
        //{
        //    upPage = page;
        //}
        //else
        //{
        //    nextPage = page;
        //}
    }

    /// <summary>
    /// 返回上个页面
    /// </summary>
    public virtual void BackToUpPage()
    {
        //Display(false, upPage);
        //upPage.Display(true, this);
    }

    /// <summary>
    /// 返回上个页面
    /// </summary>
    public virtual void GoToNextPage()
    {
        //Display(false, nextPage);
        //nextPage.Display(true, this);
    }
}
