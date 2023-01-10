using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
//    GameObject player;
//    public float speed;
        public float moveSpeed = 2f;
    	public float walkTime = 2f;
    	public float waitTime = 2f;
    	public bool isActive = true;

    	private float walkCounter;
    	private float x_move;
    	private float y_move;
    	private float waitActTime = 0;
    	private bool moving = false;

    	private Rigidbody2D rbody;

    	void Start () {
    		rbody = GetComponent<Rigidbody2D> ();
    		walkCounter = walkTime;
    	}

//    void Start()
//    {
//        player = GameObject.FindWithTag("Player");
//    }
//
//    void Update() {
//        transform.localPosition = Vector3.MoveTowards (transform.localPosition, player.transform.position, Time.deltaTime * speed);
//
//        Vector3 difference = player.transform.position - transform.position;
//        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
//        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);
//    }


	void FixedUpdate () {
		if (isActive) {
			if (moving) {
				Vector3 direction = new Vector3 (x_move, y_move, 0);
				rbody.velocity = direction;
				walkCounter -= Time.deltaTime;
				if (walkCounter <= 0) {
					moving = false;
				}
			} else {
				if (waitActTime <= 0) {
					do {
						x_move = Random.Range (-1, 2) * moveSpeed;
                    	y_move = Random.Range (-1, 2) * moveSpeed;
					} while ((x_move == 0 && y_move == 0));
					MudarFaceMonstro(x_move, y_move);
					walkCounter = walkTime;
					waitActTime = Random.Range (0, waitTime);
					moving = true;
				} else {
					rbody.velocity = Vector2.zero;
					waitActTime -= Time.deltaTime;
				}
			}
		}
	}

	void MudarFaceMonstro(float x, float y) {
		if (x > 0 && y == 0)
			transform.eulerAngles = new Vector3(0, 0, -90);
		else if (x < 0 && y == 0)
			transform.eulerAngles = new Vector3(0, 0, 90);
		else if (x == 0 && y > 0)
			transform.eulerAngles = new Vector3(0, 0, 0);
		else if (x == 0 && y < 0)
			transform.eulerAngles = new Vector3(0, 0, 180);
		else if (x > 0 && y > 0)
			transform.eulerAngles = new Vector3(0, 0, -45);
		else if (x > 0 && y < 0)
			transform.eulerAngles = new Vector3(0, 0, -135);
		else if (x < 0 && y > 0)
			transform.eulerAngles = new Vector3(0, 0, 45);
		else if (x < 0 && y < 0)
			transform.eulerAngles = new Vector3(0, 0, 135);
	}
}


