using UnityEngine;

public class Coordinates : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    public Coordinates(float _x,float _y)
    {
        x = _x;
        y = _y;
        z = 0;
    }

    public Coordinates(float _x, float _y,float _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    public Coordinates(Vector3 vectorPosition)
    {
        x = vectorPosition.x;
        y = vectorPosition.y;
        z = vectorPosition.z;
    }

    public Coordinates(Vector2 vectorPosition)
    {
        x = vectorPosition.x;
        y = vectorPosition.y;
        z = 0;
    }

    static public Coordinates operator +(Coordinates a, Coordinates b)
    {
        Coordinates c = new Coordinates(a.x + b.x, a.y + b.y, a.z + b.z);
        return c;
    }

    static public Coordinates operator -(Coordinates a, Coordinates b)
    {
        Coordinates c = new Coordinates(a.x - b.x, a.y - b.y, a.z - b.z);
        return c;
    }

    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }

    public override string ToString()
    {
        return "(" + x + "," + y + "," + z + ")";
    }

    static public void DrawLine(Coordinates startPos, Coordinates endPos, float width, Color _color)
    {
        GameObject line = new GameObject("Line_" + startPos.ToString() + "_" + endPos.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = _color;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(startPos.x, startPos.y, startPos.z));
        lineRenderer.SetPosition(1, new Vector3(endPos.x, endPos.y, endPos.z));
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
}
