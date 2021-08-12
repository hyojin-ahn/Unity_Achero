using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimisMove : MonoBehaviour
{
    public float speed;
    GameObject player;
    public GameObject minimis;
    public float objDistance;

    public Rigidbody rigi;
    Vector3 dir;


    // Start is called before the first frame update
    void Start()
    {
        //timer = 0.0f;
        StartCoroutine(Moving());
       
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        objDistance = Vector3.Distance(minimis.transform.position, player.transform.position);
        //Debug.Log(objDistance);


        transform.Translate(dir.normalized * 2f * Time.deltaTime);


        #region �Ѿƴٴϱ�
        //if (objDistance > 3)
        //{
        //    dir = player.transform.position - transform.position;
        //    dir.Normalize();
        //    transform.Translate(dir * speed * Time.deltaTime);

        //}
        //else if(objDistance <= 3)
        //{
        //    timer += Time.deltaTime;
        //    waitingTime = Random.Range(1.5f, 3.0f);
        //    if (timer > waitingTime)
        //    {

        //        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.5f * Time.deltaTime);
        //        timer = 0;
        //        if (objDistance <= 0.8f)
        //        {
        //            transform.position = transform.position;
        //        }
        //    }

        //}
        #endregion
    }
    IEnumerator Moving()
    {
        rigi = GetComponent<Rigidbody>();
        while (true)
        {
            float dir1 = Random.Range(-6.5f, 6.5f);
            float dir2 = Random.Range(-8.5f, 8.5f);

            dir = new Vector3(dir1, 0, dir2);
            yield return new WaitForSeconds(5);
            //rigi.velocity = new Vector3(dir1, 0.5f, dir2);
            
        }
       


    }
}
