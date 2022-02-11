using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlane : MonoBehaviour
{
    [SerializeField] private Transform A;
    [SerializeField] private Transform B;
    [SerializeField] private Transform C;

    private Plane _plane;

    private void Start()
    {
        _plane = new Plane(new Coordinates(A.position),
            new Coordinates(B.position),
            new Coordinates(C.position));

        for(float s = 0; s < 1; s += 0.1f)
        {
            for(float t = 0; t < 1; t += 0.1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = _plane.Lerp(s, t).ToVector();
            }
        }
    }
}
