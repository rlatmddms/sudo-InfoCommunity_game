using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldItemEffect : MonoBehaviour
{
    SpriteRenderer rd;
    public int n = 100;
    public int add_n = 0;
    Color one_color;
    
    void Start()
    {
        rd = GetComponent<SpriteRenderer>();
        one_color = rd.color;
    }

    private void FixedUpdate()
    {
        if(add_n + n > 256)
        {
            add_n = 0;
        }
        else
        {
            add_n+=5;
        }
        rd.material.color = new Color(1, 1, 1, (add_n + n) / 255f);
    }
}
