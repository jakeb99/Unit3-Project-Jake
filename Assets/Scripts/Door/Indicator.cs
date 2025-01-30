using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] private Material greenLightMat;
    [SerializeField] private Material redLightMat;
    public void IndicatorOn()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material = greenLightMat;
    }

    public void IndicatorOff()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material = redLightMat;
    }
}
