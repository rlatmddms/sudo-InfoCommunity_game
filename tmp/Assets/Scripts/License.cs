//https://www.youtube.com/watch?v=KPoeNZZ6H4s

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class License : MonoBehaviour
{
    private SpriteRenderer rd;
    public Text infoText; // UI Text 컴포넌트
    public string itemInfo; // 표시할 텍스트 내용

    void Start()
    {

        rd = GetComponent<SpriteRenderer>();
        rd.material.color = new Color(1, 1, 1, 100 / 255f);
        // 시작할 때는 텍스트를 숨겨둠
        if (infoText != null)
        {
            infoText.text = "";
            infoText.gameObject.SetActive(false); // 처음에는 비활성화
        }
    }


    void OnMouseEnter()
    {
        rd.material.color = new Color(1,1,1,1);

        if (infoText != null)
        {
            infoText.text = itemInfo;
            Vector3 cam = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 offset = new Vector3(0,-45,0);
            infoText.rectTransform.position = cam + offset;
            infoText.gameObject.SetActive(true); // 텍스트 표시
        }
    }

    void OnMouseExit()
    {
        rd.material.color = new Color(1, 1, 1, 100/255f);

        if (infoText != null)
        {
            infoText.text = "";
            infoText.gameObject.SetActive(false); // 텍스트 숨김
        }
    }
}
