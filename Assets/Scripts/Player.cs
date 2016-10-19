using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int health = 3;      //the player health

    bool shooting = false;
    Animator anim;

    public float speed;
    public float jumpDistance;
    public GameObject gun;
    public GameObject bullet;

    Rigidbody2D rb;

    public enum PlayerState
    {
        running,

        shooting,

        jumping
    }

    public PlayerState state = PlayerState.running;


	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //moves player right
        transform.position += transform.right * speed * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (state == PlayerState.running)
            {
                //transform.position += transform.up * jumpDistance * Time.deltaTime;
                rb.AddForce(Vector2.up * jumpDistance);

                state = PlayerState.jumping;
            }
            else if (state == PlayerState.jumping)
            {
                Instantiate(bullet, gun.transform.position, Quaternion.identity);
                shooting = true;
                anim.SetBool("shooting", shooting);
            }
        }

        switch(state)
        {
            case PlayerState.running:
                shooting = false;
                anim.SetBool("shooting", shooting);
                break;
            case PlayerState.shooting:
                shooting = true;
                anim.SetBool("shooting", shooting);
                break;
        }
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.collider.CompareTag("Ground"))
        {
            state = PlayerState.running;
            Debug.Log("derp");
        }
    }
}
