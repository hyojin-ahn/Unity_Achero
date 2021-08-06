using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WheelRoulette : MonoBehaviour
{
    public GameObject UI;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        UI.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);

    }
    
}
