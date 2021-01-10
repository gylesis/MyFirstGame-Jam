using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour {

    [SerializeField]
    Outline outline;

    string interactMessage;

    virtual public void OnAction() {
        Debug.Log("не работает чумба");
    }

    public void OnEnter() {
        if (outline == null) return;
        outline.enabled = true;
    }

    public void OnExit() {
        if (outline == null) return;
        OutlineTurningOff();
    }

    IEnumerator OutlineTurningOff() {
        yield return new WaitForSeconds(0.3f);
        outline.enabled = false;
    }
}

