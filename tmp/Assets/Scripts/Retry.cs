using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{

    public string scene_name;
    
    public void SceneChange()
    {
        SceneManager.LoadScene(scene_name);
    }
}
