using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPos : MonoBehaviour
{
    public GameObject bulletFactory;  //ÃÑ¾Ë °øÀå

    float currentTime;
    bool targetready;  
    public float speed;
    public int count=0;
    int rand;

    // Start is called before the first frame update
    void Start()
    {
        targetready= GameObject.Find("Player");
    }

    // Update is called once per frame
    
    void Update()
    {
        currentTime += Time.deltaTime;
        if (count < 3)
        {
            if (currentTime > 0.5f && targetready == true)
            {
                Fire();
                currentTime = 0;
            }

        }
        else if (count == 3)
        {
            if(currentTime > 1)
            {
                count++;
                currentTime = 0;
                rand = Random.Range(3, 8);
            }

        }
        else if(count == 4)
        {
            if(currentTime > rand)
            {
                count = 0;
                currentTime = 0;
            }
        }
       

    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = transform.position;
        transform.Translate(Vector3.forward * currentTime * Time.deltaTime);
        count = count + 1;
    }
   

}
