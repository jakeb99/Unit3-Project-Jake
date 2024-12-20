using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float shootingForce;

    public void Shoot()
    {
        Rigidbody clonedRigidbody = Instantiate(
                projectilePrefab, 
                weaponTip.position, 
                weaponTip.rotation
        );

        clonedRigidbody.AddForce(weaponTip.forward * shootingForce);
    }
}
