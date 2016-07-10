using UnityEngine;
using System.Collections;

public class LoadObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetTexture(string path)
    {
        StartCoroutine(LoadingTextureObject(path));
    }

    /// <summary>
    /// 加载本地图片
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public IEnumerator  LoadingTextureObject(string path)
    { 
        WWW www = new WWW("file://"+path);
        yield return www;        
        if(www != null && string.IsNullOrEmpty(www.error))
        {
           // Texture2D texture = www.texture;
        }
    }
}
