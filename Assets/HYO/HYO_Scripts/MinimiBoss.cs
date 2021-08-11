using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimiBoss : MonoBehaviour
{
    //현재 HP
    public float MinimibossHp;
    //최대HP
    public float maxHp;
    //HP UI
    public Image hpUI;
    //들어갈 데미지
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        MinimibossHp = maxHp;

    }

    // Update is called once per frame
    void Update()
    {
        if (MinimibossHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("pBullet"))
        {
            MinimibossHp -= damage;
            hpUI.fillAmount = MinimibossHp / maxHp;

        }
    }
}
