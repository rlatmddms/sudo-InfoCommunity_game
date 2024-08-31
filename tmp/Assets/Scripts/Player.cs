using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int hp, stamina;
    Rigidbody2D rgd;
    Vector2 input;
    private void Awake()
    {
        rgd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1"))
        {
            hp -= 10;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            hp += 10;
        }
    }

    private void FixedUpdate()
    {
        Vector2 move = input.normalized * Time.deltaTime * speed;
        rgd.MovePosition(move + rgd.position);
    }
    
}
