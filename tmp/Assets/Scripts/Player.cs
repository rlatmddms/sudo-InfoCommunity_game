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
    public int recover_st, use_st;
    public Rigidbody2D rgd;
    bool is_move_x = false;
    Animator anime;
    Vector2 input;
    private void Awake()
    {
        rgd = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        StartCoroutine(is_sprint());
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

        if(hp <= 0)
        {
            Invoke("Game_Over", 1);
        }
     
    }

    private IEnumerator is_sprint()
    {
        bool isis = true;
        while (true)
        {
            if (Input.GetButton("Shift") && stamina > use_st && isis)
            {
                speed = sprint_speed;
                stamina -= use_st;
                if(stamina < use_st)
                {
                    isis = false;
                }
            }
            else
            {
                stamina += recover_st;
                if (stamina > 1000) stamina = 1000;
                speed = walk_speed;
                if (stamina >= 1000) isis = true;
            }
            if(!isis)
            {
                GameManager.gm.ui.st_rd.color = new Color(1, 150 / 255f, 41 / 255f);
            }
            else
            {
                GameManager.gm.ui.st_rd.color = new Color(41 / 255f, 1, 41 / 255f);
            }
            yield return new WaitForSeconds(0.02f);
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
