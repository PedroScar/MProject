using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int maxHealth;
    int currentHealth;
    public bool isActive = false;
    public float delay;
    public GameObject bulletPoint;
    public GameObject cabin;
    public GameObject bullet;
    public Joystick joystick;
    float actualDelay;
    bool startShoting;
    private static bool playerExists;

    void Start() {
        currentHealth = maxHealth;

        if (playerExists)
            Destroy(gameObject);
        else
            playerExists = true;
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        if (isActive) {
            Vector2 movement = new Vector2(joystick.Horizontal, joystick.Vertical);

            if (movement != Vector2.zero) {
                Vector3 dir = -movement;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                cabin.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            }

            if (actualDelay < delay && startShoting) {
                actualDelay += Time.deltaTime;

            } else if (startShoting) {
                actualDelay = 0f;
                Shot();
            }

        }
    }

    void Shot() {
        Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);
    }

    public void StartShoting() {
        if (isActive) {
            startShoting = true;
        }
    }

    public void StopShoting() {
        startShoting = false;
    }

    public void DamagePlayer(int damage) {
        currentHealth -= damage;

        if (currentHealth > 0) {
            // currentHealth -= damage;
            // Instantiate(damageBurst, transform.position, transform.rotation);
            // var clone = (GameObject)Instantiate(damageNumber, transform.position, Quaternion.Euler(Vector3.zero));
            // clone.GetComponent<FloatingNumbers>().damageNumber = damage;
            // StartCoroutine("HurtColor");
        }
    }
}
