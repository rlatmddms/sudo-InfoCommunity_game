using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    PageManager pagemanager;
    public Button[] select_buttons;
    public Button nextButton;
    public Button exitButton;
    public int answer_index;
    public int select_index;
    // Start is called before the first frame update
    void Start()
    {
        pagemanager = GetComponentInParent<PageManager>();
        nextButton.onClick.AddListener(pagemanager.next_page); // '다음' 버튼 설정
        exitButton.onClick.AddListener(pagemanager.close_all); // '종료' 버튼 설정
        for (int i = 0; i < select_buttons.Length; i++)
        {
            int index = i; // 클로저 문제를 방지하기 위해 인덱스를 로컬 변수로 저장
            select_buttons[i].onClick.AddListener(() => select(index)); // 각 버튼에 선택 이벤트 연결
        }
    }

    
    void select(int idx)
    {
        select_index = idx;
    }
}
