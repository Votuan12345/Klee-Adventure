using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : GameObjectRotation
{
    [SerializeField] List<Transform> chains;
    [SerializeField] Transform spikedBallOb;

    private void Start()
    {
        float posY = 0;
        for(int i = 0; i < chains.Count; i++)
        {
            chains[i].position = transform.position + new Vector3(0, posY, 0);
            posY+= 0.6f;
        }
        spikedBallOb.position = transform.position + new Vector3(0, posY + 1.17f, 0);
    }
}
