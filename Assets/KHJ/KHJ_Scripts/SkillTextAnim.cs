using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTextAnim : MonoBehaviour
{
    //처음 위치
    Vector3 init;

    private void OnEnable()
    {
        init = transform.position;
        iTween.MoveTo(gameObject, iTween.Hash(
            "x", Screen.width * 0.5,
            "time", 0.5f,
            "easetype", iTween.EaseType.easeInOutBack
            ));

        iTween.MoveTo(gameObject, iTween.Hash(
            "x", Screen.width * 1.5,
            "time", 0.5f,
            "easetype", iTween.EaseType.easeInOutBack,
            "delay", 2f,
            "oncomplete", "setting"
            ));
    }


    void setting()
    {
        transform.position = init;
        gameObject.SetActive(false);
    }


}
