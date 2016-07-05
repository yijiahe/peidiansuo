using UnityEngine;
using System.Collections;

public class MeshCreate
{

    public static Mesh CreateQuadMesh()
    {
        Mesh mesh = new Mesh();
        //顶点坐标
        Vector3[] vertices = new Vector3[]
        {
            new Vector3( 1, 0,  1),
            new Vector3( 1, 0, -1),
            new Vector3(-1, 0,  1),
            new Vector3(-1, 0, -1),
        };
        //UV坐标
        Vector2[] uv = new Vector2[]
        {
            new Vector2(1, 1),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(0, 0),
        };
        //Normal坐标
        Vector3[] nor = new Vector3[]
        {
            new Vector3( 1, 0,  1),
            new Vector3( 1, 0, -1),
            new Vector3(-1, 0,  1),
            new Vector3(-1, 0, -1),
        };
        //三角形索引
        int[] triangles = new int[]
        {
            0, 1, 2,
            2, 1, 3,
        };

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.normals = nor;

        return mesh;
    }
}