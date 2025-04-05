using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PathWay : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    private LineRenderer lineRenderer;

    public float spacing = 1f;
    public float drawSpeed = 10f;
    public float fadeDelay = 2f; // segundos antes de empezar a deshacerse
    public float fadeSpeed = 5f;
    public float curvaturaUno;
    public float curvaturaDos;

    private List<Vector3> fullPath = new List<Vector3>();
    private List<Vector3> visiblePath = new List<Vector3>();

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        GenerateCurvedPath();
        StartCoroutine(DrawAndFadePath());
    }

    void GenerateCurvedPath()
    {
        fullPath.Clear();

        Vector3 p0 = startPoint.position;
        Vector3 p3 = endPoint.position;
        Vector3 dir = (p3 - p0).normalized;
        float dist = Vector3.Distance(p0, p3);

        // Puntos de control intermedios para la curva (puedes ajustar alturas)
        Vector3 p1 = p0 + Vector3.up * (dist / curvaturaUno) + dir * (dist / curvaturaDos);
        Vector3 p2 = p0 + Vector3.down * (dist / curvaturaDos) + dir * (2f * dist / curvaturaUno);

        int segments = Mathf.CeilToInt(dist / spacing);
        for (int i = 0; i <= segments; i++)
        {
            float t = i / (float)segments;
            Vector3 point = GetBezierPoint(p0, p1, p2, p3, t);
            fullPath.Add(point);
        }
    }

    Vector3 GetBezierPoint(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        // Cubic Bezier
        return Mathf.Pow(1 - t, 3) * a +
               3 * Mathf.Pow(1 - t, 2) * t * b +
               3 * (1 - t) * t * t * c +
               Mathf.Pow(t, 3) * d;
    }

    IEnumerator DrawAndFadePath()
    {
        lineRenderer.positionCount = 0;
        visiblePath.Clear();

        // Dibuja progresivamente
        for (int i = 0; i < fullPath.Count; i++)
        {
            visiblePath.Add(fullPath[i]);
            lineRenderer.positionCount = visiblePath.Count;
            lineRenderer.SetPositions(visiblePath.ToArray());
            yield return new WaitForSeconds(1f / drawSpeed);
        }
    }
}
