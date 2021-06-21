using UnityEngine;

public class P_Moves : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public float groundChekRadius;

    private float horizontalMovement;

    private bool isJumping;
    private bool isGrounded;

    public Transform groundChek;

    public LayerMask collisionLayers;

    public Rigidbody2D rb;

    private Vector3 velocity = Vector3.zero;





    void Update ()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
            //chrono.StartChrono();
        }
    }
    
    void FixedUpdate ()
    {
       
        isGrounded = Physics2D.OverlapCircle(groundChek.position, groundChekRadius, collisionLayers);
        
        MovePlayer(horizontalMovement);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
    }

    public void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundChek.position, groundChekRadius);
    }

}