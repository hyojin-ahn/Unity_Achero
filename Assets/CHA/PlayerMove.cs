using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        speed = 5.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // �Է�
        // �¿� 
        float h = Input.GetAxis("Horizontal");
        // ���� 
        float v = Input.GetAxis("Vertical");

        //�̵� 
        Vector3 dirH = Vector3.right * h;
        Vector3 dirV = Vector3.forward * v;
        Vector3 dir = dirH + dirV;
        //dir�� ũ�� 1�� �Ѵ�
        dir.Normalize();

        //������
        transform.position += dir * speed * Time.deltaTime;


    }
}
