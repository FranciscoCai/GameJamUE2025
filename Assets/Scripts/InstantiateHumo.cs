using System.Collections;
using UnityEngine;

public class InstantiateHumo : MonoBehaviour
{
    public GameObject humo;
    public Transform instanceTransform;
    public float cd;
    void Start()
    {
        StartCoroutine(InstanceHumoCD());
    }

    private IEnumerator InstanceHumoCD()
    {
        while (true)
        {
            Instantiate(humo, instanceTransform.position, instanceTransform.rotation);
            yield return new WaitForSeconds(cd);
        }
    }
}
