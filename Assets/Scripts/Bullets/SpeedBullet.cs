using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBullet : BulletBase
{

    [SerializeField] float bulletSpeed;

    void Start()
    {
        StartCoroutine(DeleteBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
        Shot();
    }

    protected override void Shot()
    {
        //transform.position += transform.forward * bulletSpeed;
    }

    IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(deleteSec);
        Destroy(gameObject);
    }
}
