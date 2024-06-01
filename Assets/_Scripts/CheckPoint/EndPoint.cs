using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (GameManager.instance == null) return;

        if (GameManager.instance.GetGameState() != GameManager.GameState.gameOver 
            || GameManager.instance.GetGameState() != GameManager.GameState.win)
        {
            if (col.CompareTag("Player"))
            {
                if (GameManager.instance.Fruits >= GameManager.instance.MaxFruits)
                {
                    GameManager.instance.SetGameState(GameManager.GameState.win);
                    if (AudioController.Instance != null)
                    {
                        AudioController.Instance.PlaySFX(AudioController.Instance.finish);
                    }
                    StartCoroutine(ShowWinPanel());
                }
            }
        }
    }

    IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(2f);
        UIManager.instance.ShowWinPanel(true);
    }
}
