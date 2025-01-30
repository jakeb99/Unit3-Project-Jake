using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CommanderAbility : MonoBehaviour
{
    [SerializeField] private LayerMask compatibleWithCommands;
    [SerializeField] private CompanionController companionController;

    [SerializeField] private GameObject wayPointPrefab;

    private void Awake()
    {
        if (companionController == null)
        {
            companionController = FindObjectOfType<CompanionController>();
        }
    }

    public void Command()
    {
        Instantiate(wayPointPrefab, transform.position, Quaternion.identity);
        companionController.GiveCommand(new MoveCommand(transform.position));
    }
}
