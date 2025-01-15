using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAbility : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravityAcceleration = -9.81f;
    private float currentGravity;

    private void FixedUpdate()
    {
        if (!IsOnGround())
        {
            currentGravity += gravityAcceleration * Time.deltaTime;
        } 
        else if (currentGravity < 0) 
        {
            currentGravity = 0;
        }

        Vector3 gravVec = new Vector3();
        gravVec.y = currentGravity;
        controller.Move(gravVec * Time.deltaTime);
    }

    public void AddForce(Vector3 force)
    {
        currentGravity = force.y;
    }

    public bool IsOnGround()
    {
        return Physics.CheckSphere(transform.position, 0.01f, groundLayer);
    }
}
