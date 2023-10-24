using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;
using System;

public class inputManager : MonoBehaviour
{
    public static inputManager instance;
    //public GameObject IMGameObject;
    public bool MenuOpenCloseInput {  get; private set; }
    public bool Canceln {  get; private set; }
    public bool MoveRight { get; private set; }
    public bool MoveLeft { get; private set; }

    private PlayerInput _playerInput;
    private InputSystemUIInputModule _inputsystemuiinputmoudle;

    private InputAction _menuOpenCloseAction;
    private InputAction _cancel;
    private InputAction _moveleft;
    private InputAction _moveright;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();
        _inputsystemuiinputmoudle = GetComponent<InputSystemUIInputModule>();

        _menuOpenCloseAction = _playerInput.actions["MenuOpenClose"];
        _cancel = _inputsystemuiinputmoudle.cancel;
        _moveleft = _playerInput.actions["MoveLeft"];
        _moveright = _playerInput.actions["MoveRight"];

    }

    // Update is called once per frame
    private void Update()
    {
        MenuOpenCloseInput = _menuOpenCloseAction.WasPressedThisFrame();
        Canceln = _cancel.WasPressedThisFrame();
        MoveLeft = _moveleft.WasPressedThisFrame();
        MoveRight = _moveright.WasPressedThisFrame();
    }

}
