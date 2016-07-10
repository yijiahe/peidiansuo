using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneObject 
{
	static SceneObject instance;

	/// <summary>
	/// 1_DiMian_Prefab
	/// 1_Ditu_Wall_Prefab
	/// 1_Quxian_Wall_Prefab.
	/// 1_Wall_Prefab
	/// 1_zhongjian_Prefab
	/// </summary>

	public List<WebRes[]> list = new List<WebRes[]>();
	
	public WebRes[] zt1_WebRes = new WebRes[5];
	public WebRes[] zt2_WebRes = new WebRes[6];
	public WebRes[] zt3_WebRes = new WebRes[5];
	public WebRes[] zt4_WebRes = new WebRes[4];
	public WebRes[] zt5_WebRes = new WebRes[13];

	public WebRes smallmapRes = new WebRes();

	private SceneObject () 
	{
		for(int i = 0; i < zt1_WebRes.Length;i++)
		{
			zt1_WebRes[i] = new WebRes();
		}
		list.Add(zt1_WebRes);
		zt1_WebRes[0].abName = "1_DiMian_Prefab";
		zt1_WebRes[1].abName = "1_Ditu_Wall_Prefab";
		zt1_WebRes[2].abName = "1_Quxian_Wall_Prefab";
		zt1_WebRes[3].abName = "1_Wall_Prefab";
		zt1_WebRes[4].abName = "1_zhongjian_Prefab";

		for(int i = 0; i < zt2_WebRes.Length;i++)
		{
			zt2_WebRes[i] = new WebRes();
		}
		list.Add(zt2_WebRes);
		zt2_WebRes[0].abName = "2_1_DiMian_Prefab";
		zt2_WebRes[1].abName = "2_2_Wall_Prefab";
		zt2_WebRes[2].abName = "2_3_Middle1_Prefab";
		zt2_WebRes[3].abName = "2_4_Middle2_Prefab";
		zt2_WebRes[4].abName = "2_5_Left_Prefab";
		zt2_WebRes[5].abName = "2_6_Right_Prefab";

		for(int i = 0; i < zt3_WebRes.Length;i++)
		{
			zt3_WebRes[i] = new WebRes();
		}
		list.Add(zt3_WebRes);
		zt3_WebRes[0].abName = "3_1_DiMian_Prefab";
		zt3_WebRes[1].abName = "3_2_Wall_Prefab";
		zt3_WebRes[2].abName = "3_3_Right_Prefab";
		zt3_WebRes[3].abName = "3_4_Left_Prefab";
		zt3_WebRes[4].abName = "3_5_Middle_Prefab";

		for(int i = 0; i < zt4_WebRes.Length;i++)
		{
			zt4_WebRes[i] = new WebRes();
		}
		list.Add(zt4_WebRes);
		zt4_WebRes[0].abName = "4_1_DiMian_Prefab";
		zt4_WebRes[1].abName = "4_2_Wall_Prefab";
		zt4_WebRes[2].abName = "4_3_Middle1_Prefab";
		zt4_WebRes[3].abName = "4_4_Middle2_Prefab";

		for(int i = 0; i < zt5_WebRes.Length;i++)
		{
			zt5_WebRes[i] = new WebRes();
		}
		list.Add(zt5_WebRes);
		zt5_WebRes[0].abName = "56_1_Dimian_Prefab";
		zt5_WebRes[1].abName = "56_2_Wall_Prefab";
		zt5_WebRes[2].abName = "56_3_Middle1_Prefab";
		zt5_WebRes[3].abName = "56_4_Middle2_Prefab";
		zt5_WebRes[4].abName = "56_5_Middle3_Prefab";
		zt5_WebRes[5].abName = "56_6_Middle4_Prefab";
		zt5_WebRes[6].abName = "56_7_Middle5_Prefab";
		zt5_WebRes[7].abName = "56_8_Middle6_Prefab";
		zt5_WebRes[8].abName = "56_9_Middle7_Prefab";
		zt5_WebRes[9].abName = "56_10_Middle8_Prefab";
		zt5_WebRes[10].abName = "56_11_Middle9_Prefab";
		zt5_WebRes[11].abName = "56_12_Middle10_Prefab";
		zt5_WebRes[12].abName = "56_13_Middle11_Prefab";
	}

	public static SceneObject GetInstance()
	{
		if(instance == null)
		{
			instance = new SceneObject();
		}
		return instance;
	}
}
