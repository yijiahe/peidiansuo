using UnityEngine;
using System.Collections;

//[System.Serializable]
public class WebRes
{
	public string abName;
	public AssetBundle assetBundle ;
	public bool loadCompelet ;
	public GameObject cloneGB ;

	public WebRes()
	{
		abName = "";
		assetBundle = null;
		loadCompelet = false;
		cloneGB = null;
	}
}
