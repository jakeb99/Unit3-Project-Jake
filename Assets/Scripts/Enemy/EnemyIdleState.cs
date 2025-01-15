using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyIdleState : EnemyState
{
    int _currentTarget = 0;

    public EnemyIdleState(EnemyController enemy) : base(enemy)
    {
        // usees base constructor from EnemyState
        // anything below here is added on after.
    }

    public override void OnStateEnter()
    {
       _enemy._agent.destination = _enemy._targetPoints[_currentTarget].position;
        Debug.Log("Enemy entering Idle state");
    }

    public override void OnStateUpdate()
    {
        // choose a random target pint to move to
        if (_enemy._agent.remainingDistance < 0.1f)
        {
            _currentTarget++;
            if (_currentTarget >= _enemy._targetPoints.Length)
                _currentTarget = 0;

            _enemy._agent.destination = _enemy._targetPoints[_currentTarget].position;
        }

        //check for player
        if (Physics.SphereCast(_enemy._enemyEye.position, _enemy._checkRadius, _enemy.transform.forward, out RaycastHit hit, _enemy._playerCheckDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player Found!");

                _enemy._player = hit.transform;
                _enemy._agent.destination = _enemy._player.position;

                //Move to follow state
                _enemy.ChangeState(new EnemyFollowState(_enemy));
            }
        }
    }
    public override void OnStateExit()
    {
        Debug.Log("Enemy exiting Idle state");
    }
}
