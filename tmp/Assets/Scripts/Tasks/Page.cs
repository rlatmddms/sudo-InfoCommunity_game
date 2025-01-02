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
        nextButton.onClick.AddListener(pagemanager.next_page); // '����' ��ư ����
        exitButton.onClick.AddListener(pagemanager.close_all); // '����' ��ư ����
        for (int i = 0; i < select_buttons.Length; i++)
        {
            int index = i; // Ŭ���� ������ �����ϱ� ���� �ε����� ���� ������ ����
            select_buttons[i].onClick.AddListener(() => select(index)); // �� ��ư�� ���� �̺�Ʈ ����
        }
    }

    
    void select(int idx)
    {
        select_index = idx;
    }
}
