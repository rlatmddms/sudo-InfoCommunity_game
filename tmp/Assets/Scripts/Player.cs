using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private const bool V = true;
    public float speed;
    public float walk_speed;
    public float sprint_speed;
    public int hp, stamina;
    public Rigidbody2D rgd;
    bool is_move_x = false;
    Animator anime;
    Vector2 input;
    private void Awake()
    {
        rgd = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        bool is_buttondown_x = Input.GetButtonDown("Horizontal");
        bool is_buttondown_y = Input.GetButtonDown("Vertical");
        bool is_buttonup_x = Input.GetButtonUp("Horizontal");
        bool is_buttonup_y = Input.GetButtonUp("Vertical");

        if (is_buttondown_x)
            is_move_x = true;
        else if (is_buttondown_y)
            is_move_x = false;
        else if(is_buttonup_x || is_buttonup_y)
        {
            is_move_x = input.x != 0;
        }

        if (is_move_x)
        {
            input.y = 0;
            
        }

        else
        {
            input.x = 0;
            
        }
        anime.SetInteger("hor", (int)(input.x));
        anime.SetInteger("ver", (int)(input.y));



        if (Input.GetButtonDown("Fire1") && hp > 0)
        {
            hp -= 10;
        }
        if (Input.GetButtonDown("Fire2") && hp < 100)
        {
            hp += 10;
        }

        if(Input.GetButton("Shift") && stamina > 0)
        {
            speed = sprint_speed;
            stamina -= 1;
        }
        else
        {
            stamina++;
            if (stamina > 1000) stamina = 1000;
            speed = walk_speed;
        }

        if(hp <= 0)
        {
            Invoke("Game_Over", 1);
        }
     
    }
    void Game_Over()
    { 
        SceneManager.LoadScene("game_over");
    }

    private void FixedUpdate()
    {
        Vector2 move = input * Time.deltaTime * speed;
        rgd.MovePosition(move + rgd.position);
    }
    
}
