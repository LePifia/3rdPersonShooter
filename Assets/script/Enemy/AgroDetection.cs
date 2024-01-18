using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class AgroDetection : MonoBehaviour
{
    public event Action<Transform> OnAggro = delegate { };

    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();

        if(player != null)
        {
            OnAggro(player.transform);
        }
    }
}
