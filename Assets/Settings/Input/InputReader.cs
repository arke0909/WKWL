using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public Controls _playerInput { get; private set; }

    public event Action EscEvent;
    public event Action LeftMouseEvent;
    //public event Action OnEscEvent;

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

    private void OnEnable()
    {
        if (_playerInput == null)
        {
            _playerInput = new Controls();
            _playerInput.Player.SetCallbacks(this);
        }


        _playerInput.Enable();
    }

    public void OnESC(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if(context.performed) LeftMouseEvent?.Invoke();
    }

    public void OnMouse(InputAction.CallbackContext context)
    {
        _mousePos = context.ReadValue<Vector2>();
    }

}
