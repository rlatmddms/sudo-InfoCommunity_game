using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{

    public Page[] pages;
    public Image canvas_ui;
    private int pageindex = 0; // 현재 미션 창 인덱스
    public int wrong_cnt = 0;
    public GetLicenseSystem glc;
    Color wrong = new Color(140 / 255f, 15 / 255f, 15 / 255f);
    Color right = new Color(40 / 255f, 210 / 255f, 40 / 255f);

    void Start()
    {
        canvas_ui.gameObject.SetActive(false);
        all_active_false();
    }


    void all_active_false()
    {
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i].gameObject.SetActive(false);
        }
        canvas_ui.gameObject.gameObject.SetActive(false);
    }

    public void show()
    {
        pages[pages.Length - 1].nextButton.gameObject.SetActive(true);
        pageindex = 0;
        wrong_cnt = 0;
        show_page();
    }
    public void show_page()
    {
        if(pageindex < pages.Length)
        {
            pages[pageindex].gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("page index error");
        }
    }

    public void next_page()
    {
        if (pageindex < pages.Length - 1)
        {
            answer_check();
            pages[pageindex].gameObject.SetActive(false);
            pageindex++; // 다음 미션 인덱스로 증가
            show_page(); // 다음 미션 창 표시
        }
        else
        {
            answer_check();
            pages[pageindex].nextButton.gameObject.SetActive(false);
        }
    }
    public void answer_check()
    {
        if (pages[pageindex].select_index == pages[pageindex].answer_index)
        {
            StartCoroutine(effect(right));
        }
        else
        {
            StartCoroutine(effect(wrong));
            wrong_cnt++;
        }
    }

    void all_complete()
    {
        Debug.Log("all");
        glc.get_license_event();
        this.gameObject.SetActive(false);
    }
    public void close_all()
    {
        if(pageindex == pages.Length - 1 && wrong_cnt == 0)
        {
            wrong_cnt = 1;
            all_complete();
        }
        else
        {
            glc.start_date = glc.d + 20;
        }
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].gameObject.SetActive(false);
        }
        canvas_ui.gameObject.gameObject.SetActive(false);
    }
    public IEnumerator effect(Color color)
    {
        canvas_ui.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            canvas_ui.color = new Color(color.r, color.g, color.b, (i * 10) / 255f);
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 10; i++)
        {
            canvas_ui.color = new Color(color.r, color.g, color.b, (100 - i*10) / 255f);
            yield return new WaitForSeconds(0.01f);
        }
        canvas_ui.color = color;
        canvas_ui.gameObject.SetActive(false);
    }
}
