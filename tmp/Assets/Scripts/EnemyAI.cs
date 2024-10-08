using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // ������ ��ǥ (�÷��̾�)
    public float moveSpeed = 2f; // �̵� �ӵ�
    public Tilemap tilemap; // Ÿ�ϸ� ����

    private List<Vector3Int> path; // A* �˰������� ���� ���

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
            yield return new WaitForSeconds(0.5f); // 1�ʸ��� ��� ����
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

            // ���� ��ġ�� ���������� ���� ���� �̵�
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                path.RemoveAt(0); // ���� ���� �̵�
            }
        }
    }

    // A* �˰����� ���� Node Ŭ����
    private class Node
    {
        public Vector3Int Position; // ����� ��ġ (�� ��ǥ)
        public float GCost; // ���� ���κ����� �̵� ���
        public float HCost; // ��ǥ �������� ���� ���
        public float FCost => GCost + HCost; // �� ���
        public Node Parent; // ���� ����� �θ� ���

        public Node(Vector3Int position, Node parent = null)
        {
            Position = position;
            Parent = parent;
        }
    }

    private List<Vector3Int> AStar(Vector3Int start, Vector3Int goal)
    {
        // A* �˰��� ����
        List<Vector3Int> path = new List<Vector3Int>();
        List<Node> openList = new List<Node>();
        HashSet<Vector3Int> closedSet = new HashSet<Vector3Int>();

        Node startNode = new Node(start);
        openList.Add(startNode);

        while (openList.Count > 0)
        {
            Node currentNode = openList[0];

            // ���� ���� FCost�� ���� ��� ����
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

            // ��ǥ�� �����ߴ��� Ȯ��
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

        return path; // ��θ� ã�� ������ ��� �� ����Ʈ ��ȯ
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
        return tilemap.GetTile(position) == null; // �� Ÿ���̸� �̵� ����
    }

    private float GetDistance(Vector3Int a, Vector3Int b)
    {
        return Vector3Int.Distance(a, b);
    }
}
