using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISegmentFactory
{
    GameObject CreateSegment(Vector3 position);
}

public class SegmentFactory : ISegmentFactory
{
    private readonly GameObject _segmentPrefab;

    public SegmentFactory(GameObject segmentPrefab)
    {
        _segmentPrefab = segmentPrefab;
    }

    public GameObject CreateSegment(Vector3 position)
    {
        GameObject segment = Object.Instantiate(_segmentPrefab);
        segment.transform.position = position;
        return segment;
    }
}
