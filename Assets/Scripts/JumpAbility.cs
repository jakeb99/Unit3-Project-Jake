using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAbility : MonoBehaviour
{
    [SerializeField] private GravityAbility gravScript;
    [SerializeField] private float jumpForce;

    public void Jump()
    {
        if (gravScript.IsOnGround())
            gravScript.AddForce(Vector3.up * jumpForce);
    }
}
