using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // 추적할 목표 (플레이어)
    public float moveSpeed = 2f; // 이동 속도
    public Tilemap tilemap; // 타일맵 참조

    private List<Vector3Int> path; // A* 알고리즘으로 계산된 경로

    private void Start()
    {
        path = new List<Vector3Int>();
        StartCoroutine(UpdatePath());
    }

    private void Update()
    {
        MoveAlongPath();
    }

    private IEnumerator UpdatePath()
    {
        while (true)
        {
            CalculatePath();
            yield return new WaitForSeconds(0.5f); // 1초마다 경로 재계산
        }
    }

    private void CalculatePath()
    {
        Vector3Int start = tilemap.WorldToCell(transform.position);
        Vector3Int goal = tilemap.WorldToCell(target.position);
        path = AStar(start, goal);
    }

    private void MoveAlongPath()
    {
        if (path.Count > 0)
        {
            Vector3 targetPosition = tilemap.GetCellCenterWorld(path[0]);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 현재 위치에 도달했으면 다음 셀로 이동
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                path.RemoveAt(0); // 다음 셀로 이동
            }
        }
    }

    // A* 알고리즘을 위한 Node 클래스
    private class Node
    {
        public Vector3Int Position; // 노드의 위치 (셀 좌표)
        public float GCost; // 시작 노드로부터의 이동 비용
        public float HCost; // 목표 노드까지의 예상 비용
        public float FCost => GCost + HCost; // 총 비용
        public Node Parent; // 현재 노드의 부모 노드

        public Node(Vector3Int position, Node parent = null)
        {
            Position = position;
            Parent = parent;
        }
    }

    private List<Vector3Int> AStar(Vector3Int start, Vector3Int goal)
    {
        // A* 알고리즘 구현
        List<Vector3Int> path = new List<Vector3Int>();
        List<Node> openList = new List<Node>();
        HashSet<Vector3Int> closedSet = new HashSet<Vector3Int>();

        Node startNode = new Node(start);
        openList.Add(startNode);

        while (openList.Count > 0)
        {
            Node currentNode = openList[0];

            // 가장 낮은 FCost를 가진 노드 선택
            for (int i = 1; i < openList.Count; i++)
            {
                if (openList[i].FCost < currentNode.FCost ||
                    (openList[i].FCost == currentNode.FCost && openList[i].HCost < currentNode.HCost))
                {
                    currentNode = openList[i];
                }
            }

            openList.Remove(currentNode);
            closedSet.Add(currentNode.Position);

            // 목표에 도달했는지 확인
            if (currentNode.Position == goal)
            {
                return RetracePath(startNode, currentNode);
            }

            foreach (var neighbor in GetNeighbors(currentNode.Position))
            {
                if (closedSet.Contains(neighbor) || !IsWalkable(neighbor))
                    continue;

                float newCostToNeighbor = currentNode.GCost + 1;
                Node neighborNode = new Node(neighbor, currentNode);

                if (newCostToNeighbor < neighborNode.GCost || !openList.Contains(neighborNode))
                {
                    neighborNode.GCost = newCostToNeighbor;
                    neighborNode.HCost = GetDistance(neighborNode.Position, goal);
                    if (!openList.Contains(neighborNode))
                        openList.Add(neighborNode);
                }
            }
        }

        return path; // 경로를 찾지 못했을 경우 빈 리스트 반환
    }

    private List<Vector3Int> RetracePath(Node startNode, Node endNode)
    {
        List<Vector3Int> retracedPath = new List<Vector3Int>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            retracedPath.Add(currentNode.Position);
            currentNode = currentNode.Parent;
        }
        retracedPath.Reverse();
        return retracedPath;
    }

    private List<Vector3Int> GetNeighbors(Vector3Int position)
    {
        List<Vector3Int> neighbors = new List<Vector3Int>
        {
            new Vector3Int(position.x + 1, position.y, position.z),
            new Vector3Int(position.x - 1, position.y, position.z),
            new Vector3Int(position.x, position.y + 1, position.z),
            new Vector3Int(position.x, position.y - 1, position.z)
        };

        return neighbors;
    }

    private bool IsWalkable(Vector3Int position)
    {
        return tilemap.GetTile(position) == null; // 빈 타일이면 이동 가능
    }

    private float GetDistance(Vector3Int a, Vector3Int b)
    {
        return Vector3Int.Distance(a, b);
    }
}
