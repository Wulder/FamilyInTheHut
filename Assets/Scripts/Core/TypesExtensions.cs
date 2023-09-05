using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TypesExtensions
{
    public static Vector3 GetPlaceVector(this Vector3 v)
    {

        return new Vector3(v.x, 0, v.z);

    }
}
