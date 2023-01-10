using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUI : MonoBehaviour {
    
    private static bool uiExist;

    void Start() {
        if (uiExist)
            Destroy(gameObject);
        else
            uiExist = true;
        DontDestroyOnLoad(gameObject);
    }
}
