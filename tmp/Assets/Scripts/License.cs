using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class License : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer rd;
    void Start()
    {
        rd = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()
    {
        rd.material.color = new Color(1, 1, 1, 1);
    }
    void OnMouseExit()
    {
        rd.material.color = new Color(1, 1, 1, 100 / 255f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
