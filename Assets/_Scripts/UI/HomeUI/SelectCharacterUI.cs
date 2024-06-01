using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private GameObject arrowLeftButton;
    [SerializeField] private GameObject arrowRightButton;

    private int index;

    private void Awake()
    {
        index = Prefs.characterSelectionIndex;

        if(characters != null && characters.Count > 0)
        {
            foreach(GameObject character in characters)
            {
                character.SetActive(false);
            }
            characters[index].SetActive(true);
            arrowRightButton.SetActive(index < characters.Count - 1);
            arrowLeftButton.SetActive(index > 0);
        }
    }

    public void OnArrowLeftButtonClick()
    {
        index--;
        index = Mathf.Clamp(index, 0, characters.Count-1);

        arrowLeftButton.SetActive(index > 0);
        arrowRightButton.SetActive(true);

        if (characters != null && characters.Count > 0)
        {
            foreach (GameObject character in characters)
            {
                character.SetActive(false);
            }
            characters[index].SetActive(true);
            Prefs.characterSelectionIndex = index;
        }
    }

    public void OnArrowRightButtonClick()
    {
        index++;
        index = Mathf.Clamp(index, 0, characters.Count - 1);

        arrowLeftButton.SetActive(true);
        arrowRightButton.SetActive(index < characters.Count - 1);

        if (characters != null && characters.Count > 0)
        {
            foreach (GameObject character in characters)
            {
                character.SetActive(false);
            }
            characters[index].SetActive(true);
            Prefs.characterSelectionIndex = index;
        }
    }
}
