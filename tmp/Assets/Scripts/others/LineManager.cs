using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class LineManager : MonoBehaviour
{
    public Canvas canvas; // 연결된 Canvas
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
        // GraphicRaycaster와 EventSystem 가져오기
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

                // 새로운 선 생성
                currentLine = Instantiate(linePrefab, canvas.transform);
                currentLineRect = currentLine.GetComponent<RectTransform>();

                currentLineRect.position = startPoint;
                currentLineRect.sizeDelta = new Vector2(1, 1); // 초기 크기
                isDrawing = true;
            }
            
        }
        if (isDrawing && Input.GetMouseButton(0))
        {
            Vector2 currentPoint = Input.mousePosition;
            DrawLine(startPoint, currentPoint);
        }

        // 마우스 클릭 종료
        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }
    }
    private void DrawLine(Vector2 start, Vector2 end)
    {
        Vector2 direction = end - start;
        float length = direction.magnitude;

        // 선 길이와 회전 업데이트
        currentLineRect.sizeDelta = new Vector2(length, 2); // 선 두께는 2
        currentLineRect.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        currentLineRect.position = start + direction / 2; // 선의 중심점 배치
    }
    private bool TryGetUIElementUnderMouse(out GameObject clickedObject)
    {
        clickedObject = null;

        // 마우스 위치로 PointerEventData 생성
        pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        // Raycast 결과 저장
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        // 클릭된 UI 요소 확인
        if (results.Count > 0)
        {
            clickedObject = results[0].gameObject;
            return true;
        }
        return false;
    }
}
