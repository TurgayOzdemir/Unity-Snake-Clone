using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private InputActions _input;

    public Vector2 Direction { get; private set; }

    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;

    private void Awake()
    {
        _input = new InputActions();

        _input.Mobile.Enable();
        _input.Desktop.Disable();

        _input.Desktop.Up.performed += ctx =>
        {
            if (Direction != Vector2.down)
                Direction = Vector2.up;
        };

        _input.Desktop.Down.performed += ctx =>
        {
            if (Direction != Vector2.up)
                Direction = Vector2.down;
        };

        _input.Desktop.Left.performed += ctx =>
        {
            if (Direction != Vector2.right)
                Direction = Vector2.left;
        };

        _input.Desktop.Right.performed += ctx =>
        {
            if (Direction != Vector2.left)
                Direction = Vector2.right;
        };

        _input.Mobile.TouchStart.performed += ctx =>
        {
            _startTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        };

        _input.Mobile.TouchEnd.canceled += ctx =>
        {
            _endTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            HandleSwipe();
        };
    }

    private void HandleSwipe()
    {
        Vector2 swipeDirection = _endTouchPosition - _startTouchPosition;

        // Horizontal
        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
        {
            if (swipeDirection.x > 0 && Direction != Vector2.left)
                Direction = Vector2.right;
            else if (swipeDirection.x < 0 && Direction != Vector2.right)
                Direction = Vector2.left;
        }

        // Vertical
        else
        {
            if (swipeDirection.y > 0 && Direction != Vector2.down)
                Direction = Vector2.up;
            else if (swipeDirection.y < 0 && Direction != Vector2.up)
                Direction = Vector2.down;
        }      
    }


    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

}
