using System.Collections;
using UnityEngine;

public class CambioCamaraUltimaNota : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;
    public float stopDistance = 0.01f;

    public IEnumerator CambioCamara()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, target.position) > stopDistance)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    target.position,
                    moveSpeed * Time.deltaTime
                );

                // Rotar suavemente hacia la rotaci¨®n del target
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    target.rotation,
                    rotateSpeed * Time.deltaTime
                );
            }
            else
            {
                // Asegura que la posici¨®n y rotaci¨®n sean exactamente iguales al llegar
                transform.position = target.position;
                transform.rotation = target.rotation;
            }
            moveSpeed += Time.deltaTime*10f;
            yield return null;
        }
    }
}
