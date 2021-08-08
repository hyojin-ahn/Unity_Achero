using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    float speed = 10f;
    public Vector3 dir;
    public int power;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
        
        transform.Translate(dir*speed*Time.deltaTime);
        transform.Rotate(dir);
    }



    private void OnTriggerEnter(Collider other)
    {
        //데미지 주기
        other.GetComponentInParent<EnemyStat>().hp -= power;

        //데미지 주면 총알 파괴
        Destroy(gameObject);
    }


}
