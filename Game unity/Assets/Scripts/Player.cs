using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rig;
    private Animator Animacao;

    public bool isJumping;



    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float Movement = Input.GetAxis("Horizontal");

        // funciona ~~

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);  
        transform.position += movement * Time.deltaTime * Speed;

        // n funciona ~~

         //Rig.velocity = new Vector2(Movement * Speed, Rig.velocity.y);

        // vou testar ~~

        //float moveHorizontal = Input.GetAxis ("Horizontal");

        //Vector2 movement = new Vector2(moveHorizontal, 0);

        //Rig.AddForce(movement * Speed);

        if (Movement > 0f)
        {
            Animacao.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Movement < 0f)
        {
            Animacao.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            Animacao.SetBool("Walk", false);
        }

    }


    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isJumping == false)
        {
            Rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            Animacao.SetBool("Jump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.layer == 8)
        {
            isJumping = false;
            Animacao.SetBool("Jump", false);
        }

        if (colisao.gameObject.tag == "Spike" || colisao.gameObject.tag == "Saw")  
        {
            GameController.instance.GameOver();
            Destroy(gameObject);
        }
    } 

    void OnCollisionExit2D(Collision2D colisao)
    {
        if (colisao.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
