using UnityEngine;
using UnityEngine.InputSystem;

public class PulsaStart : MonoBehaviour
{
    public InputActionReference boostAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isPressing = boostAction.action.IsPressed();

    }
}
