using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{   
    public Text textbar;
    public Text grade_text;

    public int study_score;
    public is_touched studying;

    public string str;
    public string grade_str;
    public int day = 2;
    public int[] calender; 
    public int year = 2025;
    public int month = 3;
    public int grade = 0;
    public int d;

    public float fast_dayspeed;
    public float Sfast_dayspeed;
    public float common_dayspeed;
    public float dayspeed_per_sec;

    void Start()
    {
        dayspeed_per_sec = common_dayspeed;
        studying.gameObject.SetActive(false);
        calender = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        day = 2;
        month = 3;
        year = 2025;
        grade_text.gameObject.SetActive(true);
        textbar.gameObject.SetActive(true); // 텍스트 표시
        StartCoroutine(timer());
    }

    private void FixedUpdate()
    {
        if(Input.GetButton("Jump"))
        {
            dayspeed_per_sec = fast_dayspeed;
            if(Input.GetButton("Fire1"))
                dayspeed_per_sec = Sfast_dayspeed;
        }
        else
        {
            dayspeed_per_sec = common_dayspeed;
        }
    }
    private IEnumerator timer()
    {
        for (d = 0; d < 1045; d++)
        {
            writepaper_exam();
            if (month == 3 && day == 2) grade++;
            if (day > calender[month])
            {
                day = 1;
                month++;
                if (month == 13)
                {
                    month = 1;
                    year++;
                }
            }
            str = year.ToString() + "년 " + month.ToString() + "월 " + day.ToString() + "일\nd + " + d.ToString();
            textbar.text = str;
            day++;

            grade_str = grade.ToString() + "학년\n내신(%) : ";
            if (GameManager.gm.rank.div == 0)
            {
                grade_str += "??";
            }
            else
            {
                float r = (1f - (GameManager.gm.rank.rankscore / GameManager.gm.rank.div)) * 100;
                if (r == 0) r = 0.03f;
                if (r > 100) r = 100f;
                grade_str += r.ToString() + "%";
            }
            grade_text.text = grade_str;

            yield return new WaitForSeconds(dayspeed_per_sec);
        }
        int m = GameManager.gm.ui.license_sum();
        if (m >= 4 && GameManager.gm.rank.rankscore >= 0.5f)
        {
            datas.is_gameover = false;
        }
        else
        {
            datas.is_gameover = true;
        }
        SceneManager.LoadScene("game over");
    }

    void writepaper_exam()
    {
        if (d > 930) return;
        if(d%365 == 45 || d%365 == 105 || d%365 == 195 || d%365 == 285)
        {
            study_score = 0;
            GameManager.gm.ui.Notice("지필고사 D-20",0,0,dayspeed_per_sec,70,false);
            studying.gameObject.SetActive(true);
            StartCoroutine(Examtime());
        }
    }

    private IEnumerator Examtime()
    {

        yield return new WaitForSeconds(dayspeed_per_sec);
        
        for (int i = 0; i < 19; i++)
        {
            GameManager.gm.ui.Notice("지필고사 D-"+(19-i).ToString(), -500, 400, 1, 50, false);
            if(studying.touched)
            {
                study_score++;
            }
            yield return new WaitForSeconds(dayspeed_per_sec);
        }
        if (study_score >= 14) study_score = 14;
        GameManager.gm.ui.Notice("지필고사!", 0, 0, 1f, 70, false);
        GameManager.gm.rank.rankscore += study_score / 14f;
        GameManager.gm.rank.div += 1;
        studying.gameObject.SetActive(false);
    }
}
