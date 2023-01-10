using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float cam_speed = 0.1f;
    Camera mycam;
    private static bool camExists;

    void Start() {
        mycam = GetComponent<Camera>();
        if (camExists)
            Destroy(gameObject);
        else
            camExists = true;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (target)
            transform.position = Vector3.Lerp(transform.position, target.position, cam_speed) + new Vector3(0, 0, -10);
    }
}
