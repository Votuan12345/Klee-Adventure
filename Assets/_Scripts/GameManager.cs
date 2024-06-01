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

    #region ReloadGame
    public void ReloadGame()
    {
        UIManager.instance.ShowResumePanel(false);
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

    #region LoadNextLevel
    public void LoadNextLevel()
    {
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

    #region LoadHomeGame
    public void LoadHomeGame()
    {
        UIManager.instance.ShowResumePanel(false);
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

    #region ContinueGame
    public void ContinueGame()
    {
        UIManager.instance.ShowResumePanel(false);
        UIManager.instance.ShowGameOverPanel(false);
        UIManager.instance.ShowWinPanel(false);
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
