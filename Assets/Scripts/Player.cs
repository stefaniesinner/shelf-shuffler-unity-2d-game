using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player obj;

    public int lives = 3;
    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isImmune = false;

    public float speed = 5f;
    public float jumpForce = 3;
    public float moveHorizontal;

    public LayerMask groundLayer;
    public float radius = 0.3f;
    public float groundRayDist = 0.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    private void Awake()
    {
        obj = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        isMoving = (moveHorizontal != 0);

        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);

        Flip(moveHorizontal);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (!isGrounded) return;

        rb.velocity = Vector2.up * jumpForce;
    }

    private void Flip(float _xValue)
    {
        Vector3 theScale = transform.localScale;

        if (_xValue < 0)
            theScale.x = Mathf.Abs(theScale.x) * -1;
        else if (_xValue > 0)
            theScale.x = Mathf.Abs(theScale.x);

        transform.localScale = theScale;
    }

    private void OnDestroy()
    {
        obj = null;
    }


}
