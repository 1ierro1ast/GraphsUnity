using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> neighbors;
    public List<float> distanceToNeighbors;

    public bool isStartNode;
    public bool isFinishNode;
    public bool isChecked;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        if(isStartNode) Gizmos.color = Color.blue;
        if(isFinishNode) Gizmos.color = Color.red;
        if(isChecked) Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, Vector3.one);
        if (neighbors.Count > 0)
        {
            distanceToNeighbors.Clear();
            foreach (var node in neighbors)
            {
                if (node != null)
                {
                    Debug.DrawLine(transform.position, node.transform.position, Color.green);
                        distanceToNeighbors.Add(
                            Vector3.Distance(transform.position, node.transform.position)
                            );
                }
            }
        }
    }
}
