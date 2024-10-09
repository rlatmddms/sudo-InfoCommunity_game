//https://www.youtube.com/watch?v=KPoeNZZ6H4s

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class License : MonoBehaviour
{
    private SpriteRenderer rd;
    public Text infoText; // UI Text ������Ʈ
    public string itemInfo; // ǥ���� �ؽ�Ʈ ����

    void Start()
    {

        rd = GetComponent<SpriteRenderer>();
        rd.material.color = new Color(1, 1, 1, 100 / 255f);
        // ������ ���� �ؽ�Ʈ�� ���ܵ�
        if (infoText != null)
        {
            infoText.text = "";
            infoText.gameObject.SetActive(false); // ó������ ��Ȱ��ȭ
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
            infoText.gameObject.SetActive(true); // �ؽ�Ʈ ǥ��
        }
    }

    void OnMouseExit()
    {
        rd.material.color = new Color(1, 1, 1, 100/255f);

        if (infoText != null)
        {
            infoText.text = "";
            infoText.gameObject.SetActive(false); // �ؽ�Ʈ ����
        }
    }
}
