using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public Text textbar;
    public Text grade_text;

    public string str;
    public string grade_str;
    public int day = 2;
    public int[] calender; 
    public int year = 2025;
    public int month = 3;
    public int grade = 0;
    public int d;
    public float dayspeed_per_sec;
    void Start()
    {
        calender = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        day = 2;
        month = 3;
        year = 2025;
        grade_text.gameObject.SetActive(true);
        textbar.gameObject.SetActive(true); // 텍스트 표시
        StartCoroutine(timer());
    }
    private IEnumerator timer()
    {
        for (d = 0; d < 1045; d++)
        {
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
            str = "";
            str += year.ToString();
            str += "년 ";
            str += month.ToString();
            str += "월 ";
            str += day.ToString();
            str += "일";
            str += "\nd + ";
            str += d.ToString();
            textbar.text = str;
            day++;

            grade_str = "";
            grade_str += grade.ToString();
            grade_str += "학년";
            grade_text.text = grade_str;

            yield return new WaitForSeconds(dayspeed_per_sec);
        }
    }
}
