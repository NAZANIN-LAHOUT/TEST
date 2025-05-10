using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FixedPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");


            input = new Vector3(horizontal, 0f, vertical).normalized;
        }

        void FixedUpdate()
        {
            Vector3 move = input * moveSpeed * Time.fixedDeltaTime;
            Vector3 newPosition = rb.position + transform.TransformDirection(move);

            rb.MovePosition(newPosition);
        }
    }
}
