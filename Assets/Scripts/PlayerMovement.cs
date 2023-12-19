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
    
    [Header("Camera")]
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    public Transform orientation;
    public Camera Camera;
    [Header("Movement")]
    public Rigidbody rb;

    private Vector3 moveDirection;
    public float moveSpeed = 1f;

    [Header("Jump")]
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce;
    private bool rdyToJump;

    
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rdyToJump = true;

    }
 
    void FixedUpdate()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight, Ground);
        CameraRotation();
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

    private void CameraRotation()
    {
   
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;    
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        Camera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);        
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
