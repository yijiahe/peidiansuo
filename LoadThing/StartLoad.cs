using UnityEngine;
using System.Collections;

public class StartLoad : MonoBehaviour 
{
	public GameObject player;
	public static bool knowPass = false;
	static bool knowbtnshow = false;
	public Rect knowBtnRect;
	public Rect knowRect;
	public int playerShow = 0;
	public Texture loadback;
	public Texture loadTip;
	public GameObject smapMap;

	LoadAllObject loadallobject = LoadAllObject.GetInstance();
	SceneObject sceneobject = SceneObject.GetInstance();

	void Awake()
	{


		if(player != null)
			player.SetActive(false);

		smapMap.SetActive(false);
	}

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(loadallobject.LoadGameObjects());
		StartCoroutine(CreatGameObject(Application.loadedLevel));
//		#if UNITY_EDITOR
//		string url =  "file:///S://CDU3D/AssetBundles/MapCamera.unity3d";
//		#else
//		string url =  Application.dataPath + "/AssetBundles/MapCamera.unity3d";
//		#endif
//		WWW www = new WWW(url);
//		yield return www;
//		if(www.error == null)
//		{
//			sceneobject.smallmapRes.abName = "MapCamera";
//			sceneobject.smallmapRes.assetBundle = www.assetBundle;
//			sceneobject.smallmapRes.cloneGB = www.assetBundle.mainAsset  as GameObject;
//			sceneobject.smallmapRes.loadCompelet = true;
//		}
//		else
//		{
//			sceneobject.smallmapRes.loadCompelet = false;
//		}
	}

	static int scId = 0;
	// Update is called once per frame
	void Update ()
	{
        //if(Input.GetKeyDown(KeyCode.L))
        //{
        //    scId++;
        //    if(scId < Application.levelCount)
        //    {
        //        Application.LoadLevel(scId);
        //    }
        //    else
        //    {
        //        scId = 0;
        //        Application.LoadLevel(scId);
        //    }
        //}
	}


	void OnGUI()
	{
		if(!player.activeSelf)
		{
			GUI.DrawTexture(GetScreenRect(knowRect),loadback,ScaleMode.StretchToFill);

		}
		if(!knowPass && !player.activeSelf)
		{
			GUI.DrawTexture(GetScreenRect(knowRect),loadTip,ScaleMode.StretchToFill);
			
		}
		if(knowbtnshow)
		{
			//if(GUI.Button(GetScreenRect(knowRect),"wozhidao"))
			if(GUI.Button(GetScreenRect(knowBtnRect)," "))//,GUIStyle.none))
			{
				knowbtnshow = false;
				KnowPass();
			}
		}
//		if(GUILayout.Button("场景跳转测试快捷键'L'"))
//		{
//			scId++;
//			if(scId < Application.levelCount)
//			{
//				Application.LoadLevel(scId);
//			}
//			else
//			{
//				scId = 0;
//			}
//		}
	}

	IEnumerator CreatGameObject(int sceneid)
	{
		int count = sceneobject.list[sceneid].Length;
		int i = 0;
		while(i < count)
		{
			while(! sceneobject.list[sceneid][i].loadCompelet)
			{
				yield return null;
			}
            Debug.Log("sceneobject.list[sceneid][i].cloneGB:" + sceneobject.list[sceneid][i].cloneGB.ToString());
			GameObject gb = Instantiate(sceneobject.list[sceneid][i].cloneGB) as GameObject;
			gb.SetActive(true);
			if(knowPass)
			{
				if(i == playerShow )
				{
					if(player != null)
						player.SetActive(true);
					smapMap.SetActive(true);
				}
			}
			else
			{
				if(i == playerShow )
				{
					knowbtnshow = true;
				}
			}

			i++;
		}
	}

	void KnowPass()
	{
		if(player != null)
			player.SetActive(true);
		smapMap.SetActive(true);
		knowPass = true;
	}

	Rect GetScreenRect(Rect rect)
	{
		Rect temp;
		temp = new Rect(rect.x/1920f*Screen.width,rect.y/1080f*Screen.height,rect.width/1920f*Screen.width,rect.height/1080f*Screen.height);
		return temp;
	}
}
