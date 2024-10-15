using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldItemEffect2 : MonoBehaviour
{
    SpriteRenderer rd;
    public int n = 150;
    public int i = 5;
    public int add_n = 0;
    Color one_color;
    void Start()
    {
        rd = GetComponent<SpriteRenderer>();
        one_color = rd.color;
    }

    private void FixedUpdate()
    {
        if (add_n + n > 256)
        {
            add_n = 0;
        }
        else
        {
            add_n += i;
        }
        rd.color = new Color((add_n + n) / 255f, (add_n + n) / 255f, (add_n + n) / 255f);
    }
}
