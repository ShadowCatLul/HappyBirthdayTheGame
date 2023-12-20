using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ground Check")]
    public float playerHeight;
    public float groundDrag;
    public LayerMask Ground;
    private bool grounded;
    
    
    [Header("Movement")]
    public Rigidbody rb;
    public Transform orientation;
    private Vector3 moveDirection;
    public float moveSpeed = 1f;

    [Header("Jump")]
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce;
    private bool rdyToJump;


    public Texture2D cursor;
    
    
    void Start()
    {



        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rdyToJump = true;

    }
 
    void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight, Ground);
        
        Movement();
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
        Debug.DrawRay(transform.position, Vector3.down*playerHeight, Color.green);
        if (Input.GetKey(jumpKey) && rdyToJump && grounded)
        {

            rdyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), 1);
        }
    }

    

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up*jumpForce, ForceMode.Impulse);
        Debug.Log("Jump");
    }

    private void ResetJump()
    {
        rdyToJump= true;
    }

}
