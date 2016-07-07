using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Wall : EBehaviour
{
    public WallInfo wallInfo = new WallInfo();

    // Use this for initialization
    void Start()
    {
        DrawWall();
    }

    public void DrawWall(WallInfo wallinfo)
    {
        UpdateWall(wallinfo);
    }

    public void DrawWall()
    {
        DrawWall(wallInfo);
    }

    void UpdateWall(WallInfo wallinfo)
    {
        wallInfo = wallinfo;
        if (wallInfo.EMeshFilter == null)
            wallInfo.EMeshFilter = GetComponent<MeshFilter>();
        if (wallInfo.EMeshFilter.mesh != null)
            DestroyImmediate(wallInfo.EMeshFilter.mesh);
        wallInfo.EMeshFilter.mesh = MeshCreate.CreateQuadMesh();
    }
}
