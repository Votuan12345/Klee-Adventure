using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private List<HealthUI> healthUIs;
    [SerializeField] private ItemCollectorUI itemCollectorUI;

    [Header("UIPanels")]
    [SerializeField] private GameObject resumePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private SceneTransition transition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if(transition != null)
            {
                transition.gameObject.SetActive(true);
            }
            if(Time.timeScale == 0) Time.timeScale = 1f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ShowResumePanel(false);
        ShowGameOverPanel(false);
        ShowWinPanel(false);
    }

    #region OnClickResumeButton
    public void OnClickResumeButton()
    {
        ShowResumePanel(true);
    }
    #endregion

    #region HealthUI
    public void ShowHealthReductionUI()
    {
        if (healthUIs == null || healthUIs.Count <= 0) return;
        foreach(HealthUI healthUI in healthUIs)
        {
            if (healthUI.IsOn)
            {
                healthUI.IsOn = false;
                healthUI.ShowHealth();
                return;
            }
        }
    }
    #endregion

    #region FruitsUI
    public void ShowFruitsUI()
    {
        itemCollectorUI.ShowTextFruits();
    }

    #endregion

    #region animationUI
    public void LoadAnimationEndGame()
    {
        transition.LoadAnimationEndGame();
    }
    #endregion

    #region UIPanels
    public void ShowResumePanel(bool value)
    {
        Time.timeScale = value ? 0f : 1f;

        if (resumePanel == null) return;
        resumePanel.SetActive(value);
    }

    public void ShowWinPanel(bool value)
    {
        Time.timeScale = value ? 0f : 1f;

        if (winPanel == null) return;
        winPanel.SetActive(value);
    }

    public void ShowGameOverPanel(bool value)
    {
        Time.timeScale = value ? 0f : 1f;

        if (gameOverPanel == null) return;
        gameOverPanel.SetActive(value);
    }

    #endregion

    #region LoadScence
    public void LoadHomeGame()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void LoadReplayGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion
}
