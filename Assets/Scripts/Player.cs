using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour { 

    [SerializeField]
    Camera camera;

    InteractableObject interactableObject;

    [SerializeField]
    Rigidbody rb;

    public bool canMove = true;

    [SerializeField]
    float moveSpeed = 2f;

    private void Start() {
        Initialization();
    }

    void Update() {
      //  RayCasting();
        Movement();
    }

    void Initialization() {
    
    }


    void Movement() {
      //  if (canMove) {
            var movePos = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            movePos *= moveSpeed * Time.deltaTime;

            rb.AddForce(movePos,ForceMode.VelocityChange);

       // }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Ground") {
            canMove = true;
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (collision.collider.tag == "Ground") {
            canMove = false;
        }
    }

    void RayCasting() {

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, maxDistance: 10f)) {

            //  gg = hitInfo.point;
            if (hitInfo.collider.TryGetComponent<InteractableObject>(out var interactableObject1)) {
                interactableObject = interactableObject1;
                interactableObject.OnEnter();
                if (Input.GetMouseButtonDown(0)) {
                    interactableObject.OnAction();
                }
            }
            else {
                interactableObject.OnExit();
            }

        }
    }

    private void OnDrawGizmos() {
     //   Gizmos.DrawLine(camera.transform.position, gg);
    }

}
