using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPos : MonoBehaviour
{
    public GameObject bulletFactory;  //ÃÑ¾Ë °øÀå

    float currentTime;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > 1)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = transform.position;
            transform.Translate(Vector3.down * currentTime * Time.deltaTime);
            currentTime = 0;

        }


    }

}
