using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCommand : MonoBehaviour
{
    Player player;
    UI ui;
    EnemyAI enemyAI;
    Enemy_Movement enemy;
    License license;
    public string command;
    public int input;
    private void Awake()
    {
        player = GameManager.gm.player;
        ui = GameManager.gm.ui;
        enemyAI = GameManager.gm.enemyAI;
        enemy = GameManager.gm.enemy;
    }
    private void OnMouseDown()
    {
        if(command == "player speed")
        {
            player.speed = input;
        }
        else if(command == "get license")
        {
            ui.get_license(input);
        }
        else if(command == "giveup license")
        {
            ui.giveup_license(input);
        }
        else if(command == "player hp")
        {
            player.hp = input;
        }
        else if (command == "player st")
        {
            player.stamina = input;
        }
        else if (command == "enemy speed")
        {
            enemy.Speed = input;
        }
        else if (command == "enemy detect")
        {
            enemy.DetectionRadius = input;
        }
        else if (command == "enemyAI speed")
        {
            enemyAI.moveSpeed = input;
        }

    }
}
