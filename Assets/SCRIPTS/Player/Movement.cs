using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Text scoreText;
    public bool isGrounded;
    private Vector2 gravity;
    private Vector2 jumpForce;
    public Vector2 movementSpeed;
    private Rigidbody rb;
    private CapsuleCollider c;
    private bool djump;
    public bool touchJump;
    public bool touchSlide;
    private int score;
    public Vector3 touchPosition;
    Vector3 slideVector;
    Vector3 standVector;
    public AudioSource coinSound;
    public AudioClip coin;

    // Use this for initialization
    void Start()
    {
        isGrounded = false;
        gravity = new Vector2(0, -1);
        jumpForce = -12 * gravity;
        rb = GetComponent<Rigidbody>();
        c = GetComponent<CapsuleCollider>();
        djump = false;
        score = 0;
        coinSound = GetComponent<AudioSource>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        //slideVector = c.size / 2;
        //standVector = c.size;

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        if (Input.touchCount > 0)
        {
            checkTouchInput();
        }
        jump();
        slide();
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-15, 0, 0);
        }
        if (isGrounded)
        {
            gravity = new Vector2(0, -1);
        }
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
    }

    //void OnCollisionStay(Collision col)
    //{
    //    if (col.gameObject.tag == "Ground")
    //        isGrounded = true;
    //}

    void OnCollisionExit(Collision col)
    {
        //if (col.gameObject.tag == "Ground")
        //{
        isGrounded = false;
        djump = true;
        //}
    }

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
            touchJump = false;
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W) && !isGrounded && rb.velocity.y < 30)
        {
            gravity *= 1.02f;
            rb.AddForce(5 * jumpForce, ForceMode.Acceleration);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            gravity = new Vector2(0, -1);
        }
        if (!isGrounded)
        {
            rb.AddForce(gravity, ForceMode.Impulse);
        }
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
}
