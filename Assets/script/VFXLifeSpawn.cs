using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXLifeSpawn : MonoBehaviour
{
    private float lifeTimer;
    private void Update()
    {
        lifeTimer += Time.deltaTime;

        if (lifeTimer > 4)
        {
            gameObject.SetActive(false);
        }
    }
}
