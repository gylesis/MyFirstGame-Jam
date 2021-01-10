using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour {

    [SerializeField]
    Outline outline;

    [SerializeField]
    string interactMessage;

    public bool outlineIsOn = false;

    virtual public void OnAction() {
        Debug.Log("не работает чумба");
    }

    public void OnEnter() {
        GameManager.TextForInteractableObj.enabled = true;
        GameManager.TextForInteractableObj.text = interactMessage;
        if (outline == null) return;
        outline.enabled = true;
        outlineIsOn = true;
    }

    public void OnExit() {
        GameManager.TextForInteractableObj.enabled = false;
        if (outline == null) return;
        StartCoroutine(OutlineTurningOff());
    }

    IEnumerator OutlineTurningOff() {
        yield return new WaitForSeconds(0.3f);
        outline.enabled = false;
        outlineIsOn = false;
    }
}

