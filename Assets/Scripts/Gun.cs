using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour
{

    const int StageMaxWidth = 150;

    [SerializeField] GameObject[] bulletPrefubs;
    [SerializeField] Transform ShotStart;
    [SerializeField] Transform PlayerTransfrom;
    [SerializeField] float ShotSpeed = 50.0f;
    bool isShot;

    // Start is called before the first frame update
    void Start()
    {
        isShot = true;
        SetAngle();
        //BulletShot();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShot)
        {
            //BulletShot();
        }

        //GunMoveLR();
        GunMoveCircle();
    }

    int timeSpeed = 100;
    void GunMoveLR()
    {
        
        float movePos = Mathf.PingPong(Time.time * timeSpeed, StageMaxWidth) - StageMaxWidth / 2;
        transform.localPosition = new Vector3(movePos,0,0);
    }

    float angle;
    float rotateSpeed = 0.1f;
    Vector3 distanceFromPlayer = new Vector3( StageMaxWidth / 2, StageMaxWidth / 2, 0);
    void GunMoveCircle()
    {
        // プレイヤーにマズルを向ける
        SetAngle();

        //transform.localRotation = Quaternion.Euler(0,0,-angle);
        
        Debug.Log(angle);
        
    }

    void SetAngle()
    {
        angle = GetAngleNotY(PlayerTransfrom.position, transform.position);
    }

    void AddRad()
    {
        angle += rotateSpeed * Time.deltaTime;
        angle = Mathf.Repeat(angle, 360f);
    }


    float GetAngleNotY(Vector3 player,Vector3 mypos)
    {
        Vector3 vec = new Vector3(player.x,0.0f,player.z) - new Vector3(mypos.x,0.0f,mypos.z);
        float rad = Mathf.Atan2(vec.z, vec.x);
        //float deg = rad * Mathf.Rad2Deg;

        return rad;
        
    }

    void BulletShot()
    {

        GameObject bullet = (GameObject)Instantiate(SelectBullet(),ShotStart.position,transform.rotation);
        Rigidbody bulletrd= bullet.GetComponent<Rigidbody>();
        // 銃とマズルのベクトルを計算し向きを取得する
        Vector3 shotVec = (ShotStart.position - transform.position);
        // 銃とマズルの初期ポジションが異なるため、不要な高さの情報を削る
        shotVec.y = 0.0f;
        
        bulletrd.AddForce(shotVec*ShotSpeed);
        isShot = false;

        StartCoroutine(ReloadTime());
    }

    GameObject SelectBullet()
    {
        int index = Random.Range(0, bulletPrefubs.Length);
        return bulletPrefubs[index];
    }


    const int BaseReloadCount = 4;
    IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(BaseReloadCount);
        isShot = true;
    }
}
