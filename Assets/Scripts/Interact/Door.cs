using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Door : InteractableObject {

    enum DoorState {
        Opened,
        Closed,
        Locked
    }

    [SerializeField]
    DoorState state = DoorState.Closed;

    DoorState State {
        get {
            return state;
        }
        set {
            Debug.Log("Changed");
         //   OnChangeState();
            state = value;
        }
    }

    void OnChangeState() {
        switch (state) {
            case DoorState.Opened:
                Close();
                break;
            case DoorState.Closed:
                Open();
                break;         
        }
    }

    public override void OnAction() {
        switch (State) {
            case DoorState.Opened:
                Close();
                break;
            case DoorState.Closed:
                Open();
                break;
            case DoorState.Locked:
                Locked();
                break;
        }
    }

    void Open() {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        state = DoorState.Opened;
    }

    void Close() {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        state = DoorState.Closed;
    }

    void Locked() {

    }

}
