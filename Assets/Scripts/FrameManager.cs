using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FrameManager : MonoBehaviour
{
    [HideInInspector] public UnityEvent Frame;

    [SerializeField] private float tickRate = 0.1f;

    private void Start()
    {
        StartCoroutine(TickRoutine());
    }

    private IEnumerator TickRoutine()
    {
        yield return new WaitForSeconds(tickRate);

        Frame?.Invoke();

        StartCoroutine(TickRoutine());
    }
}
