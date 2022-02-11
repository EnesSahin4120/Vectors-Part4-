using UnityEngine;
using UnityEngine.UI;

public class IsInsideTriangleTest : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private Text InnerOrNotInnerText;

    [Header("Triangle Coordinates")]
    [SerializeField] private Vector2 point1;
    [SerializeField] private Vector2 point2;
    [SerializeField] private Vector2 point3;

    void Start()
    {
        Coordinates.DrawLine(new Coordinates(point1.x, point1.y), new Coordinates(point2.x, point2.y), 0.1f, Color.red);

        Coordinates.DrawLine(new Coordinates(point1.x, point1.y), new Coordinates(point3.x, point3.y), 0.1f, Color.red);

        Coordinates.DrawLine(new Coordinates(point2.x, point2.y), new Coordinates(point3.x, point3.y), 0.1f, Color.red);
    }

    void Update()
    {
        Vector2 pointPosition = new Vector2(point.position.x, point.position.y);
        if(Mathematics.IsInsideTriangle(new Coordinates(point1),new Coordinates(point2),new Coordinates(point3),new Coordinates(pointPosition)))
        {
            InnerOrNotInnerText.text = "Ball is Inside";
        }
        else
        {
            InnerOrNotInnerText.text = "Ball is Not Inside";
        }
    }
}
