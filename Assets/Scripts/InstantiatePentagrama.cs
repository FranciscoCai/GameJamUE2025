using System.Collections;
using UnityEngine;

public class InstantiatePentagrama : MonoBehaviour
{
    [SerializeField] private GameObject[] piezasPentagrama;
    private int numbInstance;
    [SerializeField] private float cd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Beluga"))
        {
            Debug.Log(1);
            StartCoroutine(PentagramaInstantiate());
        }
    }

    // Update is called once per frame
    private IEnumerator PentagramaInstantiate()
    {
        while (true)
        {
            piezasPentagrama[numbInstance].SetActive(true);
            numbInstance++;
            if(numbInstance >= piezasPentagrama.Length)
            {
                break;
            }
            yield return new WaitForSeconds(cd);
        }
    }
}
