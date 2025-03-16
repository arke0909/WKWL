using UnityEngine;
using System;
using static Controls;
using UnityEngine.InputSystem;

public class Test2 : MonoBehaviour, IPlayerActions
{
    private Controls _controls;

    public event Action OnLeftClickEvent;
    public event Action OnClickESCEvent;

    private Vector2 _mousePos;

    public Vector2 MousePos
    {
        get
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
            mousePos.z = 0;
            return mousePos;
        }
    }

    private void Awake()
    {
        _controls = new Controls();
        _controls.Enable();
        _controls.Player.SetCallbacks(this);
    }
    public void OnESC(InputAction.CallbackContext context)
    {
        //nothing
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if(context.performed)
        OnLeftClickEvent?.Invoke();
    }

    public void OnMouse(InputAction.CallbackContext context)
    {
        _mousePos = context.ReadValue<Vector2>();
    }
}