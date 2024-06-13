using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : GameObjectMovement
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.parent = null;
        }
    }
}
