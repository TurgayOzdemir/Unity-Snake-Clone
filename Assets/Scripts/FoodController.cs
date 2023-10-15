using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FoodController : MonoBehaviour
{
    [SerializeField] BoxCollider2D gridAarea;

    [Inject] private CollisionHandler _collision;

    private void Start()
    {
        RandomizePosition();

        _collision.Food.AddListener(RandomizePosition);
    }

    private void RandomizePosition()
    {
        Bounds bounds = gridAarea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }
}
