using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Transform hp_shape;
    public Transform st_shape;
    float stbar_x, stbar_sizex;
    float hpbar_x, hpbar_sizex;
    void Awake()
    {
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

    void show_hpbar(int hp)
    {
        //hp 증감에 따른 변화
        hp_shape.localPosition = new Vector3(hpbar_x - (hpbar_sizex * (100 - hp) * 0.01f) / 2, hp_shape.localPosition.y, 1);
        hp_shape.localScale = new Vector3(hpbar_sizex * hp * 0.01f, hp_shape.localScale.y, 1);
    }
    void show_stbar(int st)
    {
        //st 증감에 따른 변화
        st_shape.localPosition = new Vector3(stbar_x - (stbar_sizex * (100 - st) * 0.01f) / 2, st_shape.localPosition.y, 1);
        st_shape.localScale = new Vector3(stbar_sizex * st * 0.01f, st_shape.localScale.y, 1);
    }
}
