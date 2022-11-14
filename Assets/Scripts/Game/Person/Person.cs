using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Person : MonoBehaviour
{
    private float _radius = 10;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Sprite _evilSprite;
    [SerializeField] private Sprite _simpleSprite;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<Transform> _points = new List<Transform>();
    private Transform _currentPoint;
    public List<Transform> Points { get => _points; set => _points = value; }
    private void Start()
    {
        _navMeshAgent.TurnOffNavmesh();
        GetRandomPoint();
    }
    public void SetEvilSprite() => _spriteRenderer.sprite = _evilSprite;
    public void SetSimpleSprite() => _spriteRenderer.sprite = _simpleSprite;
    private void GetRandomPoint() => _currentPoint = _points.GetRandomElementFromList();
    private void Update()
    {
        if (Vector2.Distance(_currentPoint.position,transform.position) < _radius)
        {
            GetRandomPoint();
        }
        _navMeshAgent.SetDestination(_currentPoint.position);
    }
}
