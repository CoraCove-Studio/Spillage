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
        print("Jump");
    }

    public void Grounded()
    {
        if (isGrounded == false)
        {
            isGrounded = true;
        }
    }

}
