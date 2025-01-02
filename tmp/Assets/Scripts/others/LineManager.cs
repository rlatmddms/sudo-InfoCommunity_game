using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class LineManager : MonoBehaviour
{
    public Canvas canvas; // ����� Canvas
    public GameObject linePrefab;

    private GraphicRaycaster graphicRaycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;
    private GameObject currentLine;
    private RectTransform currentLineRect;
    private Vector2 startPoint;
    private bool isDrawing = false;

    void Start()
    {
        // GraphicRaycaster�� EventSystem ��������
        graphicRaycaster = canvas.GetComponent<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TryGetUIElementUnderMouse(out GameObject clickedObject))
            {
                startPoint = clickedObject.transform.position;

                // ���ο� �� ����
                currentLine = Instantiate(linePrefab, canvas.transform);
                currentLineRect = currentLine.GetComponent<RectTransform>();

                currentLineRect.position = startPoint;
                currentLineRect.sizeDelta = new Vector2(1, 1); // �ʱ� ũ��
                isDrawing = true;
            }
            
        }
        if (isDrawing && Input.GetMouseButton(0))
        {
            Vector2 currentPoint = Input.mousePosition;
            DrawLine(startPoint, currentPoint);
        }

        // ���콺 Ŭ�� ����
        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }
    }
    private void DrawLine(Vector2 start, Vector2 end)
    {
        Vector2 direction = end - start;
        float length = direction.magnitude;

        // �� ���̿� ȸ�� ������Ʈ
        currentLineRect.sizeDelta = new Vector2(length, 2); // �� �β��� 2
        currentLineRect.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        currentLineRect.position = start + direction / 2; // ���� �߽��� ��ġ
    }
    private bool TryGetUIElementUnderMouse(out GameObject clickedObject)
    {
        clickedObject = null;

        // ���콺 ��ġ�� PointerEventData ����
        pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        // Raycast ��� ����
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        // Ŭ���� UI ��� Ȯ��
        if (results.Count > 0)
        {
            clickedObject = results[0].gameObject;
            return true;
        }
        return false;
    }
}
