using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class Enemy_Movement : MonoBehaviour
{
    public Transform Player_Position;   //�÷��̾� ��ġ
    public float DetectionRadius = 10f; //�÷��̾� ���� ����
    public float Speed = 5.0f;  //�̵� �ӵ�
    bool IsMove;    //�̵��ϴ��� �Ǵ�
    

    Animator ani;
    
    // Start is called before the first frame update
    void Awake()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float DistanceToPlayer = Vector2.Distance(transform.position, Player_Position.position);    //�÷��̾���� �Ÿ�


        
        
        
        if (DistanceToPlayer <= DetectionRadius)    //�÷��̾ ���� ���� ���� ������ ��
        {
            IsMove = true;
            
            ChasePlayer();  //�÷��̾� �߰�
        }
        else
        {
            IsMove = false;
        }
        
        ani.SetBool("IsMove", IsMove);
        
        
    }
    private void ChasePlayer()  //�÷��̾� �߰� �Լ�
    {
        Vector3 Direction = (Player_Position.position - transform.position).normalized; //�÷��̾ �ִ� ����

        transform.position += Direction * Speed * Time.deltaTime;   //�̵�
    }
    public void OnCollisionEnter2D()    //�浹 ���� (�浹 ���� �ø�)
    {
        if (GameManager.gm.player.hp > 0)  //�÷��̾�� ���� ��
        {
            
            GameManager.gm.player.hp -= 10; //�÷��̾� ü�� ����
            
        }
    }
       
}