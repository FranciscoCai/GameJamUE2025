using UnityEngine;
using UnityEngine.Rendering;

public class TransparenciaMariachio : MonoBehaviour
{
    public Transform target; // Objeto al que se acercar�
    public float maxDistance = 50f; 
    public float minDistance = 10f; 
    private Renderer objectRenderer;
    private Material material;
    public Renderer[] hijos;
    public Material[] materialHijo;

    void Start()
    {
        // Obtener el renderer del objeto
        objectRenderer = GetComponent<Renderer>();
        material = objectRenderer.material;
    }

    void Update()
    {
        // Calcula la distancia entre el objeto y el objetivo
        float distance = Vector3.Distance(transform.position, target.position);

        float alpha = Mathf.InverseLerp(maxDistance, minDistance, distance);
        alpha = Mathf.Clamp01(alpha); // Aseguramos que est� entre 0 y 1

        // Modificamos el color del material
        Color color = material.color;
        color.a = alpha;
        material.color = color;
        for(int i = 0; i < hijos.Length; i++)
        {
            Color colorHijo = hijos[i].material.color;
            colorHijo.a = alpha;
            hijos[i].material.color = colorHijo;
        }
        if (distance < 10)
        {
            material.SetInt("_Surface",0);
            for(int i = 0; i < hijos.Length; i++)
            {
                materialHijo[i].SetInt("_Surface",0);
            }
        } else
        {
            material.SetInt("_Surface", 1);
            for (int i = 0; i < hijos.Length; i++)
            {
                materialHijo[i].SetInt("_Surface", 1);
            }
        }
    }
}
