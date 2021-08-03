using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public float speed = 20;
    public bool ismove;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.5f;

    }

    // Update is called once per frame
    void Update()
    {
        // 입력
        // 좌우 
        float h = Input.GetAxis("Horizontal");
        // 상하 
        float v = Input.GetAxis("Vertical");

        if (h != 0.0f || v != 0.0f)
        {
            ismove = true;
        }
        else
        {
            ismove = false;
        }
        //이동 
        Vector3 dirH = Vector3.right * h;
        Vector3 dirV = Vector3.forward * v;
        Vector3 dir = dirH + dirV;
        //dir의 크기 1로 한다
        dir.Normalize();

        //움직임
        transform.position += dir * speed * Time.deltaTime;
        



    }
}
