using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPositionFix : MonoBehaviour {
    public bool invertX = false;
    public float adjustmentX;
    [Space]
    public bool invertY = false;
    public float adjustmentY;

    void Start() {
        RectTransform rt = GetComponent<RectTransform>();
        Vector3 pos = transform.position;


        if (invertX)
            pos.x = pos.x + (Screen.width / adjustmentX);
        else
            pos.x = pos.x - (Screen.width / adjustmentX);

        if (invertY)
            pos.y = pos.y + (Screen.height / adjustmentY);
        else
            pos.y = pos.y - (Screen.height / adjustmentY);

        transform.position = pos;
    }
}
