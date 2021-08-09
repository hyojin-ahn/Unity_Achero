using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    public float speed = 20;
    Vector3 lookDirection;
    public bool ismove;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.5f;

    }

    // Update is called once per frame
    void Update()
    {
        float h;
        float v;
        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S))
        {
            
            h = Input.GetAxis("Horizontal");
            
            v = Input.GetAxis("Vertical");
            if (h != 0.0f || v != 0.0f)
            {
                ismove = true;
            }
            else
            {
                ismove = false;
            }
            
            Vector3 dirH = Vector3.right * h;
            Vector3 dirV = Vector3.forward * v;
            Vector3 dir = dirH + dirV;

            
            
            lookDirection = dir;
            //h * dirV + v * Vector3.right;
           
            this.transform.rotation = Quaternion.LookRotation(lookDirection);
            //this.transform.Translate(dir * speed * Time.deltaTime);
            transform.position += dir * speed * Time.deltaTime;
            dir.Normalize();
        }



        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }



    }
}
