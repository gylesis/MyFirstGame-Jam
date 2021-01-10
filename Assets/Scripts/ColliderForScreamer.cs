using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderForScreamer : MonoBehaviour {
    [SerializeField]
    Screamer screamer;

    bool isActivated = false;

    private void OnTriggerEnter(Collider other) {
        if (!isActivated) {
            screamer.OnStepInCollider();
            isActivated = true;
        }
    }

}
