using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public Text textbar;
    public string str;
    public int day = 2;
    public int[] calender; 
    public int year = 2025;
    public int month = 3;
    void Start()
    {
        calender = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        day = 2;
        month = 3;
        year = 2025;
        StartCoroutine(timer());
        textbar.gameObject.SetActive(true); // 텍스트 표시
    }
    private IEnumerator timer()
    {
        for (int d = 0; d < 1045; d++)
        {
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
            Debug.Log(month + "월 " + day + "일");
            str = "";
            str += year.ToString();
            str += "년 ";
            str += month.ToString();
            str += "월 ";
            str += day.ToString();
            str += "일";
            textbar.text = str;
            day++;
            yield return new WaitForSeconds(2f);
        }
    }
}
