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
    public bool djump;
    private bool touchJump;
    private bool touchDJump;
    private bool touchSlide;
    private int score;
    private Vector3 touchPosition;
    private Vector3 slideVector;
    private Vector3 standVector;
    private AudioSource coinSound;
    public AudioClip coin;
    private Vector3 rightLimits, leftLimits;
    private Camera cam;
    public bool isAlive;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        isGrounded = false;
        gravity = new Vector3(0, -15, 0);
        jumpForce = -9/15f * gravity;
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
        isAlive = true;
        //slideVector = c.size / 2;
        //standVector = c.size;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
                rb.velocity *= 0f;
            }
            if (rb.position.x > rightLimits.x)
            {
                position.x = rightLimits.x;
                rb.position = position;
                rb.velocity *= 0f;
            }
        }
        if (rb.velocity.y > 9.0f)
        {
            float newVel;
            newVel = -rb.velocity.y;
            rb.AddForce(new Vector3(rb.velocity.x, newVel, rb.velocity.z));
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
            djump = false;
            touchDJump = false;
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

    void OnDestroy()
    {
        isAlive = false;
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
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
        }
        if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
        {
            if (Input.GetTouch(0).position.y > touchPosition.y)
            {
                touchJump = true;
            }
            //if (Input.GetTouch(0).position.y < touchPosition.y)
            //{
            //    touchSlide = true;
            //}
        }
    }

    void jump()
    {
        if ((Input.GetKey(KeyCode.W) && isGrounded) || (touchJump && isGrounded))
        {
            isGrounded = false;
            touchJump = false;
            rb.AddForce(new Vector3(rb.velocity.x, rb.velocity.y + jumpForce.y, rb.velocity.z), ForceMode.Impulse);
            //if (Input.GetKeyUp(KeyCode.W))
            //{
            //    djump = true;
            //}
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
        //doublejump();
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
        if ((Input.GetKey(KeyCode.W) && djump) || touchDJump)
        {
            touchJump = false;
            rb.velocity = jumpForce * 0;
            djump = false;
            touchDJump = false;
            rb.AddForce(jumpForce * .9f, ForceMode.Impulse);
            if (Input.GetKeyUp(KeyCode.W) || touchDJump)
            {
                djump = false;
                touchDJump = false;
            }
        }
    }

    void move()
    {
        rb.velocity = Input.GetAxis("Horizontal") * movementSpeed;
    }
}
