using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    private static Text textForInteractableObj;

    public static Text TextForInteractableObj {

        get {
            return textForInteractableObj;
        }

        set {
            textForInteractableObj = value;
        }
    }

    private void Start() {
       // Cursor.lockState = CursorLockMode.Locked;
      //  Cursor.visible = false;
        Instance = this;
        textForInteractableObj = transform.Find("InteractMessage").GetComponent<Text>();
    }

    void Update()
    {

    }
}
