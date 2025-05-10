using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 120f;

    float xRotation = 0f;

    void Start()
    {
        // قفل کردن و نامرئی کردن موس
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // ورودی موس
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // کم و زیاد کردن چرخش عمودی
        xRotation -= mouseY;

        // محدود کردن دقیق زاویه‌ها
        xRotation = Mathf.Clamp(xRotation, -31.94f, 11f);

        // اعمال چرخش دوربین
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // چرخش بدنه به چپ و راست
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

