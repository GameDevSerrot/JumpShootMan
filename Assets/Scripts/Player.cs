using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int health = 3;      //the player health

    public float speed;
    public float jumpDistance;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        transform.position += transform.right * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.up * jumpDistance * Time.deltaTime;
        }
	
	}
}
