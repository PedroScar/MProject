using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {
    public string AbrirCena;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Player") {
            SceneManager.LoadScene(AbrirCena);
        }
    }
}
