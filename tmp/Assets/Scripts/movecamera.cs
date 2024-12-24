using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecamera : MonoBehaviour
{
    Transform camera_trsf;

    private void Awake()
    {
        camera_trsf = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        camera_trsf.localPosition = new Vector3(GameManager.gm.player.transform.position.x, GameManager.gm.player.transform.position.y, -15);
    }
}
