using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour
{
    int side = 1;
    public Transform bullet;
    public Transform pivot;
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;

    public Animator animator;

    public bool isJumping;

    private int vidaMaxima = 3;
    private int vida;

    private AudioSource sound;

    [SerializeField] Image vidaOn;
    [SerializeField] Image vidaOff;

    [SerializeField] Image vidaOn2;
    [SerializeField] Image vidaOff2;


    void Start()
    {
        vida = vidaMaxima;
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        Move();
        Jump();

        if (Input.GetKeyDown(KeyCode.D))
            side = 1;
        if (Input.GetKeyDown(KeyCode.A))
            side = -1;

        transform.right = Vector2.right * side;

        if(Input.GetKeyDown(KeyCode.E))
        {
            sound.Play();
           Transform obj = Instantiate(bullet, pivot.position, transform.rotation);
            obj.right = Vector2.right * side;
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Dano();
        }
        if (col.gameObject.CompareTag("pendulo"))
        {
            Dano();
        }
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    private void Dano()
    {
        vida -= 1;

        if(vida == 2)
        {
            vidaOn2.enabled = true;
            vidaOff2.enabled = false;
        }
        else
        {
            vidaOn2.enabled = false;
                vidaOff2.enabled = true;
        }

        if(vida == 1)
        {
            vidaOn2.enabled = true;
            vidaOff2.enabled = false;

            vidaOn.enabled = true;
            vidaOff.enabled = false;
        }
        else
        {
            vidaOn.enabled = false;
            vidaOff.enabled = true;
        }

        if(vida <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

}
