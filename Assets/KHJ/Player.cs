using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life;
    void Start()
    {
        life = 100;
    }

    void Update()
    {
        
    }

    public void Damaged()
    {
        life -= 10;
    }
}
