using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectRotation : MonoBehaviour
{
     [SerializeField] protected float speed;

    protected virtual void FixedUpdate()
    {
        Rotate();
    }

    protected virtual void Rotate()
    {
        transform.Rotate(0, 0, Time.fixedDeltaTime * speed);
    }
}
