using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Node startNode;
    public Node finishNode;
    public List<Node> graph;
    [Range(0,5)]public float delay;

    public bool IsDesiredNode(Node node)
    {
        if (node.isFinishNode) return true;
        return false;
    }

    private void Start()
    {
        StartCoroutine(BreadthFirstSearch());
    }

    private bool HasNodeInList(Node node, List<Node> nodesList)
    {
        foreach (var n in nodesList)
        {
            if (n == node) return true;
        }
        return false;
    }

    public IEnumerator BreadthFirstSearch()
    {
        //создаем очередь с соседями стартовой точки
        var searchQueue = new Queue<Node>(startNode.neighbors);
        //создаем список для уже проверенных точек
        var checkedNodes = new List<Node>();
        // пока очередь не пуста
        while (searchQueue.Count > 0)
        {
            //извлекаем из очереди точку(ноду)
            var node = searchQueue.Dequeue();
            // если точки нет в списке проверенных
            if (!HasNodeInList(node, checkedNodes))
            {
                // если это конечная точка
                if (IsDesiredNode(node))
                {
                    // выводим сообщение о том что нашли точку
                    Debug.Log("Finish node is: " + node.name);
                    // и прерываем алгоритм
                }
                
                // если это не конечная точка
                else
                {
                    Debug.Log("It is not finish");
                    //добавляем всех соседей этой точки в очередь
                    foreach (var n in node.neighbors)
                    {
                        searchQueue.Enqueue(n);
                    }
                    // добавляем точку в проверенные
                    checkedNodes.Add(node);
                    node.isChecked = true;
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }

    private void SetGraph()
    {
        foreach (Transform t in transform)
        {
            graph.Add(t.GetComponent<Node>());
        }
    }

    private void OnDrawGizmos()
    {
        if (graph.Count == 0)
        {
            SetGraph();
        }
    }
}
