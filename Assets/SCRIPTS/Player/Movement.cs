using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Text scoreText;
    public bool isGrounded;
    public Vector3 gravity;
    public Vector3 jumpForce;
    public Vector3 movementSpeed;
    private Rigidbody rb;
    private CapsuleCollider c;
    private bool djump;
    private bool touchJump;
    private bool touchSlide;
    private int score;
    private Vector3 touchPosition;
    private Vector3 slideVector;
    private Vector3 standVector;
    private AudioSource coinSound;
    public AudioClip coin;
    private Vector3 rightLimits, leftLimits;
    private Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        isGrounded = false;
        gravity = new Vector3(0, -15, 0);
        jumpForce = -8/15f * gravity;
        movementSpeed = new Vector3(15, 0, 0);
        rb = GetComponent<Rigidbody>();
        c = GetComponent<CapsuleCollider>();
        djump = false;
        score = 0;
        coinSound = GetComponent<AudioSource>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        leftLimits = cam.ScreenToWorldPoint(new Vector3(6 * Screen.width / 20, 0, 0));
        rightLimits = cam.ScreenToWorldPoint(new Vector3(19 * Screen.width / 20, 0, 0));
        rb.position = cam.ScreenToWorldPoint(new Vector3(14 * Screen.width / 20, Screen.height / 2, 1));
        //slideVector = c.size / 2;
        //standVector = c.size;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(rb.velocity);
        scoreText.text = "Score: " + score;
        if (Input.touchCount > 0)
        {
            checkTouchInput();
        }
        jump();
        slide();
        //rb.AddForce(gravity, ForceMode.Impulse);
        rb.AddForce(new Vector3(rb.velocity.x, rb.velocity.y + gravity.y * Time.deltaTime, rb.velocity.z), ForceMode.VelocityChange);
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + gravity.y * (Time.deltaTime * Time.deltaTime), rb.velocity.z);
        if (rb.position.x >= leftLimits.x && rb.position.x <= rightLimits.x)
        {
            move();
        }
        else
        {
            Vector3 position = rb.position;
            if (rb.position.x < leftLimits.x)
            {
                position.x = leftLimits.x;
                rb.position = position;
            }
            if (rb.position.x > rightLimits.x)
            {
                position.x = rightLimits.x;
                rb.position = position;
            }
        }
        //if (isGrounded)
        //{
        //    gravity = new Vector2(0, -1);
        //}
    }

    void OnCollisionEnter(Collision col)
    {
        //gravity = new Vector2(0, -1);
        //if(col.contacts.Length<0)
        //{
        //    var contact = col.contacts[0];
        //    if(Vector3.Dot(contact.normal, Vector3.up)>0.5)
        //    {
        //        isGrounded = true;
        //    }
        //}
        if ((this.transform.position.y - col.transform.position.y) > 0)
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinSound.PlayOneShot(coin);
            score++;
        }
        if(other.tag=="Ground")
        {
            isGrounded = false;
        }
    }

    //void OnCollisionStay(Collision col)
    //{
    //    if (col.gameObject.tag == "Ground")
    //        isGrounded = true;
    //}

    //void OnCollisionExit(Collision col)
    //{
    //    //if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform")
    //    //{
    //        isGrounded = false;
    //        djump = true;
    //    //}
    //}

    void checkTouchInput()
    {
    //    if (Input.GetTouch(0).phase == TouchPhase.Began)
    //    {
    //        touchPosition = Input.GetTouch(0).position;
    //    }
    //    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
    //    {
    //        if (Input.GetTouch(0).position.y > touchPosition.y)
    //        {
    //            touchJump = true;
    //        }
    //        if (Input.GetTouch(0).position.y < touchPosition.y)
    //        {
    //            touchSlide = true;
    //        }
    //    }
    }

    void jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) && isGrounded) || touchJump)
        {
            isGrounded = false;
            touchJump = false;
            rb.AddForce(jumpForce, ForceMode.Impulse);
            //rb.AddForce(new Vector3(rb.velocity.x, rb.velocity.y + jumpForce.y * Time.deltaTime, rb.velocity.z), ForceMode.VelocityChange);
        }
        //if (Input.GetKey(KeyCode.W) && !isGrounded && rb.velocity.y < 30)
        //{
        //    gravity *= 1.02f;
        //    rb.AddForce(5 * jumpForce, ForceMode.Acceleration);
        //}
        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    gravity = new Vector2(0, -1);
        //}
        //if (!isGrounded)
        //{
        //    rb.AddForce(gravity, ForceMode.Impulse);
        //}
        doublejump();
    }

    void slide()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                c.height = c.height / 2;
            }
            if(Input.GetKeyUp(KeyCode.S))
            {
                c.height = c.height * 2;
            }
        }
    }

    void doublejump()
    {
        if ((Input.GetKeyDown(KeyCode.W) && djump && !isGrounded) || touchJump)
        {
            touchJump = false;
            rb.velocity = jumpForce * 0;
            djump = false;
            rb.AddForce(jumpForce * .9f, ForceMode.Impulse);
        }
    }

    void move()
    {
        rb.velocity = Input.GetAxis("Horizontal") * movementSpeed;
    }
}
