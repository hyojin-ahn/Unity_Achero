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
        dir = target.transform.position - transform.position;
        dir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
 
        transform.Translate(dir * speed * Time.deltaTime);

    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        //�浹�� �ݴ� �������� ƨ���
        //����� ���� ���� Vector3
        Vector3 direction = transform.position - other.gameObject.transform.position;

        //direction = direction * 1000;
        //normalized �� ������ ������ ������ �״�� �ΰ� ũ�⸸ 1.0�� ���� �ִ� ��
        direction = direction.normalized * 1000;


        dir = Quaternion.Euler(0, Random.Range(-60.0f, 60.0f), 0) * other.transform.forward;
        dir.Normalize();


        //������ ���� �� ������Ʈ�� �ٽ� ���� ��.
        //other.gameObject.GetComponent<Rigidbody>().AddForce(direction);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    //Debug.Log(collision.gameObject.name);

    //    //�浹�� �ݴ� �������� ƨ���
    //    //����� ���� ���� Vector3
    //    Vector3 direction = transform.position - collision.gameObject.transform.position;

    //    //direction = direction * 1000;
    //    //normalized �� ������ ������ ������ �״�� �ΰ� ũ�⸸ 1.0�� ���� �ִ� ��
    //    direction = direction.normalized * 1000;

    //    //������ ���� �� ������Ʈ�� �ٽ� ���� ��.
    //    collision.gameObject.GetComponent<Rigidbody>().AddForce(direction);

    //}
}
