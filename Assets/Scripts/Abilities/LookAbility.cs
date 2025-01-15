using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAbility : MonoBehaviour
{
    //Reference to the Head/Camera GameObject
    [SerializeField] private Transform head;

    public void Look(Vector3 lookDirection)
    {
        head.transform.localRotation = Quaternion.Euler(-lookDirection.y, 0, 0);
        transform.rotation = Quaternion.Euler(0, lookDirection.x, 0);
    }
}
