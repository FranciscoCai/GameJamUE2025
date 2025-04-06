using UnityEngine;
using System.Collections;

public class AdioManager : MonoBehaviour
{

    public AudioSource audioOut; // El que se apaga
    public AudioSource audioIn;  // El que entra
    public float fadeDuration = 2f;

    void Start()
    {
        StartCoroutine(CrossfadeAudio());
    }

    private IEnumerator CrossfadeAudio()
    {
        float timer = 0f;

        float startVolumeOut = audioOut.volume;
        float startVolumeIn = 0f;

        audioIn.volume = 0f;
        audioIn.Play();

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;

            audioOut.volume = Mathf.Lerp(startVolumeOut, 0f, t);
            audioIn.volume = Mathf.Lerp(startVolumeIn, 1f, t);

            yield return null;
        }

        audioOut.volume = 0f;
        audioIn.volume = 1f;

        audioOut.Stop();
    }
}
