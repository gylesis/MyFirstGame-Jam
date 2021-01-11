using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaMachine : InteractableObject {

    [SerializeField]
    GameObject sodaPrefab;

    [SerializeField]
    Vector3 posToSpawn;

    public override void OnAction() {
        Destroy(Instantiate(sodaPrefab, posToSpawn, Quaternion.Euler(0, 0, 90)), 5f);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(posToSpawn, 0.1f);
    }
}
