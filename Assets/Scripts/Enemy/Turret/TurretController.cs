using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private TurretState currentState;

    public TurretLazer turretlazer;
    [SerializeField] public float checkDistance = 0;
    [SerializeField] public float checkRadius;
    [SerializeField] public Transform checkOrgin;
    //[SerializeField] private MeshRenderer meshRenderer;
    //[SerializeField] private List<Material> materials = new List<Material>();

    private bool playerInView;

    private void Awake()
    {
        currentState = new TurretIdleState(this);
    }

    private void Start()
    {
        //currentState.OnTurretStateEnter += ChangeTurretLightMat;
        currentState.OnStateEnter();
    }

    private void Update()
    {
        currentState.OnStateUpdate();
    }

    public void ChangeState(TurretState state)
    {
        currentState.OnStateExit();
        currentState = state;
        //currentState.OnTurretStateEnter += ChangeTurretLightMat;
        currentState.OnStateEnter();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInView = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInView = false;
        }
    }

    public bool IsPlayerVisible()
    {
        return playerInView;
    }

    // looking into change the mat when we change state but did not have time to finish this
    //public void ChangeTurretLightMat()
    //{
    //    // only swap colours if we have ones to use
    //    if (materials.Count == 2)
    //    {
    //        if (currentState.GetType() == typeof(TurretAttackState))
    //        {
    //            meshRenderer.materials[1] = materials[0];
    //        }
    //        else
    //        {
    //            meshRenderer.materials[1] = materials[1];
    //        }
    //    }

    //    ////Debug.Log(currentState.GetType().ToString());
    //}
}
