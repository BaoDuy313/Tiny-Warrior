using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float MoveForce = 20f;
    public float MaxVelocity = 5f;
    public float Jumpforce = 260f;
    public static bool grounded = true;

    private Rigidbody2D mybody;
    private Animator anim;

    public AudioSource audioSource;
    public AudioClip audioJump;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float forceX = 0;
        float forceY = 0;

        float vel = Mathf.Abs(mybody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");
        if (!PlayerDie.playIsDead)
        {
            if (vel < MaxVelocity)
            {
                Vector3 temp = transform.localScale;
                if (h > 0.1f)
                {
                    temp.x = -1f;
                    forceX = MoveForce;
                    anim.SetBool("Walk", true);
                }
                else if (h < -0.1f)
                {
                    temp.x = 1f;
                    forceX = -MoveForce;
                    anim.SetBool("Walk", true);
                }
                else //đứng yên
                {
                    anim.SetBool("Walk", false);
                }

                transform.localScale = temp;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (grounded)
                {
                    forceY = Jumpforce;
                    audioSource.PlayOneShot(audioJump);

                    anim.SetBool("Jump", true);
                }
                else
                {
                    anim.SetBool("Jump", false);
                }
            }

            mybody.AddForce(new Vector2(forceX, forceY));
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
}
