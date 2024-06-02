using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUI : MonoBehaviour
{
    [SerializeField] private GameObject homePanel;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject optionsPanel;
 
    private void Awake()
    {
        if (homePanel != null && levelPanel != null && optionsPanel != null)
        {
            homePanel.SetActive(true);
            levelPanel.SetActive(false);
            optionsPanel.SetActive(false);
        }
    }

    public void OnPlayButtonClick()
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.buttonClick);
        if (homePanel != null && levelPanel != null && optionsPanel != null)
        {
            homePanel.SetActive(false);
            levelPanel.SetActive(true);
            optionsPanel.SetActive(false);
        }
    }

    public void OnOptionsButtonClick() 
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.buttonClick);
        if (homePanel != null && levelPanel != null && optionsPanel != null)
        {
            homePanel.SetActive(false);
            levelPanel.SetActive(false);
            optionsPanel.SetActive(true);
        }
    }

    public void OnBackButtonClick()
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.buttonClick);
        if (homePanel != null && levelPanel != null && optionsPanel != null)
        {
            homePanel.SetActive(true);
            levelPanel.SetActive(false);
            optionsPanel.SetActive(false);
        }
    }

    public void OnQuitButtonClick()
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.buttonClick);
        Application.Quit();
    }

    #region Select level
    public void SelectLevel(int level)
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.buttonClick);
        SceneManager.LoadSceneAsync("Level" + level);
    }
    #endregion
}
