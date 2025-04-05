using UnityEngine;
using UnityEngine.InputSystem;

public class VueloDeBeluga : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference lookAction;
    public InputActionReference boostAction;

    [Header("Camera")]
    public Transform cam;
    public Vector3 camOffset = new Vector3(0, 3, -6);
    private Vector3 initialCamOffset = new Vector3(0, 3, -6);
    public float camSmoothSpeed = 5f;

    [Header("Free Look Settings")]
    public float lookSensitivity = 2f;
    public float maxLookAngleX = 45f; // izquierda/derecha
    public float maxLookAngleY = 20f; // arriba/abajo
    public float returnSpeed = 5f;

    private Vector2 lookOffset = Vector2.zero;

    [Header("Drone Settings")]
    public float forwardSpeed;
    private float currentSpeed;
    public float boostMultiplier = 2f;
    public float verticalSpeed = 5f;
    public float turnSpeed = 60f;
    public float rotateVelocity;
    public float CameraYVelocity;

    public float maxOffsetX = 3f;
    public float minOffsetX = 2f;
    public float maxOffsetY = 3f;
    public float minOffsetY = 2f;

    [Header("Model Reference")]
    public Transform droneModel;

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
        initialCamOffset = camOffset;
    }

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        bool isBoosting = boostAction.action.IsPressed();
        float targetSpeed = isBoosting ? forwardSpeed * boostMultiplier : forwardSpeed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, 10 * Time.deltaTime);

        float vertical = input.y * verticalSpeed * Time.deltaTime;
        transform.position += Vector3.up * vertical;
        transform.position += transform.forward * currentSpeed * Time.deltaTime;
        float turn = input.x * turnSpeed * Time.deltaTime;
        transform.Rotate(0f, turn, 0f);

        if (cam != null)
        {
            Vector2 lookInput = lookAction.action.ReadValue<Vector2>();

            if (lookInput.sqrMagnitude > 0.01f)
            {
                // Acumula el movimiento del stick derecho para desplazar la cámara
                lookOffset += lookInput * lookSensitivity;
                lookOffset.x = Mathf.Clamp(lookOffset.x, -maxLookAngleX, maxLookAngleX);
                lookOffset.y = Mathf.Clamp(lookOffset.y, -maxLookAngleY, maxLookAngleY);
            }
            else
            {
                // Vuelve al centro suavemente
                lookOffset = Vector2.Lerp(lookOffset, Vector2.zero, Time.deltaTime * returnSpeed);
            }

            // Calcula rotación de la cámara
            Quaternion lookRotation = Quaternion.Euler(-lookOffset.y, lookOffset.x, 0);
            Vector3 desiredPosition = transform.position + (lookRotation * (transform.rotation * camOffset));
            cam.position = Vector3.Lerp(cam.position, desiredPosition, camSmoothSpeed * Time.deltaTime);
            cam.LookAt(transform.position + Vector3.up * 1.5f);
        }
    }

    void LateUpdate()
    {
        if (droneModel != null)
        {
            Vector3 movementDir = transform.position - lastPosition;
            if (movementDir.sqrMagnitude > 0.00075f)
            {
                Quaternion targetRot = Quaternion.LookRotation(movementDir.normalized, Vector3.up);

                // Leer el input horizontal para inclinar
                float rollAmount = moveAction.action.ReadValue<Vector2>().x;
                float maxRoll = 45f; // grados de inclinación máxima
                float roll = -rollAmount * maxRoll; // inclinación izquierda/derecha

                // Aplicar roll (rotación en Z)
                Quaternion rollRotation = Quaternion.AngleAxis(roll, Vector3.forward);
                targetRot *= rollRotation;


                // Aplicar rotación suavemente
                droneModel.rotation = Quaternion.Slerp(droneModel.rotation, targetRot, Time.deltaTime * rotateVelocity);
            }
            if (moveAction.action.ReadValue<Vector2>().sqrMagnitude > 0.1f)
            {
                float highAmount = moveAction.action.ReadValue<Vector2>().y;
                camOffset = new Vector3(camOffset.x, Mathf.Clamp(camOffset.y - highAmount * Time.deltaTime * CameraYVelocity, minOffsetY, maxOffsetY), camOffset.z);

                float rollAmount = moveAction.action.ReadValue<Vector2>().x;
                camOffset = new Vector3(Mathf.Clamp(camOffset.x - rollAmount * Time.deltaTime * CameraYVelocity, minOffsetX, maxOffsetX), camOffset.y, camOffset.z);
            }
            else
            {
                camOffset = Vector3.Lerp(camOffset, initialCamOffset, 2 * Time.deltaTime);
            }

            lastPosition = transform.position;
        }
    }
}
