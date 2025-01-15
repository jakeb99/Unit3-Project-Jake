using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    [SerializeField] private float timeToReset = 15f;
    [SerializeField] private float currentTimer = 0f;
    [SerializeField] private Rigidbody bulletRigidBody;

    private ObjectPooling linkedPool;

    public void LinkToPool(ObjectPooling pool)
    {
        linkedPool = pool;
    }

    // onenable called when game object is set active
    private void OnEnable()
    {
        currentTimer = 0;
    }

    private void Update()
    {
        if(currentTimer < timeToReset)
        {
            currentTimer += Time.deltaTime;   
        } else
        {
            linkedPool.ResetBullet(this);
        }
    }

    public Rigidbody GetRigidbody()
    {
        return bulletRigidBody;
    }
}
