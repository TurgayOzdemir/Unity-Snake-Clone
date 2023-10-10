using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<GameObject> _segments;

    [SerializeField] private int _initialSize = 4;

    [SerializeField] private GameObject segmentPrefab;

    private void Start()
    {
        _segments= new List<GameObject>();
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].transform.position = _segments[i - 1].transform.position;
        }

        transform.position = new Vector3(Mathf.Round(transform.position.x) + _direction.x, Mathf.Round(transform.position.y) + _direction.y, 0f);
    }

    private void Grow()
    {
        GameObject segment = Instantiate(segmentPrefab);
        segment.transform.position = _segments[_segments.Count - 1].transform.position;

        _segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i]);
        }
        _segments.Clear();
        _segments.Add(gameObject);

        for (int i = 1; i < _initialSize; i++)
        {
            _segments.Add(Instantiate(segmentPrefab));
        }

        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Grow();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ResetState();
        }
    }
}
