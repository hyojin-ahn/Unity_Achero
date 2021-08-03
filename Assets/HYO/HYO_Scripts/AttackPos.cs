using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPos : MonoBehaviour
{
    public GameObject bulletFactory;  //�Ѿ� ����

    float currentTime;
    bool targetready;  
    public float speed;
    int count=0;
    

    // Start is called before the first frame update
    void Start()
    {
        targetready= GameObject.Find("Player");
    }

    // Update is called once per frame
    
    void Update()
    {
        currentTime += Time.deltaTime;
        
        if(currentTime > 1  && targetready==true)
        {
            GameObject bullet = Instantiate(bulletFactory);

            bullet.transform.position = transform.position;
            transform.Translate(Vector3.forward * currentTime * Time.deltaTime);
            currentTime = 0;
            count = count + 1;
            if (count == 3)
            {
                currentTime = -4;
                count = 0;

            }
        }


    }

}
