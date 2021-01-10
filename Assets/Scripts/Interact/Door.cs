using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : InteractableObject {

    enum DoorState {
        Opened,
        Closed,
        Locked
    }

    DoorState state = DoorState.Closed;

    DoorState State {
        get {
            return state;
        }
        set {
            GameManager.TextForInteractableObj.text = state.ToString();
            state = value;
        }
    }

    void OnChangeState() {
        switch (State) {
            case DoorState.Opened:
                Close();
                break;
            case DoorState.Closed:
                Open();
                break;         
        }
    }

    public override void OnAction() {
        switch (state) {
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
        State = DoorState.Opened;
    }

    void Close() {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        State = DoorState.Closed;
    }

    void Locked() {

    }

}
