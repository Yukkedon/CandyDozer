using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    protected int deleteSec = 3;

    // Update is called once per frame
    protected abstract void Shot();
}
