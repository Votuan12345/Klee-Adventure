using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : GameObjectRotation
{
    [SerializeField] List<Transform> chains;
    [SerializeField] Transform spikedBallOb;
    [SerializeField] private bool isRight;

    private int direction = 1;
    private void Start()
    {
        float posY = 0;
        for(int i = 0; i < chains.Count; i++)
        {
            chains[i].position = transform.position + new Vector3(0, posY, 0);
            posY+= 0.6f;
        }
        spikedBallOb.position = transform.position + new Vector3(0, posY + 0.57f, 0);
        direction = isRight ? -1 : 1;
    }

    protected override void Rotate()
    {
        transform.Rotate(0, 0, Time.fixedDeltaTime * speed * direction);
    }
}
