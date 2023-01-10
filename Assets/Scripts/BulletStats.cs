using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour {
    public float speed;
    public int damage;

    void Start() {
        GameObject location = GameObject.FindWithTag("BulletPoint");
        transform.rotation = location.transform.rotation;
    }

    void Update() {
        transform.Translate(new Vector3(0, speed * Time.deltaTime));
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<MonsterManager>().DamageMonster(damage);
        }

        Destroy(gameObject);
    }
}
