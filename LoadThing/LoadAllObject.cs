using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadAllObject 
{
	static LoadAllObject instance;

	public WWW www;
	//public Thread loadTh;
	SceneObject sceneobject = SceneObject.GetInstance();

	// Use this for initialization
	private LoadAllObject() 
	{
		//loadTh = new Thread(new ThreadStart(LoadGameObject));
	}

	public static LoadAllObject GetInstance()
	{
		if(instance == null)
		{
			instance = new LoadAllObject();
		}
		return instance;
	}

	public IEnumerator LoadGameObjects()
	{
		int i_F = Application.loadedLevel;
		int count_F = sceneobject.list[i_F].Length;
		int j_F = 0;
		Debug.Log("i_F"+i_F);
		while(j_F < count_F)
		{
			if(!sceneobject.list[i_F][j_F].loadCompelet)
			{
				www = new WWW(GetLoadPath(sceneobject.list[i_F][j_F].abName,i_F+1));
				yield return www;
				if(www.error == null)
				{
					sceneobject.list[i_F][j_F].assetBundle = www.assetBundle;
					sceneobject.list[i_F][j_F].cloneGB = www.assetBundle.mainAsset as GameObject;
					sceneobject.list[i_F][j_F].loadCompelet = true;
					www.assetBundle.Unload(false);
					Debug.Log(sceneobject.list[i_F][j_F].abName + " Load True");
					
				}
				else
				{
					sceneobject.list[i_F][j_F].loadCompelet = false;
					Debug.Log(sceneobject.list[i_F][j_F].abName + " Load False");
				}
				
			}
			j_F++;
		}

//		List<WebRes[]> solist = sceneobject.list;
//		int firstLoadNum = Application.loadedLevel;
//		solist[0] = sceneobject.list[firstLoadNum];
//		for(int a = 1; a < solist.Count - 1; a++)
//		{
//			if(a <= firstLoadNum)
//			{
//				solist[a] = sceneobject.list[a-1];
//			}
//			else
//			{
//				solist[a] = sceneobject.list[a];
//			}
//			Debug.Log(solist[a].ToString());
//		}

		int scenenum = sceneobject.list.Count;
		Debug.Log("scenenum" + scenenum);
		for(int i = 0;i < scenenum ;i++)
		{
			int count = sceneobject.list[i].Length;
			int j = 0;
			//Debug.Log("i"+i);
			while(j < count)
			{
				if(!sceneobject.list[i][j].loadCompelet)
				{
					www = new WWW(GetLoadPath(sceneobject.list[i][j].abName,i+1));
					yield return www;
					if(www.error == null)
					{
						sceneobject.list[i][j].assetBundle = www.assetBundle;
						sceneobject.list[i][j].cloneGB = www.assetBundle.mainAsset as GameObject;
						sceneobject.list[i][j].loadCompelet = true;
						www.assetBundle.Unload(false);
						//Debug.Log(sceneobject.list[i][j].abName + " Load True");

					}
					else
					{
						sceneobject.list[i][j].loadCompelet = false;
					//	Debug.Log(sceneobject.list[i][j].abName + " Load False");
					}

				}
				j++;
			}
		}
	}

	string GetLoadPath(string name,int sceneid)
	{
		#if UNITY_EDITOR
        return "file:///E:/work/CDU3D_1_30/AssetBundles/CD_ZT_" + sceneid.ToString() + "_Prefabs/" + name + ".unity3d";
		#else
		return  Application.dataPath + "/AssetBundles/CD_ZT_" + sceneid.ToString() + "_Prefabs/" + name +".unity3d";
		#endif
	}
}
