using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Vector3 axis;
    // Start is called before the first frame update
    void Start()
    {
        axis = new Vector3(0, 1f, 0);
        StartCoroutine(RoundCube());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis);
    }

    IEnumerator RoundCube()
    {
        yield return new WaitForSeconds(2.0f);
        axis.y = 0;
        axis.z = 1f;
        yield return new WaitForSeconds(2.0f);
        axis.z = 0;
        axis.y = 1f;
    }
}
