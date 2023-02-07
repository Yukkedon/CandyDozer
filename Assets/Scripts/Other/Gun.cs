using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] GameObject Bullet;

    Vector3 bulletpos;
    Rigidbody bulletrb;
    // Start is called before the first frame update
    void Start()
    {
        bulletrb= Bullet.GetComponent<Rigidbody>();
        bulletpos = transform.position;
        bulletpos.y += 10;

        

        BulletShot();

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void BulletShot()
    {
        Instantiate(Bullet,transform.position,Quaternion.identity);
    }
}
