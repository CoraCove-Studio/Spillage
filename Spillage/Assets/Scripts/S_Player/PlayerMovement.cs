using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerControl pc;
    [SerializeField] private int speed;
    [SerializeField] private int strafeSpeed;
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
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 _ = inputValue.Get<Vector2>();
        Vector3 movement = new(_.x * speed, 0, _.y * speed);
        print(movement);
        rb.AddForce(movement);

    }

    public void Grounded()
    {
        if (isGrounded == false)
        {
            isGrounded = true;
        }
    }

}
