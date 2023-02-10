using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunmoveReverseArea : MonoBehaviour
{
    bool isReverseCheck = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isReverseCheck)
        {
            isReverseCheck = true;
        }
    }
}
