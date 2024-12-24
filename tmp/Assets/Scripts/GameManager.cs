using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Player1 player;
    public UI ui;
    public GameTime gametime;
    public EnemyAI enemyAI;
    public Enemy_Movement enemy;
    public Rank rank;
    public PageManager pagemanager;

    void Awake()
    {
        gm = this;
    }
}
