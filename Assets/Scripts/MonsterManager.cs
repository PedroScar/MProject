using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {

    public int maxHealth = 20;
    public int currentHealth;
    public int attack = 1;

    public GameObject TextoDano;

    void Start() {
        currentHealth = maxHealth;
    }

    public void DamageMonster(int damage) {
        currentHealth -= damage;

        var clone = (GameObject)Instantiate(TextoDano, transform.position, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<FloatingText>().texto = $"{damage}";
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Player") {
            other.gameObject.GetComponent<PlayerManager>().DamagePlayer(attack);
        }
    }
}
