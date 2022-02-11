using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    Coordinates A;
    Coordinates B;
    Coordinates C;
    Coordinates v;
    Coordinates u;

    public Plane (Coordinates _A, Coordinates _B, Coordinates _C)
    {
        A = _A;
        B = _B;
        C = _C;
        v = B - A;
        u = C - A;
    }

    public Plane (Coordinates _A, Vector3 V, Vector3 U)
    {
        A = _A;
        v = new Coordinates(V.x, V.y, V.z);
        u = new Coordinates(U.x, U.y, U.z);
    }

    public Coordinates Lerp (float s, float t)
    {
        float xst = A.x + v.x * s + u.x * t;
        float yst = A.y + v.y * s + u.y * t;
        float zst = A.z + v.z * s + u.z * t;

        return new Coordinates(xst, yst, zst);
    }
}
