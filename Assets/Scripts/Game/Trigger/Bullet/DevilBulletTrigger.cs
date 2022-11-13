using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBulletTrigger : BulletTrigger<Angel>
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger<Angel>(collision, (item) =>
        {
            item.Health.DecreaseHealth(_bullet.Damage);
            gameObject.SetActive(false);
        });
    }

}
