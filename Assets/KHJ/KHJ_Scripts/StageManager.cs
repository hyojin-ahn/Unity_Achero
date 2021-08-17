using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public int stage_now = 0;
    public bool clear;

    public GameObject Door;
    public GameObject SlotMachine;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Door = GameObject.Find("Door");
    }

    void Update()
    {
        if(Door == null)
            Door = GameObject.Find("Door");

        switch (stage_now)
        {
            case 1:                
                Door.GetComponent<Animator>().SetTrigger("Clear");
                break;
            case 2:
                if(Player.instance.gameObject.GetComponent<PlayerAttack>().CurrTarget == null)
                {
                    Door.GetComponent<Animator>().SetTrigger("Clear");
                }
                break;
            case 3:
                Door.GetComponent<Animator>().SetTrigger("Clear");
                break;
            case 4:
                Door.GetComponent<Animator>().SetTrigger("Clear");
                break;
            case 5:
                break;
        }

        if(clear == true)
        {
            clear = false;
            Next_Stage();
        }

    }

    public void Next_Stage()
    {
        if(stage_now != 0)
            Door.GetComponent<Animator>().ResetTrigger("Clear");
        stage_now += 1;
        SceneManager.LoadScene(stage_now);
    }

}
