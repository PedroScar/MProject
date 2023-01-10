using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTrackManager : MonoBehaviour {
    private static bool trackManagerExists;
    public AudioSource audioSource;

    void Start() {
        audioSource.Play();

        if (trackManagerExists)
            Destroy(gameObject);
        else
            trackManagerExists = true;
        DontDestroyOnLoad(gameObject);
    }
}