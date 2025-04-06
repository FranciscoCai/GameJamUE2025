using UnityEngine;

public class AdioManager : MonoBehaviour
{

    public AudioSource audioOut; // El que se apaga
    public AudioSource audioIn;  // El que entra
    public float fadeDuration = 2f;

    void Start()
    {
        
    }

    public void StartCrossfade()
    {
        StartCoroutine(CrossfadeAudio());
    }

    private IEnumerator CrossfadeAudio()
    {
        float timer = 0f;

        float startVolumeOut = audioOut.volume;
        float startVolumeIn = 0f;

        audioIn.volume = 0f;
        audioIn.Play(); // ?? empieza a sonar desde el principio de la conversi�n

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;

            audioOut.volume = Mathf.Lerp(startVolumeOut, 0f, t);
            audioIn.volume = Mathf.Lerp(startVolumeIn, 1f, t);

            yield return null;
        }

        // Asegura que los vol�menes queden exactos al final
        audioOut.volume = 0f;
        audioIn.volume = 1f;

        // (Opcional) Detener el audio que sali�
        audioOut.Stop();
    }
}
