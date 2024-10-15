using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetLicenseSystem : MonoBehaviour
{
    SpriteRenderer rd;
    public GameObject minigame;
    public int start_date, end_date,id;
    public string change_scene;
    public int d;

    void Start()
    {
        rd = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (GameManager.gm.gametime.d >= start_date && GameManager.gm.gametime.d <= end_date)
        {
            return;
        }
        rd.material.color = new Color(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if(GameManager.gm.gametime.d < start_date || GameManager.gm.gametime.d > end_date || id > 10)
            {
                return;
            }

            if(id == 0)
            {
                PageManager a = minigame.GetComponent<PageManager>();
                d = GameManager.gm.gametime.d;
                a.show();
            }
            else if(id == 4)
            {
                Task1 a = minigame.GetComponent<Task1>();
                d = GameManager.gm.gametime.d;
                a.show();
            }
            else if (id == 5)
            {
                PageManager a = minigame.GetComponent<PageManager>();
                d = GameManager.gm.gametime.d;
                a.show();
            }
            //switch (id)
            //{
            //    case 0:
            //        change_scene = "Mini 0";
            //        break;
            //    case 1:
            //        change_scene = "Mini 1";
            //        break;
            //    case 2:
            //        change_scene = "Mini 2";
            //        break;
            //    case 3:
            //        change_scene = "Mini 3";
            //        break;
            //    case 4:
            //        change_scene = "Mini 4";
            //        break;
            //    case 5:
            //        change_scene = "Mini 5";
            //        break;
            //    case 6:
            //        change_scene = "Mini 6";
            //        break;
            //    case 7:
            //        change_scene = "Mini 7";
            //        break;
            //    case 8:
            //        change_scene = "Mini 8";
            //        break;
            //    case 9:
            //        change_scene = "Mini 9";
            //        break;

            //}
            //SceneManager.LoadScene(change_scene);
            else 
                get_license_event();
        }  
            
        
    }
    public void get_license_event()
    {
        string text = gameObject.name + "�� ȹ���Ͽ����ϴ�."; 
        GameManager.gm.ui.Notice(text,0,0,1f,50,true);
        gameObject.SetActive(false);
        GameManager.gm.ui.get_license(id);
        id = 100;
    }
}
