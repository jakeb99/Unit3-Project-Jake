using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerMeshFP : MonoBehaviour
{
    private MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    public void ShowPlayerMesh()
    {
        mr.enabled = true;
    }

    public void HidePlayerMesh()
    {
        mr.enabled = false;
    }
}
