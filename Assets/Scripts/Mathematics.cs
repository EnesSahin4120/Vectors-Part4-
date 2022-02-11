using System.Collections.Generic;
using UnityEngine;

public class Mathematics : MonoBehaviour
{
    static public float Square(float grade)
    {
        return grade * grade;
    }

    static public float Distance(Coordinates coord1,Coordinates coord2)
    {
        float diffSquared = Square(coord1.x - coord2.x) +
            Square(coord1.y - coord2.y) +
            Square(coord1.z - coord2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;
    }

    static public float VectorLength(Coordinates vector)
    {
        float length = Distance(new Coordinates(0, 0, 0), vector);
        return length;
    }

    static public float HypotenuseLength(float a,float b)
    {
        return Mathf.Sqrt(a * a + b * b);
    }

    static public Coordinates Normalize(Coordinates vector)
    {
        float length = VectorLength(vector);
        vector.x /= length;
        vector.y /= length;
        vector.z /= length;

        return vector;
    }

    static public float Dot(Coordinates vector1,Coordinates vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    static public Coordinates Projection(Coordinates vector1,Coordinates vector2)
    {
        float numeratorPart = Dot(vector1, vector2);
        float vector2Length = VectorLength(vector2);
        float denominatorPart = Square(vector2Length);
        Coordinates resultCoordinate = new Coordinates(vector2.x * (numeratorPart / denominatorPart), vector2.y * (numeratorPart / denominatorPart), vector2.z * (numeratorPart / denominatorPart));
   
        return resultCoordinate;
    }

    static public List<Coordinates> Orthogonalization(Coordinates vector1,Coordinates vector2,Coordinates vector3)
    {
        Coordinates orthogonalization1 = vector1;

        Coordinates orthogonalization2 = new Coordinates(vector2.x - Projection(vector2, orthogonalization1).x,
            vector2.y - Projection(vector2, orthogonalization1).y,
            vector2.z - Projection(vector2, orthogonalization1).z);

        Coordinates orthogonalization3 = new Coordinates(vector3.x - Projection(vector3, orthogonalization1).x - Projection(vector3, orthogonalization2).x,
            vector3.y - Projection(vector3, orthogonalization1).y - Projection(vector3, orthogonalization2).y,
            vector3.z - Projection(vector3, orthogonalization1).z - Projection(vector3, orthogonalization2).z);

        List<Coordinates> resultCoordinates = new List<Coordinates>();
        resultCoordinates.Add(orthogonalization1);
        resultCoordinates.Add(orthogonalization2);
        resultCoordinates.Add(orthogonalization3);

        return resultCoordinates;
    } 

    static public List<Coordinates> Orthonormalization(Coordinates vector1,Coordinates vector2,Coordinates vector3)
    {
        Coordinates orthonormalization1 = new Coordinates(vector1.x / VectorLength(vector1), vector1.y / VectorLength(vector1), vector1.z / VectorLength(vector1));
        Coordinates orthonormalization2 = new Coordinates(vector2.x / VectorLength(vector2), vector2.y / VectorLength(vector2), vector2.z / VectorLength(vector2));
        Coordinates orthonormalization3 = new Coordinates(vector3.x / VectorLength(vector3), vector3.y / VectorLength(vector3), vector3.z / VectorLength(vector3));

        List<Coordinates> resultCoordinates = new List<Coordinates>();
        resultCoordinates.Add(orthonormalization1);
        resultCoordinates.Add(orthonormalization2);
        resultCoordinates.Add(orthonormalization3);

        return resultCoordinates;
    }

    static public Coordinates Cross(Coordinates vector1, Coordinates vector2)
    {
        float i = vector1.y * vector2.z - vector1.z * vector2.y;
        float j = vector1.z * vector2.x - vector1.x * vector2.z;
        float k = vector1.x * vector2.y - vector1.y * vector2.x;

        Coordinates resultCoordinates = new Coordinates(i, j, k);
        return resultCoordinates;
    }

    static public float TripleProduct(Coordinates vector1,Coordinates vector2,Coordinates vector3)
    {
        return Dot(vector1, Cross(vector2, vector3));
    }

    static public float Area(Coordinates vector1,Coordinates vector2)
    {
        return VectorLength(Cross(vector1, vector2));
    }

    static public float Volume(Coordinates vector1, Coordinates vector2, Coordinates vector3)
    {
        return Mathf.Abs(TripleProduct(vector1, vector2, vector3));
    }   

    static public List<float> PolarCoordinates(Coordinates vector)
    {
        float r = VectorLength(new Coordinates(vector.x, vector.y, 0));
        float theta = Mathf.Rad2Deg * Mathf.Atan2(vector.y, vector.x);

        List<float> resultNumericals = new List<float>();
        resultNumericals.Add(r);
        resultNumericals.Add(theta);

        return resultNumericals;
    }

    static public List<float> SphericalCoordinates(Coordinates vector)
    {
        float r = VectorLength(vector);
        float theta = Mathf.Rad2Deg * Mathf.Atan2(vector.y, vector.x);
        float phi = Mathf.Rad2Deg * Mathf.Atan2(VectorLength(new Coordinates(vector.x, vector.y, 0)), vector.z);

        List<float> resultNumericals = new List<float>();
        resultNumericals.Add(r);
        resultNumericals.Add(theta);
        resultNumericals.Add(phi);

        return resultNumericals;
    }

    static public float DistancePointToLine(Coordinates point, Coordinates pointOnLine, Coordinates lineDirection)
    {
        Coordinates M0_M1 = new Coordinates(pointOnLine.x - point.x, pointOnLine.y - point.y, pointOnLine.z - point.z);
        Coordinates S = Cross(M0_M1, lineDirection);

        float S_Length = VectorLength(S);
        float lineDirection_length = VectorLength(lineDirection);

        return S_Length / lineDirection_length;
    }

    static public float TriangleArea(Coordinates point1,Coordinates point2,Coordinates point3)
    {
        float x1 = point1.x;
        float y1 = point1.y;

        float x2 = point2.x;
        float y2 = point2.y;

        float x3 = point3.x;
        float y3 = point3.y;

        float triangleArea= Mathf.Abs(x1 * (y2 - y3) +
                        x2 * (y3 - y1) +
                        x3 * (y1 - y2)) / 2.0f;

        return triangleArea;
    }

    static public bool IsInsideTriangle(Coordinates trianglePoint1,Coordinates trianglePoint2, Coordinates trianglePoint3,Coordinates point)
    {
        float A = TriangleArea(trianglePoint1, trianglePoint2, trianglePoint3);
        float A1 = TriangleArea(point, trianglePoint2, trianglePoint3);
        float A2 = TriangleArea(trianglePoint1, point, trianglePoint3);
        float A3 = TriangleArea(trianglePoint1, trianglePoint2, point);

        return (A == A1 + A2 + A3);
    }
}
