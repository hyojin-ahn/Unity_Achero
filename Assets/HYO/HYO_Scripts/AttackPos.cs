using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPos : MonoBehaviour
{
    public GameObject bulletFactory;  //ÃÑ¾Ë °øÀå

    float currentTime;
    bool targetready;  
    public float speed;

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
            transform.Translate(Vector3.down * currentTime * Time.deltaTime);
            currentTime = 0;

        }


    }

}
