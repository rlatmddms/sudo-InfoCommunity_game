using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Id1 : MonoBehaviour
{
    SpriteRenderer rd;
    public int start_date, end_date,id;

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
        if(collision.collider.CompareTag("Player"))
            get_license_event();
    }
    void get_license_event()
    {
        if(GameManager.gm.gametime.d >= start_date && GameManager.gm.gametime.d <= end_date && id < 10)
        {
            string text = "";
            text += gameObject.name;
            text += "¸¦ È¹µæÇÏ¿´½À´Ï´Ù.";
            GameManager.gm.ui.Notice(text);
            gameObject.SetActive(false);
            GameManager.gm.ui.get_license(id);
            id = 100;
        }
    }
}
