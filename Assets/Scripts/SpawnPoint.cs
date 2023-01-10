using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    void Start() {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = transform.position;

        GameObject myCamera = GameObject.FindWithTag("MainCamera");
        myCamera.transform.position = new Vector3(transform.position.x, transform.position.y, myCamera.transform.position.z);
    }
}
