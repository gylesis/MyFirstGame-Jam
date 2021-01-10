using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisual : MonoBehaviour {

    [SerializeField]
    GameObject cursor;

    void Update() {
        cursor.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }
}
