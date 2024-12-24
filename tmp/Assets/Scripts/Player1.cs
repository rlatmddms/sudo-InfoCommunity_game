using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player1 : MonoBehaviour
{
    bool isis = true;
    public float speed;
    public float walk_speed;
    public float sprint_speed;
    public int hp, stamina;
    public int recover_st, use_st;
    Rigidbody2D rgd;
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

        input.Normalize();
        if (input.x > 0f && this.transform.localScale.x > 0f || input.x < 0f && this.transform.localScale.x < 0f) this.transform.localScale = new Vector3(this.transform.localScale.x * -1, 2, 1);
        transform.Translate(input * speed * Time.deltaTime);
        if (input != Vector2.zero)
            anime.SetFloat("RunState", 0.1f);
        else 
            anime.SetFloat("RunState", 0f);
        if (Input.GetButton("Shift") && stamina > use_st && isis)
        {
            anime.SetFloat("RunState", 0.3f);
            speed = sprint_speed;
            stamina -= use_st;
            if (stamina < use_st)
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
        if (!isis)
        {
            GameManager.gm.ui.st_rd.color = new Color(1, 150 / 255f, 41 / 255f);
        }
        else
        {
            GameManager.gm.ui.st_rd.color = new Color(41 / 255f, 1, 41 / 255f);
        }
    }
    
}
