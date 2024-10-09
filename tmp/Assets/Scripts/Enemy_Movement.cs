using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class Enemy_Movement : MonoBehaviour
{
    public Transform Player_Position;   //플레이어 위치
    public float DetectionRadius = 10f; //플레이어 감지 범위
    public float Speed = 5.0f;  //이동 속도
    bool IsMove;    //이동하는지 판단
    

    Animator ani;
    
    // Start is called before the first frame update
    void Awake()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float DistanceToPlayer = Vector2.Distance(transform.position, Player_Position.position);    //플레이어와의 거리


        
        
        
        if (DistanceToPlayer <= DetectionRadius)    //플레이어가 감지 범위 내에 들어왔을 시
        {
            IsMove = true;
            
            ChasePlayer();  //플레이어 추격
        }
        else
        {
            IsMove = false;
        }
        
        ani.SetBool("IsMove", IsMove);
        
        
    }
    private void ChasePlayer()  //플레이어 추격 함수
    {
        Vector3 Direction = (Player_Position.position - transform.position).normalized; //플레이어가 있는 방향

        transform.position += Direction * Speed * Time.deltaTime;   //이동
    }
    public void OnCollisionEnter2D(Collision2D collision)    //충돌 감지 (충돌 시작 시만)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager.gm.player.hp > 0)  //플레이어와 근접 시
        {
            
            GameManager.gm.player.hp -= 10; //플레이어 체력 감소
            
        }
    }
       
}