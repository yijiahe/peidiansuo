using UnityEngine;
using System.Collections;

public interface IPage
{
    /// <summary>
    /// 显示隐藏页面
    /// </summary>
    /// <param name="state"></param>
    void Display(bool state);

    /// <summary>
    /// 显示隐藏页面，并记录上一个页面
    /// </summary>
    /// <param name="state"></param>
    /// <param name="page"></param>
    void Display(bool state, Page page);

    /// <summary>
    /// 返回上一个界面
    /// </summary>
    void BackToUpPage();
}
