using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 120f;

    float xRotation = 0f;

    void Start()
    {
      
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
    
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

      
        xRotation -= mouseY;

     
        xRotation = Mathf.Clamp(xRotation, -31.94f, 11f);

      
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

