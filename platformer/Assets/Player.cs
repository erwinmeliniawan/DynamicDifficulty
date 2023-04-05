using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    Rigidbody2D rb;

    public float jumpForce;
    bool isGrounded;
    public Transform goundDetector;
    public LayerMask whatisground;

    public GameObject tall;
    private Vector3 respawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        PlayerMovement();
        DetecGround();

    }

    public void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
   
        //Move Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180); //flip the character on its x axis
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, 0f);
        }
    }

    public void DetecGround()
    {
        isGrounded = Physics2D.OverlapCircle(goundDetector.position, 1, whatisground);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "tall")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
        }
    }

}
