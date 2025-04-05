
using UnityEngine;
using UnityEngine.InputSystem; 

public class Vibración : MonoBehaviour
{
    public Transform player;            
    public float maxDistance = 20f;   
    public float vibrationIntensity = 0.5f; 

    private Gamepad gamepad;

    void Update()
    {
        if (player == null) return;

        if (gamepad == null)
            gamepad = Gamepad.current;

        if (gamepad == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < maxDistance)
        {
  
            float intensity = Mathf.Lerp(vibrationIntensity, 0f, distance / maxDistance);
            gamepad.SetMotorSpeeds(intensity, intensity); 
        }
        else
        {
          
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }

    void OnDisable()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0f, 0f); 
        }
    }
}
