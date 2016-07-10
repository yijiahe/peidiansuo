
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;
using System.Data;
/// <summary>
/// 使用Application.persistentDataPath方式来创建文件，读写Xml文件.
/// 注Application.persistentDataPath末尾没有“/”符号
/// </summary>
public class FileHelper : MonoBehaviour
{

    /// <summary>
    /// 将文件移到固定目录
    /// </summary>
    /// <param name="srcPath"></param>
    /// <param name="targetPath"></param>
    /// <returns></returns>
    public static bool CopyDir(string srcPath, string targetPath)
    {
       // string filename = System.IO.Path.GetFileName(sourcePath);
        try
        {
            // 检查目标目录是否以目录分割字符结束如果不是则添加
            //if (targetPath[targetPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
            //{
            //    targetPath += System.IO.Path.DirectorySeparatorChar;
            //}
            // 判断目标目录是否存在如果不存在则新建
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
            Debug.Log("srcPath：" + srcPath + " targetPath: " + targetPath);
            // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
            // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
            // string[] fileList = Directory.GetFiles（srcPath）；
            System.IO.File.Copy(srcPath, targetPath + System.IO.Path.GetFileName(srcPath), true);

            //string[] fileList = System.IO.Directory.GetFileSystemEntries(srcPath);
            //// 遍历所有的文件和目录
            //foreach (string file in fileList)
            //{
            //    Debug.Log("a1");
            //    // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
            //    if (System.IO.Directory.Exists(file))
            //    {
            //        CopyDir(file, targetPath + System.IO.Path.GetFileName(file));
            //    }
            //    // 否则直接Copy文件
            //    else
            //    {
            //        Debug.Log("a2");
            //        //if (System.IO.File.Exists(targetPath + System.IO.Path.GetFileName(file)))
            //        //{
            //        //  //  System.IO.File.Copy(file, targetPath + System.IO.Path.GetFileName(file), true);
            //        //}
            //        //直接覆盖//
                  
            //       // return true;
            //    }
            //}
            return true;
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            return false;
            //throw;
            
        }

    }



/// <summary>
/// 动态创建文件夹.
/// </summary>
/// <returns>The folder.</returns>
/// <param name="path">文件创建目录.</param>
/// <param name="FolderName">文件夹名(不带符号).</param>
public string CreateFolder(string path, string FolderName)
    {
        string FolderPath = path + FolderName;
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }
        return FolderPath;
    }

    /// <summary>
    /// 创建文件.
    /// </summary>
    /// <param name="path">完整文件夹路径.</param>
    /// <param name="name">文件的名称.</param>
    /// <param name="info">写入的内容.</param>
    public void CreateFile(string path, string name, string info)
    {
        //文件流信息
        StreamWriter sw;
        FileInfo t = new FileInfo(path + name);
        if (!t.Exists)
        {
            //如果此文件不存在则创建
            sw = t.CreateText();
        }
        else
        {
            //如果此文件存在则打开
            sw = t.AppendText();
        }
        //以行的形式写入信息
        sw.WriteLine(info);
        //关闭流
        sw.Close();
        //销毁流
        sw.Dispose();
    }

    /// <summary>
    /// 读取文件.
    /// </summary>
    /// <returns>The file.</returns>
    /// <param name="path">完整文件夹路径.</param>
    /// <param name="name">读取文件的名称.</param>
    public ArrayList LoadFile(string path, string name)
    {
        //使用流的形式读取
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + name);
        }
        catch (Exception e)
        {
            //路径与名称未找到文件则直接返回空
            Debug.Log(e.ToString());
            return null;
        }
        string line;
        ArrayList arrlist = new ArrayList();
        while ((line = sr.ReadLine()) != null)
        {
            //一行一行的读取
            //将每一行的内容存入数组链表容器中
            arrlist.Add(line);
        }
        //关闭流
        sr.Close();
        //销毁流
        sr.Dispose();
        //将数组链表容器返回
        return arrlist;
    }
    //写入模型到本地
    IEnumerator loadassetbundle(string url)
    {
        WWW w = new WWW(url);
        yield return w;
        if (w.isDone)
        {
            byte[] model = w.bytes;
            int length = model.Length;
            //写入模型到本地
            CreateassetbundleFile(Application.persistentDataPath, "Model.assetbundle", model, length);
        }
    }
    /// <summary>
    /// 获取文件下所有文件大小
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public int GetAllFileSize(string filePath)
    {
        int sum = 0;
        if (!Directory.Exists(filePath))
        {
            return 0;
        }

        DirectoryInfo dti = new DirectoryInfo(filePath);

        FileInfo[] fi = dti.GetFiles();

        foreach (FileInfo f in fi)
        {

            sum += Convert.ToInt32(f.Length / 1024);
        }

        DirectoryInfo[] di = dti.GetDirectories();

        if (di.Length > 0)
        {
            for (int i = 0; i < di.Length; i++)
            {
                sum += GetAllFileSize(di[i].FullName);
            }
        }
        return sum;
    }
    /// <summary>
    /// 获取指定文件大小
    /// </summary>
    /// <param name="FilePath"></param>
    /// <param name="FileName"></param>
    /// <returns></returns>
    public int GetFileSize(string FilePath, string FileName)
    {
        int sum = 0;
        if (!Directory.Exists(FilePath))
        {
            return 0;
        }
        else
        {
            FileInfo Files = new FileInfo(@FilePath + FileName);
            sum += Convert.ToInt32(Files.Length / 1024);
        }
        return sum;
    }
    void CreateassetbundleFile(string path, string name, byte[] info, int length)
    {
        //文件流信息
        //StreamWriter sw;
        Stream sw;
        FileInfo t = new FileInfo(path + "//" + name);
        if (!t.Exists)
        {
            //如果此文件不存在则创建
            sw = t.Create();
        }
        else
        {
            //如果此文件存在则打开
            //sw = t.Append();
            return;
        }
        //以行的形式写入信息
        sw.Write(info, 0, length);
        //关闭流
        sw.Close();
        //销毁流
        sw.Dispose();
    }
    //读取本地AssetBundle文件
    IEnumerator LoadAssetbundleFromLocal(string path, string name)
    {
        Debug.Log("file:///" + path + "/" + name);

        WWW w = new WWW("file:///" + path + "/" + name);

        yield return w;

        if (w.isDone)
        {
            Instantiate(w.assetBundle.mainAsset);
                        
        }
    }

    /// <summary>
    /// 删除文件.
    /// </summary>
    /// <param name="path">删除完整文件夹路径.</param>
    /// <param name="name">删除文件的名称.</param>
    public void DeleteFile(string path, string name)
    {
        File.Delete(path + name);
    }
    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="filesName"></param>
    /// <returns></returns>
    public bool DeleteFiles(string path, string filesName)
    {
        bool isDelete = false;
        try
        {
            if (Directory.Exists(path))
            {
                if (File.Exists(path + "\\" + filesName))
                {
                    File.Delete(path + "\\" + filesName);
                    isDelete = true;
                }
            }
        }
        catch
        {
            return isDelete;
        }
        return isDelete;
    }
}
