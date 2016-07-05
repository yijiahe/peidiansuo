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
        GetComponent<MeshFilter>().mesh = MeshCreate.CreateQuadMesh();
    }

    public void DrawWall()
    {
        DrawWall(wallInfo);
    }
}
