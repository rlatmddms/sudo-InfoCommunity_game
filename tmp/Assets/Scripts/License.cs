//https://www.youtube.com/watch?v=KPoeNZZ6H4s

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class License : MonoBehaviour
{
    private SpriteRenderer rd;
    public bool is_get;
    public int id = 0;
    public Text infoText; // UI Text 컴포넌트
    public string itemInfo; // 표시할 텍스트 내용

    void Start()
    {
        is_get = false;
        rd = GetComponent<SpriteRenderer>();
        rd.material.color = new Color(0, 0, 0, 100 / 255f);
        // 시작할 때는 텍스트를 숨겨둠
        if (infoText != null)
        {
            infoText.text = "";
            infoText.gameObject.SetActive(false); // 처음에는 비활성화
        }
    }

    public void get_license()
    {
        is_get = true;
        rd.material.color = new Color(1, 1, 1, 150 / 255f);
    }
    public void giveup_license()
    {
        is_get = false;
        rd.material.color = new Color(0, 0, 0, 100 / 255f);
    }


    void OnMouseEnter()
    {
        if (is_get)
            rd.material.color = new Color(1, 1, 1, 1);
        else
            rd.material.color = new Color(0, 0, 0, 1);

        if (infoText != null)
        {
            infoText.text = itemInfo;
            Vector3 cam = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 offset = new Vector3(0,-50,0);
            infoText.rectTransform.position = cam + offset;
            infoText.gameObject.SetActive(true); // 텍스트 표시
        }
    }

    void OnMouseExit()
    {
        if (is_get)
            rd.material.color = new Color(1, 1, 1, 150 / 255f);
        else
            rd.material.color = new Color(0, 0, 0, 100 / 255f);

        if (infoText != null)
        {
            infoText.text = "";
            infoText.gameObject.SetActive(false); // 텍스트 숨김
        }
    }
}
