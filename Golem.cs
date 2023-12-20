using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Golem : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    public float speed;
    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;
    private bool colliding;
    public LayerMask layer;
    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;
    private SpriteRenderer sr;
    [SerializeField] private AudioSource hitSound;
    
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

   
    void Update()
    {
        rig.velocity = new Vector2(speed , rig.velocity.y);
        colliding = Physics2D.Linecast(rightCol.position , leftCol.position,layer);

        if(colliding)
        {
            transform.localScale =  new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }
    bool playerDestroyed;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y;
            if(height > 0 && !playerDestroyed)
            {
                hitSound.Play();
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10 , ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject , 0.88f);
            }
            else
            {
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                sr.enabled = false;
                circleCollider2D.enabled = false;
                boxCollider2D.enabled = false;
                speed = 0;
            }
        }
    }
}
