using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _templates;
    [SerializeField] private GameObject[] _targets;
    [SerializeField] private float _spawnTime;

    private Point[] _points;

    private void Awake()
    {
        _points = gameObject.GetComponentsInChildren<Point>();

        for (int i = 0; i < _targets.Length && i < _points.Length; i++)
        {
            _points[i].SetTemplate(_templates[Random.Range(0, _templates.Length)]);
            _points[i].SetTarget(_targets[i]);
        }
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds time = new(_spawnTime);

        while (true)
        {
            _points[Random.Range(0, _points.Length)].Spawn();

            yield return time;
        }
    }
}