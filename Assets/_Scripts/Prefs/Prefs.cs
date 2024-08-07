using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    public static int characterSelectionIndex
    {
        get => PlayerPrefs.GetInt(GameConst.CharacterSelectionKey, 0);
        set
        {
            int curCharacter = PlayerPrefs.GetInt(GameConst.CharacterSelectionKey);

            if (value != curCharacter)
            {
                PlayerPrefs.SetInt(GameConst.CharacterSelectionKey, value);
            }
        }
    }
}
