using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] Material currentMat;
    [SerializeField] Material otherMat;
    MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();

        mr.material = currentMat;
    }

    public void SwapMaterial()
    {
        mr.material = otherMat;

        otherMat = currentMat;
        currentMat = mr.material;
    }
}
