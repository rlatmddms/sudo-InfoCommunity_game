using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class datas
{
    public static string want_company = "xxx111xxx";
    public static bool is_gameover = false;
}

public class GameOver : MonoBehaviour
{
    public string scene_name;
    public Text title_text, play_text;
    public InputField input;
    private void Start()
    {
        if (datas.want_company == "xxx111xxx")
        {
            
            title_text.text = "���ϴ� ȸ�� �̸��� �Է��ϼ���";
            play_text.text = "PLAY";
        }
        else
        {
            if (datas.is_gameover == false)
            {
                title_text.text = datas.want_company + "��� ����!";
            }
            else
            {
                title_text.text = "GAME OVER";
            }
            play_text.text = "TRY AGAIN";
        }
    }
    public void SceneChange()
    {
        datas.want_company = input.text;
        SceneManager.LoadScene(scene_name);
    }
}
