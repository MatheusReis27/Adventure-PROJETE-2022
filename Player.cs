using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private SpriteRenderer sr ;
    private CircleCollider2D circle;
    private BoxCollider2D box;
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    private Rigidbody2D rig;
    private Animator anim;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource hitSound;
    
    
 
    

    // Start is called before the first frame update
    void Start()
    {
        
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        box = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        move();
        Jump(); 
        
        
        
    }
    
    void move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    
        if(Input.GetAxis("Horizontal") > 0f)
        {
            
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3 (0f,0f,0f);
        }

        if(Input.GetAxis("Horizontal") < 0f)
        {
            
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3 (0f,180f,0f);
        }

        if(Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("run", false);
        }
        
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                jumpSound.Play();
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if(doubleJump)
                {
                    jumpSound.Play();
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            
            }
            
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
        if(collision.gameObject.tag == "Spike")
        {
            hitSound.Play();
            GameController.instance.ShowGameOver();
            sr.enabled = false;
            circle.enabled = false;
            box.enabled = false;
            Speed = 0;
        }
        if(collision.gameObject.tag == "Saw")
        {
            hitSound.Play();
            GameController.instance.ShowGameOver();
            sr.enabled = false;
            circle.enabled = false;
            box.enabled = false;
            Speed = 0;
        }
        

        
    }
    void OnCollisionExit2D(Collision2D collision)
    {
         if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
