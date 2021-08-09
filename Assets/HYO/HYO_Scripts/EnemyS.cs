using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{
    public int Hp;
    public int Power;

    public GameObject enemy;
    GameObject player;
    public float objDistance;
    public bool isRotate;

    MakeEnemy spawn;

    AttackPos attackPos;

    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);

        attackPos = gameObject.GetComponentInChildren<AttackPos>();
    }

    // Update is called once per frame
    void Update()
    {

        if(attackPos.count == 4)
        {
            //y=-2
            Vector3 gone = transform.position;
            gone.y = -2;
            //transform.position = new Vector3(0, -2, 0);
            transform.position = Vector3.Lerp(transform.position, gone , 1f * Time.deltaTime);

            if(transform.position.y < -1.9f)
            {
                attackPos.count++;

                //랜덤 포지션 값을 받아옴
                GameObject spObj = GameObject.Find("spawn");
                MakeEnemy sp = spObj.GetComponent<MakeEnemy>();
                targetPos = sp.GetRandomPosition();
                targetPos.y = -2;

                transform.position = targetPos;

                targetPos.y = 0.5f;
                
            }


           




            

        }
        else if(attackPos.count == 5)
        {


            transform.position = Vector3.Lerp(transform.position, targetPos, 1f * Time.deltaTime);

            if(transform.position.y >= 0.45f)
            {
                attackPos.count++;
            }

            /* 
             밑에서 랜덤 X,Z좌표를 받아서 이동후 y=0.5로 다시 올라옴
            transform.position = new Vector3(0, 0.5f, 0);
            */

        }
        else if(attackPos.count == 6)
        {
            // 타겟 방향으로 회전함
            Vector3 l_vector = player.transform.position - transform.position;
            //transform.rotation = Quaternion.LookRotation(l_vector).normalized;
            //transform.LookAt(player.transform);
            //isRotate = false;

            transform.forward = Vector3.Lerp(transform.forward, l_vector, 0.5f * Time.deltaTime);
        }
        objDistance = Vector3.Distance(enemy.transform.position, player.transform.position);
        //Debug.Log(objDistance);

    }
}
