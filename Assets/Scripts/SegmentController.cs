using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SegmentController : MonoBehaviour
{
    [SerializeField] private int _initialSize = 4;

    [SerializeField] private GameObject segmentPrefab;

    private List<GameObject> _segments;
    private ISegmentFactory _segmentFactory;

    [Inject] private InputHandler _input;
    [Inject] private FrameManager _frame;
    [Inject] private CollisionHandler _collision;

    private void Start()
    {
        _segments = new List<GameObject>();

        _segmentFactory = new SegmentFactory(segmentPrefab);

        _frame.Frame.AddListener(SegmentsPosition);
        _collision.Food.AddListener(Grow);
        _collision.Lose.AddListener(ResetState);

        ResetState();
    }

    private void SegmentsPosition()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].transform.position = _segments[i - 1].transform.position;
        }
    }

    private void Grow()
    {
        Vector3 newPosition = _segments[_segments.Count - 1].transform.position;
        GameObject newSegment = _segmentFactory.CreateSegment(newPosition);
        _segments.Add(newSegment);
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
}
