using System.Collections;
using UnityEngine;

public class DesactivartUTORIAL : MonoBehaviour
{
   [SerializeField] private float Cd = 10f;
    void Start()
    {
        StartCoroutine(DesActive());
    }

 private IEnumerator DesActive()
    {
        yield return new WaitForSeconds(Cd);
        gameObject.SetActive(false);
    }
}
