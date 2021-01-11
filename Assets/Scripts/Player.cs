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

    [SerializeField]
    float mouseSensivity;
    private float xRotation;
    private float yRotation;

    [SerializeField]
    Transform playerBody;

    [SerializeField]
    float jumpPower;

    public bool canJump = false;

    private void Start() {
        Initialization();
    }

    void Update() {
        RayCasting();
    }

    void Initialization() {
    }

    private void FixedUpdate() {
        Movement();
        Rotation();
        Jump();
    }

    void Jump() {
        if (canJump) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
            }
        }
    }

    void Movement() {
        // if (canMove) {
        Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z);

        Vector3 moveX = transform.right * Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        Vector3 moveZ = forward * Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        var movePos = moveX + moveZ;

        rb.AddForce(movePos, ForceMode.VelocityChange);

        //  }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Ground") {
            canMove = true;
            canJump = true;
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (collision.collider.tag == "Ground") {
            canMove = false;
            canJump = false;
        }
    }

    void RayCasting() {

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, maxDistance: 10f)) {

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

    void Rotation() {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //  yRotation += mouseX;

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void OnDrawGizmos() {
        //   Gizmos.DrawLine(camera.transform.position, gg);
    }

}
