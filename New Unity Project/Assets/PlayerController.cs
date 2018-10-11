using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Altura;
    public float score = 0;
    public float speed = 10f;
    public float maxSpeed = 5f;
    public bool grounded;
    public float jumpPower = 10f;
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;
    

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Altura", rb2d.velocity.y);
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            jump = true;
        }

    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (jump )
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        //Debug.Log(rb2d.velocity.x);
        
        //Debug.Log();
        

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "chest")
        {
            Destroy(col.gameObject);
            score = score + 1;
            Debug.Log(score);
        }
    }

   

}

