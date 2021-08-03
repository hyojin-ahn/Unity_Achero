using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerani : MonoBehaviour
{
    public GameObject playermove;
    public bool ismove_;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ismove_ = playermove.GetComponent<PlayerMove>().ismove;
        // 좌우 
        
        if (ismove_ == true)
        {            
            //움직이면 롤링
            ani.SetInteger("AniInt", 1);
        }
        else
        {            
            //안움직이면 가만히
            ani.SetInteger("AniInt", 0);
        }
    }
}
