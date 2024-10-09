using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class license : MonoBehaviour
{
    
    private string[] license_names;
    public Transform[] licenses;
    public SpriteRenderer[] licenses_render;
    void Start()
    {
        license_names = new string[10];
        string[] license_name = {"정보처리기능사 : x", "컴퓨터활용능력2급 : x", "컴퓨터활용능력1급","전기기능사","정보기기운용기능사","SQLD","통신선로기능사","한국사능력검정","TOEIC","OPIC"};

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));
        // 자격증 UI 근처에 마우스를 갖다대면 자격증 모양이 진해지고 이름이 표시됨
        for (int i = 0; i < licenses.Length; i++)
        {
            if ((licenses[i].position.x - mousePos.x)*(licenses[i].position.x - mousePos.x) + (licenses[i].position.y - mousePos.y)* (licenses[i].position.y - mousePos.y) <= 2.25f)
            {
                licenses_render[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                UnityEngine.Debug.Log("인식돔");
                break;
            }
            else
            {
                licenses_render[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 180 / 255f);
                UnityEngine.Debug.Log("인식ㄴㄴ");
            }
            
        }
    }
}
