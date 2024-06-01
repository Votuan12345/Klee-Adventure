using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollectorUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textFruits;

    private void Start()
    {
        ShowTextFruits();
    }

    public void ShowTextFruits()
    {
        if (GameManager.instance == null) return;
        int fruits = GameManager.instance.Fruits;
        int maxFruits = GameManager.instance.MaxFruits;

        textFruits.text =  ":" + fruits.ToString() + "/" + maxFruits.ToString();
    }

}
