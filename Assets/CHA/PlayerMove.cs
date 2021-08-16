using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    public float speed = 20;
    Vector3 lookDirection;
    public bool ismove;
    bool isBorder;

    

    void Start()
    {
        speed = 5.5f;

    }

    // Update is called once per frame
    void Update()
    {
        float h;
        float v;
        h = Input.GetAxis("Horizontal");            
        v = Input.GetAxis("Vertical");
        if (h != 0.0f || v != 0.0f)
        {
            ismove = true;
        }
        else if (h == 0.0f && v == 0.0f)
        {
            ismove = false;            
        }

        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S))
        {            
            Vector3 dirH = Vector3.right * h;
            Vector3 dirV = Vector3.forward * v;
            Vector3 dir = dirH + dirV;            
            
            lookDirection = dir;
            //h * dirV + v * Vector3.right;


            //this.transform.rotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 0.2f);
            //this.transform.Translate(dir * speed * Time.deltaTime);
            if(!isBorder)
                transform.position += dir * speed * Time.deltaTime;
            dir.Normalize();
        }

        StopToWall();

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(2);
        }
    }


    void StopToWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 1, Color.green);
        isBorder = Physics.Raycast(transform.position, transform.forward, 1, LayerMask.GetMask("wall"));
    }

}
