using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private PooledObject bulletPrefab;
    [SerializeField] private int amountOfClones = 20;
    [SerializeField] private List<PooledObject> availableBulets = new List<PooledObject>();
    [SerializeField] private List<PooledObject> unavailableBulets = new List<PooledObject>();

    private void Start()
    {
        for (int i = 0; i < amountOfClones; i++)
        {
            AddElementToPool();
        }
    }

    public PooledObject RetrieveAvailableBullet()
    {
        if (availableBulets.Count == 0) 
        {
            AddElementToPool();
        }

        PooledObject firstAvailable = availableBulets[0];

        availableBulets.Remove(firstAvailable);
        unavailableBulets.Add(firstAvailable);

        firstAvailable.gameObject.SetActive(true);

        return firstAvailable;
    }

    void AddElementToPool()
    {
        PooledObject clone = Instantiate(bulletPrefab);

        clone.LinkToPool(this);

        clone.gameObject.SetActive(false);
        clone.transform.SetParent(transform);
        availableBulets.Add(clone);
    }

    public void ResetBullet(PooledObject bulletToReset)
    {
        unavailableBulets.Remove(bulletToReset);
        availableBulets.Add(bulletToReset);

        bulletToReset.gameObject.SetActive(false);
        bulletToReset.GetRigidbody().velocity = Vector3.zero;
    }
}
