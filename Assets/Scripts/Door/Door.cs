using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private PhysicalButton doorButton;
    [SerializeField] private Indicator doorIndicator;
    [SerializeField] private DoorKey doorKey;
    [SerializeField] private Vector3 openOffset;
    [SerializeField] private float doorSpeed;

    private Vector3 closedPosition;

    private bool isOpen = false;
    [SerializeField] private bool canOpen;

    // Start is called before the first frame update
    void Start()
    {
        closedPosition = transform.position;

        if (doorKey)
        {
            canOpen = false;
            doorKey.OnDoorKeyPickUp += ToggleLock;
        } else
        {
            canOpen= true;
        }


        if (doorButton)
            doorButton.OnPressed += OpenDoor;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            Vector3 targetposition = closedPosition + openOffset;
            transform.position = Vector3.Lerp(transform.position, targetposition, Time.deltaTime * doorSpeed);

        } else
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, Time.deltaTime * doorSpeed);
        }

        if (canOpen)
        {
            doorIndicator?.IndicatorOn();
        } else if (!canOpen)
        {
            doorIndicator?.IndicatorOff();
        }
    }

    public void OpenDoor()
    {
        if (canOpen)
            isOpen = true;
    }

    public void CloseDoor() 
    { 
        isOpen = false;
    }

    public void ToggleLock()
    {
        if (!canOpen)
        {
            canOpen = true;
        } else
        {
            canOpen = false;
        }
    }
}
