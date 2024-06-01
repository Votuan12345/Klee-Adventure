using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameObjectMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected List<Transform> wayPoints;

    protected int waypointIndex;

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        if(wayPoints != null && wayPoints.Count > 0)
        {
            if(Vector2.Distance(transform.position, wayPoints[waypointIndex].position) < 0.1f)
            {
                waypointIndex++;
                if(waypointIndex >= wayPoints.Count)
                {
                    waypointIndex = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[waypointIndex].position, moveSpeed * Time.deltaTime);
        }
    }
}
