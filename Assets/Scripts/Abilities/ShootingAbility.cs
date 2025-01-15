using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float shootingForce;

    private ObjectPooling bulletPool;

    private void Awake()
    {
        bulletPool = FindAnyObjectByType<ObjectPooling>();
    }

    public void Shoot()
    {
        //Rigidbody clonedRigidbody = Instantiate(
        //        projectilePrefab, 
        //        weaponTip.position, 
        //        weaponTip.rotation
        //);

        Rigidbody clonedRigidbody = bulletPool.RetrieveAvailableBullet().GetRigidbody();

        if (!clonedRigidbody) return;

        clonedRigidbody.position = weaponTip.position;
        clonedRigidbody.rotation = weaponTip.rotation;

        clonedRigidbody.AddForce(weaponTip.forward * shootingForce);
    }
}
