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
        string[] license_name = {"����ó����ɻ� : x", "��ǻ��Ȱ��ɷ�2�� : x", "��ǻ��Ȱ��ɷ�1��","�����ɻ�","����������ɻ�","SQLD","��ż��α�ɻ�","�ѱ���ɷ°���","TOEIC","OPIC"};

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));
        // �ڰ��� UI ��ó�� ���콺�� ���ٴ�� �ڰ��� ����� �������� �̸��� ǥ�õ�
        for (int i = 0; i < licenses.Length; i++)
        {
            if ((licenses[i].position.x - mousePos.x)*(licenses[i].position.x - mousePos.x) + (licenses[i].position.y - mousePos.y)* (licenses[i].position.y - mousePos.y) <= 2.25f)
            {
                licenses_render[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                UnityEngine.Debug.Log("�νĵ�");
                break;
            }
            else
            {
                licenses_render[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 180 / 255f);
                UnityEngine.Debug.Log("�νĤ���");
            }
            
        }
    }
}
