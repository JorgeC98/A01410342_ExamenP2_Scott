using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed = 2f;
    public float maxSpeed = 5f;
    private Rigidbody2D rb2d;
    private Animator anim;
    public bool grounded;
    public float jumpPower = 6.5f;
    private bool jump;
    private bool movement = true;
    private SpriteRenderer spr;
    private HealthBar healthbar;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        healthbar = FindObjectOfType<HealthBar>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            jump = true;
        }

        
    }

    void FixedUpdate()
    {
        //aqui es para que el personaje se mueva
        float h = Input.GetAxis("Horizontal");

        if (!movement) h = 0;

        rb2d.AddForce(Vector2.right * speed * h);

        //Esto es para que el personaje no vaya tan rapido
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        Vector3 FixedVelocity = rb2d.velocity;
        FixedVelocity.x *= 0.75f;

        if (grounded)
        {
            rb2d.velocity = FixedVelocity;
        }

        //esto es para el el personaje se voltie para la izq o derecha
        if (h>0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }

    public void EnemyKnockBack(float enemyPosX)
    {

        healthbar.TakeDamage(50f);

        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);

        movement = false;
        Invoke("EnableMovement", 0.7f);

        Color color = new Color(255 / 255f, 106 / 255f, 0 / 255f);
        spr.color = color;
    }

    void OnBecameInvisible()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;
    }

    public void EnemyJump()
    {
        jump = true;
    }
}
