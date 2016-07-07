using UnityEngine;
using System.Collections;

[System.Serializable]
public class WallInfo : EObject
{
    Mesh wallMesh;
    public Mesh WallMesh
    {
        set
        {
            wallMesh = value;
        }
        get
        {
            return wallMesh;
        }
    }
}
