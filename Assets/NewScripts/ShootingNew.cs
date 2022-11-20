/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingNew : MonoBehaviour
{
    [SerializeField]
    private ObjectPooler.ObjectInfo.ObjectType bulletType;
    [SerializeField]
    private Vector3 spawnPosition;
    void Update()
    {
        var bullet = ObjectPooler.instance.GetObject(bulletType);
        bullet.GetComponent<Bullet2>().OnCreate(spawnPosition, transform.rotation);
    }
}
*/