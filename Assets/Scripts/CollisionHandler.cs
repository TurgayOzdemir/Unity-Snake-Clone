using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [HideInInspector] public UnityEvent Food;
    [HideInInspector] public UnityEvent Lose;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Food?.Invoke();
        }
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Player"))
        {
            Lose?.Invoke();
        }
    }
}
