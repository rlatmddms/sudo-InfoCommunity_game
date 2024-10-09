using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Transform hp_shape;
    public Transform st_shape;
    float stbar_x, stbar_sizex;
    float hpbar_x, hpbar_sizex;

    public Camera cam;

    public bool[] having_license;
    public License[] licenses;


    void Awake()
    {
        having_license = new bool[10];
        for (int i = 0; i < 10; i++) {
            having_license[i] = false;
        }
        stbar_x = st_shape.localPosition.x;
        stbar_sizex = st_shape.localScale.x;

        hpbar_x = hp_shape.localPosition.x;
        hpbar_sizex = hp_shape.localScale.x;
    }

    private void Update()
    {
        show_hpbar(GameManager.gm.player.hp);
        show_stbar(GameManager.gm.player.stamina);
    }

    private void FixedUpdate()
    {
    }

    public void show_hpbar(int hp)
    {
        //hp 증감에 따른 변화
        hp_shape.localPosition = new Vector3(hpbar_x - (hpbar_sizex * (100 - hp) * 0.01f) / 2, hp_shape.localPosition.y, 1);
        hp_shape.localScale = new Vector3(hpbar_sizex * hp * 0.01f, hp_shape.localScale.y, 1);
    }
    public void show_stbar(int st)
    {
        //st 증감에 따른 변화
        st_shape.localPosition = new Vector3(stbar_x - (stbar_sizex * (100 - st) * 0.01f) / 2, st_shape.localPosition.y, 1);
        st_shape.localScale = new Vector3(stbar_sizex * st * 0.01f, st_shape.localScale.y, 1);
    }

    public void get_license(int id)
    {
        if (id >= having_license.Length)
        {
            Debug.Log("index ERROR");
            return;
        }
        having_license[id] = true;
        licenses[id].get_license();
    }
    public void giveup_license(int id)
    {
        if (id >= having_license.Length)
        {
            Debug.Log("index ERROR");
            return;
        }
        having_license[id] = false;
        licenses[id].giveup_license();
    }

}
