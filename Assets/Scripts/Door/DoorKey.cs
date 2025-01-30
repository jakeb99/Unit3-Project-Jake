using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public Action OnDoorKeyPickUp;

    private void OnTriggerEnter(Collider other)
    {
        OnDoorKeyPickUp?.Invoke();

        Destroy(gameObject);
    }


}
