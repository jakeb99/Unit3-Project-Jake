using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _targetpoints;
    [SerializeField] private Transform _enemyTransform;
    [SerializeField] private float _playerCheckDistance;
    //[SerializeField] private float _checkRadius = 0.4f;

    private int _currentTarget = 0;

    private NavMeshAgent _agent;

    public bool isIdle = true;
    public bool isPlayerFound;
    public bool isCloseToPlayer;

    public Transform _player;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        // tell egent where the first target is
        _agent.destination = _targetpoints[_currentTarget].position;
    }

    private void Update()
    {
        if(isIdle)
        {
            Idle();
        }
        else if (isPlayerFound)
        {
            if (isCloseToPlayer)
            {
                AttackPlayer();
            }
            else
            {
                FollowPlayer();
            }
        }
    }

    void Idle()
    {
        
    }

    void FollowPlayer()
    {
        if (_player)
        {
            // logic for if we are too far away from player, go into patrolling
            if (Vector3.Distance(transform.position, _player.position) < 10f)
            {
                isPlayerFound = false;
                isIdle = true;
            }

            if (Vector3.Distance(transform.position, _player.position) < 2)
            {
                isCloseToPlayer = true;
            } else
            {
                isCloseToPlayer = false;
            }

            _agent.destination = _player.position;
        } else
        {
            isPlayerFound = false;
            isIdle = true;
            isCloseToPlayer = false;
        }
    }

    void AttackPlayer()
    {
        if (!_player) { Debug.Log("no player found"); return; }

        Debug.Log("attacking!");

        if (Vector3.Distance(transform.position, _player.position) > 2)
        {
            isCloseToPlayer = false;
        }
    }
}
