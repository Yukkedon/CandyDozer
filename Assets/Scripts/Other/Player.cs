using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // プレイヤーのスピード
    [SerializeField] float playerMS = 10.0f;
    [SerializeField] float playerJumpH = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movepos = Vector3.zero;
        movepos.x = Input.GetAxis("Horizontal");
        movepos.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            movepos.y = playerJumpH;
        }

        movepos.Normalize();

        transform.position += movepos*playerMS;
    }
}
