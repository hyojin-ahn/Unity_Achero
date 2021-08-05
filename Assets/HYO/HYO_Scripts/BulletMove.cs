using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    GameObject target;
    
    Vector3 dir;

    public int power;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");

        //dir = target.transform.position - transform.position;
        //dir.Normalize();

        Vector3 l_vector = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(l_vector).normalized;

    }

    // Update is called once per frame
    void Update()
    {

        // 타겟 방향으로 회전함
        //transform.LookAt(transform);

        // 타겟 방향으로 다가감
        
        transform.position += transform.forward * speed * Time.deltaTime;

    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        //충돌한 반대 방향으로 튕기기
        //방향과 힘을 갖는 Vector3
        Vector3 direction = transform.position - other.gameObject.transform.position;

        //direction = direction * 1000;
        //normalized 를 함으로 벡터의 방향은 그대로 두고 크기만 1.0로 맞춰 주는 것
        direction = direction.normalized * 1000;


        dir = Quaternion.Euler(0, Random.Range(-60.0f, 60.0f), 0) * other.transform.forward;
        dir.y = 0;
        dir.Normalize();
        transform.forward = dir;
        


        //가져온 힘을 볼 오브젝트에 다시 전해 줌.
        //other.gameObject.GetComponent<Rigidbody>().AddForce(direction);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    //Debug.Log(collision.gameObject.name);

    //    //충돌한 반대 방향으로 튕기기
    //    //방향과 힘을 갖는 Vector3
    //    Vector3 direction = transform.position - collision.gameObject.transform.position;

    //    //direction = direction * 1000;
    //    //normalized 를 함으로 벡터의 방향은 그대로 두고 크기만 1.0로 맞춰 주는 것
    //    direction = direction.normalized * 1000;

    //    //가져온 힘을 볼 오브젝트에 다시 전해 줌.
    //    collision.gameObject.GetComponent<Rigidbody>().AddForce(direction);

    //}
}
