using UnityEngine;
using System.Collections;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public class FileFrom
{

    public static string OpenFile(string title, bool multiselect, string filter)
    {
        try
        {
            return OpenFile("C:\\", title, multiselect, filter);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            return OpenFileOld(title, multiselect, filter);
        }
    }

    public static string SaveFile(string title, bool multiselect, string filter)
    {
        try
        {
            return SaveFile("C:\\", title, multiselect, filter);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            return SaveFileOld(title, filter);
        }
    }

    static string OpenFile(string path, string title, bool multiselect, string filter)
    {
        OpenFileName ofn = new OpenFileName();

        ofn.structSize = Marshal.SizeOf(ofn);

        ofn.filter = filter;

        ofn.file = new string(new char[256]);

        ofn.maxFile = ofn.file.Length;

        ofn.fileTitle = new string(new char[64]);

        ofn.maxFileTitle = ofn.fileTitle.Length;

        path = path.Replace('/', '\\');
        //默认路径
        ofn.initialDir = path;
        //ofn.InitialDirectory = "D:\\MyProject\\UnityOpenCV\\Assets\\StreamingAssets";
        ofn.title = title;

        ofn.defExt = "unity3d";//显示文件的类型
        //注意 一下项目不一定要全选 但是0x00000008项不要缺少
        ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;//OFN_EXPLORER|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR

        if (WindowDll.GetOpenFileName(ofn))
        {
            Debug.Log("Selected file with full path: {0}" + ofn.file);
        }
        return ofn.file;
    }

    static string SaveFile(string path, string title, bool multiselect, string filter)
    {
        OpenFileName ofn = new OpenFileName();

        ofn.structSize = Marshal.SizeOf(ofn);

        ofn.filter = filter;

        ofn.file = new string(new char[256]);

        ofn.maxFile = ofn.file.Length;

        ofn.fileTitle = new string(new char[64]);

        ofn.maxFileTitle = ofn.fileTitle.Length;

        path = path.Replace('/', '\\');
        //默认路径
        ofn.initialDir = path;
        //ofn.InitialDirectory = "D:\\MyProject\\UnityOpenCV\\Assets\\StreamingAssets";
        ofn.title = title;

        ofn.defExt = "unity3d";//显示文件的类型
        //注意 一下项目不一定要全选 但是0x00000008项不要缺少
        ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;//OFN_EXPLORER|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR

        if (WindowDll.GetSaveFileName(ofn))
        {
            Debug.Log("Selected file with full path: {0}" + ofn.file);
        }
        return ofn.file;
    }

    public static string OpenFileOld(string title, bool multiselect, string filter)
    {
        OpenFileDialog od = new OpenFileDialog();
        od.Title = title;
        od.Multiselect = multiselect;
        od.Filter = filter;// "图片文件(*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp";

        if (od.ShowDialog() == DialogResult.OK)
        {
            return od.FileName;
        }
        return "";
    }

    public static string SaveFileOld(string title, string filter)
    {
        SaveFileDialog sd = new SaveFileDialog();
        sd.Title = title;
        sd.Filter = filter;

        if (sd.ShowDialog() == DialogResult.OK)
        {
            return sd.FileName;
        }
        return "";
    }
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class OpenFileName
{
    public int structSize = 0;
    public IntPtr dlgOwner = IntPtr.Zero;
    public IntPtr instance = IntPtr.Zero;
    public String filter = null;
    public String customFilter = null;
    public int maxCustFilter = 0;
    public int filterIndex = 0;
    public String file = null;
    public int maxFile = 0;
    public String fileTitle = null;
    public int maxFileTitle = 0;
    public String initialDir = null;
    public String title = null;
    public int flags = 0;
    public short fileOffset = 0;
    public short fileExtension = 0;
    public String defExt = null;
    public IntPtr custData = IntPtr.Zero;
    public IntPtr hook = IntPtr.Zero;
    public String templateName = null;
    public IntPtr reservedPtr = IntPtr.Zero;
    public int reservedInt = 0;
    public int flagsEx = 0;
}

public class WindowDll
{
    [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);

    [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern bool GetSaveFileName([In, Out] OpenFileName ofn);

    public static bool GetOpenFileName1([In, Out] OpenFileName ofn)
    {
        return GetOpenFileName(ofn);
    }

    public static bool GetSaveFileName1([In, Out] OpenFileName ofn)
    {
        return GetSaveFileName(ofn);
    }
}
