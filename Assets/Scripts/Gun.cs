using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    const int StageMaxWidth = 150;

    [SerializeField] GameObject[] bulletPrefubs;
    [SerializeField] Transform ShotStart;

    bool isShot;

    // Start is called before the first frame update
    void Start()
    {
        isShot = true;
        BulletShot();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShot)
        {
            BulletShot();
        }

        GunMove();
        
    }

    void GunMove()
    {
        int timeSpeed = 100;
        float movePos = Mathf.PingPong(Time.time * timeSpeed, StageMaxWidth) - StageMaxWidth / 2;
        transform.localPosition = new Vector3(movePos,0,0);
    }

    void BulletShot()
    {

        GameObject bullet = (GameObject)Instantiate(SelectBullet());
        bullet.transform.position = ShotStart.position;
        Rigidbody bulletrd= bullet.GetComponent<Rigidbody>();
        // �e�ƃ}�Y���̃x�N�g�����v�Z���������擾����
        Vector3 shotVec = (ShotStart.position - transform.position);
        // �e�ƃ}�Y���̏����|�W�V�������قȂ邽�߁A�s�v�ȍ����̏������
        shotVec.y = 0.0f;
        
        bulletrd.AddForce(shotVec*30);
        isShot = false;

        StartCoroutine(ReloadTime());
    }

    GameObject SelectBullet()
    {
        int index = Random.Range(0, bulletPrefubs.Length);
        return bulletPrefubs[index];
    }


    const int BaseReloadCount = 10;
    
    IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(1);
        isShot = true;
    }
}
