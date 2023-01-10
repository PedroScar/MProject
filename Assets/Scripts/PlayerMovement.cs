using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public bool isActive = false;
	public float speed = 5f;
	public Joystick joystick;

	Animator anim;
	Rigidbody2D rbody;

	void Start () {		
		anim = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (isActive) {
		}
	}

	void FixedUpdate () {
		if (isActive) {
            Vector2 movement = new Vector2 (joystick.Horizontal, joystick.Vertical);

            if (movement != Vector2.zero) {
                Vector3 dir = -movement;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

                anim.SetBool ("isWalking", true);
            } else {
                anim.SetBool ("isWalking", false);
            }

            rbody.MovePosition (rbody.position + movement * Time.deltaTime * speed);
		}
	}
}
