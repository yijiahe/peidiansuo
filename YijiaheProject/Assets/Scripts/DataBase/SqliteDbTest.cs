using UnityEngine;
using System.Collections;
using System;
using Mono.Data.Sqlite;
using System.Data;
using System.Collections.Generic;
public class SqliteDbTest : MonoBehaviour
{
    //SqliteDbHelper db;

    void Start()
    {

    }

    void OnGUI()
    {
        if (GUILayout.Button("insert data"))
        {
            DataCell_classify data = new DataCell_classify();
            data.Classify_name = "aaaabbbbb6666";
            data.Classify_numpos = 5;
            data.Classify_parentID = 3;
            SQLDataInterface.AddClassifyInfo(data);
        }

        if (GUILayout.Button("update data"))
        {
            DataCell_classify data = new DataCell_classify();
            data.Classify_name = "bbb";
            data.Classify_numpos = 15;
            data.Classify_parentID = 13;
            data.Classify_id = 4;
            SQLDataInterface.UpdateClassifyInfo(data);
        }

        if (GUILayout.Button("search database From ParentID"))
        {
            int id = 3;
            List<DataCell_classify> dataList = SQLDataInterface.SelectClassifyListInfo(id);
            for (int i = 0; i < dataList.Count; i++)
                Debug.Log(" Classify_id:" + dataList[i].Classify_id + " Classify_name:" + dataList[i].Classify_name + " Classify_parentID:" + dataList[i].Classify_parentID + " Classify_numpos:" + dataList[i].Classify_numpos + "\n");
        }

        if (GUILayout.Button("search database From ClassifyID"))
        {
            int id = 3;
            DataCell_classify data = SQLDataInterface.SelectClassifyInfo(id);

            Debug.Log(" Classify_id:" + data.Classify_id + " Classify_name:" + data.Classify_name + " Classify_parentID:" + data.Classify_parentID + " Classify_numpos:" + data.Classify_numpos + "\n");
        }

        if (GUILayout.Button("insert model data"))
        {
            DataCell_model data = new DataCell_model();
            data.Model_name = "aaaa";
            data.Model_num = "test";
            data.Model_classify_name = "bbb";
            data.Modle_ThumbnailAddress = "E:/100CANON/IMG_0001.JPG";
            data.Model_address = "E:/GitHub/Prefab.unity3d";
            SQLDataInterface.AddModelInfo(data);
        }
       
    }

}
