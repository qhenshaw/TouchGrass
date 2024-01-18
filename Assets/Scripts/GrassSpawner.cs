using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _edgeCount = 64;
    [SerializeField] private Vector2 _scaleRange = new Vector2(1f, 2f);
    [SerializeField] private float _positionJitter = 0.2f;
    [SerializeField] private Vector3 _extents = new Vector3(10f, 0f, 10f);

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        float spacing = _extents.x / _edgeCount;
        for (int x = 0; x < _edgeCount; x++)
        {
            for (int y = 0; y < _edgeCount; y++)
            {
                Vector3 jitter = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)) * _positionJitter * spacing;
                Vector3 position = new Vector3(x * spacing, 0, y * spacing) + jitter;
                float angle = Random.Range(0f, 360f);
                Quaternion rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 scale = Random.Range(_scaleRange.x, _scaleRange.y) * Vector3.one;
                GameObject grass = Instantiate(_prefab, position, rotation, transform);
                grass.transform.localScale = scale;
            }
        }
    }
}
