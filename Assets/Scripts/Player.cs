using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // プレイヤーのスピード
    [SerializeField] float playerMS = 10.0f;
    [SerializeField] float playerJumpH = 10.0f;
    [SerializeField] GameObject DeadEffect;

    bool isDead = false;
    public bool GetIsDead() {return isDead;}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet" || collision.transform.tag == "DeadSpace")
        {
            isDead = true;
            Instantiate(DeadEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
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
