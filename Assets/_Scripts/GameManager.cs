using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int maxFruits;
    private int fruits = 0;

    public enum GameState
    {
        playing,
        win,
        gameOver
    }

    private GameState gameState;

    public int Fruits { get => fruits; set => fruits = value; }
    public int MaxFruits => maxFruits;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            gameState = GameState.playing;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameState = GameState.playing;
    }

    #region OnClickReloadGame
    public void OnClickReloadGame()
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.buttonClick);
        UIManager.instance.ShowMenuPanel(false);
        UIManager.instance.ShowGameOverPanel(false);
        UIManager.instance.ShowWinPanel(false);
        StartCoroutine(ReLoadGameCoroutine());
    }
    private IEnumerator ReLoadGameCoroutine()
    {
        UIManager.instance.LoadAnimationEndGame();
        yield return new WaitForSeconds(1f);

        gameState = GameState.playing;
        UIManager.instance.LoadReplayGame();
    }
    #endregion

    #region OnClickNextLevel
    public void OnClickNextLevel()
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.buttonClick);
        UIManager.instance.ShowWinPanel(false);
        StartCoroutine (LoadNextLevelCoroutine());
    }

    private IEnumerator LoadNextLevelCoroutine()
    {
        UIManager.instance.LoadAnimationEndGame();
        yield return new WaitForSeconds(1f);

        gameState = GameState.playing;
        UIManager.instance.LoadNextLevel();
    }
    #endregion

    #region OnClickHomeGame
    public void OnClickHomeGame()
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.buttonClick);
        UIManager.instance.ShowMenuPanel(false);
        UIManager.instance.ShowGameOverPanel(false);
        UIManager.instance.ShowWinPanel(false);
        StartCoroutine(LoadHomeGameCoroutine());
    }

    private IEnumerator LoadHomeGameCoroutine()
    {
        UIManager.instance.LoadAnimationEndGame();
        yield return new WaitForSeconds(1f);

        UIManager.instance.LoadHomeGame();
    }
    #endregion

    #region OnClickResumeGame
    public void OnClickResumeGame()
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.buttonClick);
        UIManager.instance.ShowMenuPanel(false);
        UIManager.instance.ShowGameOverPanel(false);
        UIManager.instance.ShowWinPanel(false);
    }
    #endregion

    #region OnClickMenuButton
    public void OnClickMenuButton()
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.buttonClick);
        UIManager.instance.ShowMenuPanel(true);
    }
    #endregion

    public void SetGameState(GameState newState)
    {
        gameState = newState;
    }
    public GameState GetGameState()
    {
        return gameState;
    }
}
