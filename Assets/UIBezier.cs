using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBezier : MonoBehaviour
{
    [SerializeField] private RectTransform _p0;
    [SerializeField] private RectTransform _p1;
    [SerializeField] private RectTransform _p2;
    [SerializeField] private RectTransform _p3;
    [SerializeField] private Transform _container;

    public Vector3 CubicBezier(float t)
    {
        const float ArbitraryScale = 1f;
        return Bezier.CubicBezier(_p0.position * ArbitraryScale, _p1.position * ArbitraryScale,
            _p2.position * ArbitraryScale, _p3.position * ArbitraryScale, t);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateChildren(_container);
    }

    void UpdateChildren(Transform transform)
    {
        var children = new RectTransform[transform.childCount];
        for (var i = 0; i < transform.childCount; i++)
        {
            children[i] = (RectTransform) transform.GetChild(i);
        }

        for (var i = 0; i < children.Length; i++)
        {
            var child = children[i];
            var j = (float) (i + 0.5f) / children.Length;
            j = Mathf.Lerp(0.45f, 0.55f, j);
            child.position = CubicBezier(j);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

public static class Bezier
{
    public static Vector3 CubicBezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        //SOURCE
        //https://answers.unity.com/questions/959091/how-can-i-make-a-lerp-move-in-an-arc-instead-of-a.html
        //By Bunny83
        float r = 1f - t;
        float f0 = r * r * r;
        float f1 = r * r * t * 3;
        float f2 = r * t * t * 3;
        float f3 = t * t * t;
        return new Vector3(
            f0 * p0.x + f1 * p1.x + f2 * p2.x + f3 * p3.x,
            f0 * p0.y + f1 * p1.y + f2 * p2.y + f3 * p3.y,
            f0 * p0.z + f1 * p1.z + f2 * p2.z + f3 * p3.z
        );
    }
}