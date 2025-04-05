using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;

public class CinematicaCamara : MonoBehaviour
{
    public Transform cinematicCam;
    private Vector3 camStartRot;         
    public float rotationDuration = 7f;

    public Transform followTarget;          
    public float followDelay = 5f;          
    public float cinematicDuration = 25f;

    private bool following = false;

    void Start()
    {
        camStartRot = cinematicCam.eulerAngles;
        StartCoroutine(PlayCinematic());
    }

    private IEnumerator PlayCinematic()
    {
        float timer = 0f;
        Vector3 direction = followTarget.position - cinematicCam.position;
        Quaternion startRot = cinematicCam.rotation;
        Quaternion endRot = Quaternion.LookRotation(direction);

        Vector3 startPos = cinematicCam.position;
        
        yield return new WaitForSeconds(2f);

        while (timer < rotationDuration)
        {
            timer += Time.deltaTime;
            float t = timer / rotationDuration;
            float smoothT = Mathf.SmoothStep(0f, 1f, t);
            

            cinematicCam.rotation = Quaternion.Slerp(startRot, endRot, smoothT);
            yield return null;
        }

        yield return new WaitForSeconds(followDelay);
        following = true;
    }

    void LateUpdate()
    {
        if (following && followTarget != null)
        {
            cinematicCam.position = Vector3.Lerp(cinematicCam.position, followTarget.position + new Vector3(0, 2, -5), Time.deltaTime * 2f);
            cinematicCam.LookAt(followTarget.position + Vector3.up * 1f);
        }
    }
}
