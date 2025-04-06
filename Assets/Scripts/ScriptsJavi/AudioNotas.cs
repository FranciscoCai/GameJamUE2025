using UnityEngine;

public class AudioNotas : MonoBehaviour
{
    public AudioSource[] notas;
    public AudioSource zona;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayNota()
    {
        notas[Random.Range(0, notas.Length)].Play();
        zona.Play();
    }
}
