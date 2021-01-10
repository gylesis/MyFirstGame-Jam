using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : InteractableObject {

    [SerializeField]
    protected int number;

    public override void OnAction() {
        Debug.Log(number);
    }
}
