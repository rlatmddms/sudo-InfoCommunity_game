using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class is_touched : MonoBehaviour
{
    public bool touched = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            touched = true;
        }
        else
        {
            touched = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touched = false;
    }
}
