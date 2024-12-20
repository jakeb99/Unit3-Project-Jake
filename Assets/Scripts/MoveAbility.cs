using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAbility : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController controller;

    [Header("Settings")]
    [SerializeField] private float movementSpeed;

    public void Move(Vector3 moveDirection)
    {
        Vector3 forwardMovement = moveDirection.z * transform.forward;
        Vector3 sidewaysMovement = moveDirection.x * transform.right;

        Vector3 movementVector = (forwardMovement + sidewaysMovement);

        controller.Move(movementVector * Time.deltaTime * movementSpeed);
    }
}
