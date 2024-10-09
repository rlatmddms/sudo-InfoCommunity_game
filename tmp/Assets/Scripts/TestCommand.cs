using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCommand : MonoBehaviour
{
    public string command;
    public int input;
    private void Awake()
    {
        
    }
    private void OnMouseDown()
    {
        if(command == "player speed")
        {
            GameManager.gm.player.speed = (float)(input);
        }
        else if(command == "get license")
        {
            GameManager.gm.ui.get_license(input);
        }
        else if(command == "giveup license")
        {
            GameManager.gm.ui.giveup_license(input);
        }
        else if(command == "player hp")
        {
            GameManager.gm.player.hp = input;
        }
        else if (command == "player st")
        {
            GameManager.gm.player.stamina = input;
        }
        else if (command == "enemy speed")
        {
            GameManager.gm.enemy.Speed = (float)(input);
        }
        else if (command == "enemy detect")
        {
            GameManager.gm.enemy.DetectionRadius = (float)(input);
        }
        else if (command == "enemyAI speed")
        {
            GameManager.gm.enemyAI.moveSpeed = (float)(input);
        }

    }
}
