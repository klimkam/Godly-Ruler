using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorBullet : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    public Bullet CreateBullet()
    {
        return Instantiate(_bullet,_shootPoint.position,Quaternion.identity);
    }
}
