using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Player player;
    public UI ui;


    void Awake()
    {
        gm = this;
    }
}
