using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform destination;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Player player = col.gameObject.GetComponent<Player>();  
            if(player != null)
            {
                if(Vector2.Distance(transform.position, player.transform.position) > 0.3f)
                {
                    StartCoroutine(PortalIn(player));
                }
            }
        }
    }

    IEnumerator PortalIn(Player player)
    {
        player.UpdatePortalInAnimation();
        StartCoroutine(MoveInPortal(player));
        yield return new WaitForSeconds(0.5f);

        player.transform.position = destination.position;
        player.UpdatePortalOutAnimation();

        yield return new WaitForSeconds(0.5f); 
        player.ResetPortalAnimation();
    }

    IEnumerator MoveInPortal(Player player)
    {
        float timer = 0;
        while(timer < 0.5f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
    }
}
