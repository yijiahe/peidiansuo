﻿using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.Collections.Generic;

public class DianliStaticFunction
{

    /// <summary>
    /// 分类添加
    /// </summary>
    public static void AddClassifyInfo(DataCell_classify dataCell_calssify)
    {

        try
        {
            SqliteDbHelper db;
            db = new SqliteDbHelper("Data Source=" + Application.dataPath + SQLInfo.SQL_path);
            DataCell_classify dataclassify = dataCell_calssify;
            string[] aa = new string[] { null, dataclassify.Classify_name, dataclassify.Classify_parentID.ToString(), dataclassify.Classify_numpos.ToString() };
            // db.InsertClassifyInto(SQLInfo.classify_table, dataclassify.Classify_name, dataclassify.Classify_parentID, dataclassify.Classify_numpos);
            string query = "INSERT INTO " + SQLInfo.classify_table + " VALUES (" + "null" + "," + "'" + dataclassify.Classify_name + "'" + "," + dataclassify.Classify_parentID + "," + dataclassify.Classify_numpos;
            query += ")";

            db.ExecuteQuery(query);
            db.CloseSqlConnection();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
        finally
        {

        }
    }

    /// <summary>
    /// 分类修改
    /// </summary>
    public static void updateClassifyInfo(DataCell_classify dataCell_calssify)
    {
        SqliteDbHelper db;
        db = new SqliteDbHelper("Data Source=" + Application.dataPath + SQLInfo.SQL_path);
        DataCell_classify dataclassify = dataCell_calssify;
        //  db.UpdateInto(SQLInfo.classify_table, dataclassify.Classify_name, dataclassify.Classify_parentID, dataclassify.Classify_numpos)
        string query = "UPDATE " + SQLInfo.classify_table + " SET " + "classify_name = " + "'" + dataclassify.Classify_name + "'" + "," + "classify_parent = " + dataclassify.Classify_parentID + "," + "classify_pos =" + dataclassify.Classify_numpos;
        query += " WHERE " + "classify_id = " + dataclassify.Classify_id;
        db.ExecuteQuery(query);
        db.CloseSqlConnection();
    }

    /// <summary>
    /// 分类查找
    /// 根据分类父物体查找子分类列表
    /// </summary>
    public static List<DataCell_classify> SelectClassifyListInfo(int parentid)
    {
        SqliteDbHelper db;
        db = new SqliteDbHelper("Data Source=" + Application.dataPath + SQLInfo.SQL_path);
        List<DataCell_classify> dataclassifyList = new List<DataCell_classify>();
        //  db.UpdateInto(SQLInfo.classify_table, dataclassify.Classify_name, dataclassify.Classify_parentID, dataclassify.Classify_numpos)
        string query = "SELECT classify_id,classify_name,classify_parent,classify_pos " + " From " + SQLInfo.classify_table;
        query += " WHERE " + "classify_parent = " + parentid;
        SqliteDataReader sqlData = db.ExecuteQuery(query);
        while (sqlData.Read())
        {
            DataCell_classify dataclassify = new DataCell_classify();
            dataclassify.Classify_id = sqlData.GetInt32(sqlData.GetOrdinal("classify_id"));
            dataclassify.Classify_name = sqlData.GetString(sqlData.GetOrdinal("classify_name"));
            dataclassify.Classify_numpos = sqlData.GetInt32(sqlData.GetOrdinal("classify_pos"));
            dataclassify.Classify_parentID = sqlData.GetInt32(sqlData.GetOrdinal("classify_parent"));
            dataclassifyList.Add(dataclassify);
            // Debug.Log(" Classify_id:" + dataclassify.Classify_id + " Classify_name:" + dataclassify.Classify_name + " Classify_parentID:" + dataclassify.Classify_parentID + " Classify_numpos:" + dataclassify.Classify_numpos + "\n");

        }
        sqlData.Close();
        db.CloseSqlConnection();
        Debug.Log(dataclassifyList.Count);
        return dataclassifyList;
    }

    /// <summary>
    /// 分类查找
    /// 根据ID查找子分类列表
    /// </summary>
    public static DataCell_classify SelectClassifyInfo(int classify_id)
    {
        SqliteDbHelper db;
        db = new SqliteDbHelper("Data Source=" + Application.dataPath + SQLInfo.SQL_path);
        //  List<DataCell_classify> dataclassifyList = new List<DataCell_classify>();
        //  db.UpdateInto(SQLInfo.classify_table, dataclassify.Classify_name, dataclassify.Classify_parentID, dataclassify.Classify_numpos)
        string query = "SELECT classify_id,classify_name,classify_parent,classify_pos " + " From " + SQLInfo.classify_table;
        query += " WHERE " + "classify_id = " + classify_id;
        DataCell_classify dataclassify = new DataCell_classify();
        SqliteDataReader sqlData = db.ExecuteQuery(query);
        while (sqlData.Read())
        {

            dataclassify.Classify_id = sqlData.GetInt32(sqlData.GetOrdinal("classify_id"));
            dataclassify.Classify_name = sqlData.GetString(sqlData.GetOrdinal("classify_name"));
            dataclassify.Classify_numpos = sqlData.GetInt32(sqlData.GetOrdinal("classify_pos"));
            dataclassify.Classify_parentID = sqlData.GetInt32(sqlData.GetOrdinal("classify_parent"));
        }
        sqlData.Close();
        db.CloseSqlConnection();
        return dataclassify;
    }

    /// <summary>
    /// 添加模型元件
    /// </summary>
    /// <param name="dataCell_model"> 模型类对象</param>
    public static void AddModelInfo(DataCell_model dataCell_model)
    {
        SqliteDbHelper db;
        db = new SqliteDbHelper("Data Source=" + Application.dataPath + SQLInfo.SQL_path);
        DataCell_model datamodel = dataCell_model;
        string query = "INSERT INTO " + SQLInfo.model_table + " VALUES (" + "null" + "," + datamodel.Model_num + "," + datamodel.Model_name + "," + datamodel.Model_address;
        query += "," + datamodel.Modle_ThumbnailAddress + "," + datamodel.Model_Introduction + "," + datamodel.Model_classify_name + ")";
        db.ExecuteQuery(query);
        db.CloseSqlConnection();
    }



    //  CREATE TABLE "modelcell" (
    //[model_ID] INT, 
    //[model_num] VARCHAR(32), 
    //[model_name] VARCHAR(100), 
    //[model_address] VARCHAR(300), 
    //[modle_ThumbnailAddress] VARCHAR(300), 
    //[model_Introduction] VARCHAR(3000), 
    //[model_classify_name] VARCHAR(300), 
    //CONSTRAINT [] PRIMARY KEY ([model_ID]));

    /// <summary>
    /// 元件模型修改
    /// </summary>
    public static void updateModelInfo(DataCell_model dataCell_model)
    {
        SqliteDbHelper db;
        db = new SqliteDbHelper("Data Source=" + Application.dataPath + SQLInfo.SQL_path);
        DataCell_model datamodel = dataCell_model;
        string query = "UPDATE " + SQLInfo.model_table + " SET " + "model_num = " + datamodel.Model_num + "," + "model_name = " + datamodel.Model_name + "," + "model_address = " + datamodel.Model_address;
        query += "," + "modle_ThumbnailAddress = " + datamodel.Modle_ThumbnailAddress + "," + "model_Introduction = " + datamodel.Model_Introduction + "," + "model_classify_name = " + datamodel.Model_classify_name;
        query += " WHERE " + "model_id = " + datamodel.Model_id;
        db.ExecuteQuery(query);
        db.CloseSqlConnection();
    }

    /// <summary>
    /// 模型元件查找
    /// 根据分类父物体查找子分类列表
    /// </summary>
    /// <param name="model_classify_name">分类名称</param>
    /// <returns></returns>

    public static List<DataCell_model> SelectModelListInfo(string model_classify_name)
    {
        SqliteDbHelper db;
        db = new SqliteDbHelper("Data Source=" + Application.dataPath + SQLInfo.SQL_path);
        List<DataCell_model> datamodelyList = new List<DataCell_model>();
        string query = "SELECT * " + " From " + SQLInfo.model_table;
        query += " WHERE " + "model_classify_name = " + model_classify_name;
        SqliteDataReader sqlData = db.ExecuteQuery(query);
        while (sqlData.Read())
        {
            DataCell_model datamode = new DataCell_model();
            datamode.Model_id = sqlData.GetInt32(sqlData.GetOrdinal("model_ID"));
            datamode.Model_num = sqlData.GetString(sqlData.GetOrdinal("model_num"));
            datamode.Model_name = sqlData.GetString(sqlData.GetOrdinal("model_name"));
            datamode.Model_address = sqlData.GetString(sqlData.GetOrdinal("model_address"));
            datamode.Modle_ThumbnailAddress = sqlData.GetString(sqlData.GetOrdinal("modle_ThumbnailAddress"));
            datamode.Model_Introduction = sqlData.GetString(sqlData.GetOrdinal("model_Introduction"));
            datamode.Model_classify_name = sqlData.GetString(sqlData.GetOrdinal("model_classify_name"));
            datamodelyList.Add(datamode);

        }
        sqlData.Close();
        db.CloseSqlConnection();
        Debug.Log(datamodelyList.Count);
        return datamodelyList;
    }

    /// <summary>
    /// 分类查找
    /// 根据ID查找子分类列表
    /// </summary>
    public static DataCell_model SelectModelInfoByID(int model_id)
    {
        SqliteDbHelper db;
        db = new SqliteDbHelper("Data Source=" + Application.dataPath + SQLInfo.SQL_path);
        string query = "SELECT * " + " From " + SQLInfo.model_table;
        query += " WHERE " + "model_ID = " + model_id;
        DataCell_model datamode = new DataCell_model();
        SqliteDataReader sqlData = db.ExecuteQuery(query);
        while (sqlData.Read())
        {
            datamode.Model_id = sqlData.GetInt32(sqlData.GetOrdinal("model_ID"));
            datamode.Model_num = sqlData.GetString(sqlData.GetOrdinal("model_num"));
            datamode.Model_name = sqlData.GetString(sqlData.GetOrdinal("model_name"));
            datamode.Model_address = sqlData.GetString(sqlData.GetOrdinal("model_address"));
            datamode.Modle_ThumbnailAddress = sqlData.GetString(sqlData.GetOrdinal("modle_ThumbnailAddress"));
            datamode.Model_Introduction = sqlData.GetString(sqlData.GetOrdinal("model_Introduction"));
            datamode.Model_classify_name = sqlData.GetString(sqlData.GetOrdinal("model_classify_name"));
        }
        sqlData.Close();
        db.CloseSqlConnection();
        return datamode;
    }

    /// <summary>
    /// 分类查找
    /// 根据元件编号查找子分类列表
    /// </summary>
    /// <param name="model_num">元件编号</param>
    /// <returns></returns>
    public static DataCell_model SelectModelInfoByNum(string model_num)
    {
        SqliteDbHelper db;
        db = new SqliteDbHelper("Data Source=" + Application.dataPath + SQLInfo.SQL_path);
        string query = "SELECT * " + " From " + SQLInfo.model_table;
        query += " WHERE " + "model_num = " + model_num;
        DataCell_model datamode = new DataCell_model();
        SqliteDataReader sqlData = db.ExecuteQuery(query);
        while (sqlData.Read())
        {
            datamode.Model_id = sqlData.GetInt32(sqlData.GetOrdinal("model_ID"));
            datamode.Model_num = sqlData.GetString(sqlData.GetOrdinal("model_num"));
            datamode.Model_name = sqlData.GetString(sqlData.GetOrdinal("model_name"));
            datamode.Model_address = sqlData.GetString(sqlData.GetOrdinal("model_address"));
            datamode.Modle_ThumbnailAddress = sqlData.GetString(sqlData.GetOrdinal("modle_ThumbnailAddress"));
            datamode.Model_Introduction = sqlData.GetString(sqlData.GetOrdinal("model_Introduction"));
            datamode.Model_classify_name = sqlData.GetString(sqlData.GetOrdinal("model_classify_name"));
        }
        sqlData.Close();
        db.CloseSqlConnection();
        return datamode;
    }

    /// <summary>
    /// 元件模型删除
    /// </summary>
    public static void DeleteModelInfo(DataCell_model dataCell_model)
    {
        SqliteDbHelper db;
        db = new SqliteDbHelper("Data Source=" + Application.dataPath + SQLInfo.SQL_path);
        DataCell_model datamodel = dataCell_model;
        string query = "Delete  From" + SQLInfo.model_table;
        query += " WHERE  " + "model_id = " + datamodel.Model_id;
        db.ExecuteQuery(query);
        db.CloseSqlConnection();
    }

}
