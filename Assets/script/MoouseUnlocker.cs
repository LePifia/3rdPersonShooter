using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoouseUnlocker : MonoBehaviour
{

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

}
