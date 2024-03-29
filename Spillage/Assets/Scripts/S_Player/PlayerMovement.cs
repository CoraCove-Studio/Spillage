using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerControl pc;
    [SerializeField] private int speed;
    [SerializeField] private int lookSpeed;
    [SerializeField] private int jumpForce;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pc = new PlayerControl();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
        isGrounded = false;
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 _ = inputValue.Get<Vector2>();
        Vector3 movement = new(_.x * speed, 0, _.y * speed);
        print(movement);
        rb.AddForce(movement);
    }

    private void OnLook(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        Vector3 torque = new(0, inputVector.x * lookSpeed, 0);

        // Apply torque to the Rigidbody
        rb.AddTorque(torque, ForceMode.Force);
    }

    public void Grounded()
    {
        if (isGrounded == false)
        {
            isGrounded = true;
        }
    }

}
