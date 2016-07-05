/*
 * 分析页面文件，读取标签内容
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public class AnalysisPage
{
    public static string AnalysisOneLable(string pagecontent, WebPageMark webpagemark, string id)
    {
        if (pagecontent == null && pagecontent.Length == 0)
            return null;
        if (!pagecontent.Contains(webpagemark.ToString()))
            return null;

        string str = "";
        string[] strs = pagecontent.Split(new string[] { "<" + webpagemark.ToString() }, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < strs.Length; i++)
        {
            if (strs[i].Contains('"' + id + '"'))
            {
                string[] str_1 = strs[i].Split(new string[] { "</" + webpagemark.ToString() }, System.StringSplitOptions.RemoveEmptyEntries);
                if (webpagemark == WebPageMark.td)
                {
                    string[] str_2 = str_1[0].Split(new string[] { ">" }, System.StringSplitOptions.RemoveEmptyEntries);
                    if (str_2.Length > 1)
                        str = str_2[1];
                    else
                        str = str_2[0];
                }
                else
                    str = str_1[0];
            }
        }
        return str;
    }

    public static string AnalysisImageUrl(string pagecontent)
    {
        string[] url = pagecontent.Split('"');
        if (url.Length > 1)
            return pagecontent.Split('"')[1];
        return url[0];
    }

    public static string[] AnalysisMarkList(string content, WebPageMark mark, string id)
    {
        string[] markList = content.Split(new string[] { "</" + mark.ToString() + ">" }, System.StringSplitOptions.RemoveEmptyEntries);
        if (markList.Length == 0)
            return new string[0];
        string[] ml = new string[markList.Length];
        if (id != null && id.Length > 0)
        {
            if (markList.Length > 1)
            {

                int count = 0;
                for (int i = 0; i < ml.Length; i++)
                {
                    if (markList[i].Contains('"' + id + '"'))
                    {
                        ml[count] = markList[i];
                        count += 1;
                    }
                }
                string[] str = new string[count];
                for (int i = 0; i < count; i++)
                {
                    str[i] = ml[i];
                }
                return str;
            }
            else
            {
                if (markList[0].Contains('"' + id + '"'))
                    ml = markList;
                else
                    ml[0] = "";
            }
        }
        else
        {
            ml = markList;
        }
        return ml;
    }

    public static string AnalysisInput(string content, string id)
    {
        string[] markList = content.Split(new string[] { "<" + WebPageMark.input.ToString() }, System.StringSplitOptions.RemoveEmptyEntries);

        if (id != null && id.Length > 0)
        {
            for (int i = 0; i < markList.Length; i++)
            {
                if (markList[i].Contains('"' + id + '"'))
                {
                    return markList[i];
                }
            }
            return "";
        }
        else
        {
            return markList[0];
        }
    }

    public static string TransformDate(string date)
    {
        string tdate = "";
        string[] dates = date.Split("-"[0]);
        char[] year = dates[0].ToCharArray();
        char[] mouth;
        char[] day;
        if (dates.Length > 1)
        {
            mouth = dates[1].ToCharArray();
            if (dates.Length > 2)
                day = dates[2].ToCharArray();
            else
                day = new char[] { 'O', 'O' };
        }
        else
        {
            mouth = new char[] { 'O', 'O' };
            day = new char[] { 'O', 'O' };
        }

        tdate += MatchNumber(year);
        tdate += MatchNumber(mouth);
        tdate += MatchNumber(day);

        return tdate;
    }

    static string MatchNumber(char[] c)
    {
        string s = "";
        for (int i = 0; i < c.Length; i++)
        {
            s += MatchNumber(c[i]);
        }
        return s;
    }

    static string MatchNumber(char c)
    {
        switch (c)
        {
            case '0':
            case 'O':
                return "O";
            case '1':
                return "一";
            case '2':
                return "二";
            case '3':
                return "三";
            case '4':
                return "四";
            case '5':
                return "五";
            case '6':
                return "六";
            case '7':
                return "七";
            case '8':
                return "八";
            case '9':
                return "九";
        }
        return "";
    }

    public static Texture2D GetGifImage(byte[] bt, int index)
    {
        List<Texture2D> tex2ds = new List<Texture2D>();
        tex2ds = GetGifImage(bt);
        if (index < tex2ds.Count)
            return tex2ds[index];
        return null;
    }

    public static List<Texture2D> GetGifImage(byte[] bt)
    {
        List<Texture2D> t2s = new List<Texture2D>();
        MemoryStream ms = new MemoryStream(bt);

        Image imgGif = Image.FromStream(ms);

        if (System.Drawing.ImageAnimator.CanAnimate(imgGif))
        {
            System.Drawing.Imaging.FrameDimension imgFrmDim = new System.Drawing.Imaging.FrameDimension(imgGif.FrameDimensionsList[0]);
            // 获取帧数
            int nFdCount = imgGif.GetFrameCount(imgFrmDim);
            for (int i = 0; i < nFdCount; i++)
            {
                // 把每一帧保存为jpg图片
                imgGif.SelectActiveFrame(imgFrmDim, i);
                Texture2D t2 = new Texture2D(imgGif.Width, imgGif.Height);
                t2.LoadImage(ImageToByteArray(imgGif));
                t2s.Add(t2);
            }
        }
        return t2s;
    }

    static byte[] ImageToByteArray(Image image)
    {
        byte[] bt = null;
        MemoryStream ms = new MemoryStream();
        Bitmap bim = new Bitmap(image);
        bim.Save(ms, ImageFormat.Png);
        ms.Position = 0;
        bt = new byte[ms.Length];
        ms.Read(bt, 0, System.Convert.ToInt32(ms.Length));
        ms.Flush();
        return bt;
    }
}

public enum WebPageMark
{
    div,
    table,
    tr,
    td,
    input
}