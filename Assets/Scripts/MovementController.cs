using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MovementController : MonoBehaviour
{
    [Inject] private InputHandler _input;
    [Inject] private FrameManager _frame;

    private void Start()
    {
        _frame.Frame.AddListener(Move);
    }

    private void Move()
    {
        if (_input.Direction != Vector2.zero)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x) + _input.Direction.x, Mathf.Round(transform.position.y) + _input.Direction.y, 0f);
        }
    }
}
