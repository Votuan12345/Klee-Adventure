using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject healthOn;
    [SerializeField] private GameObject healthOff;

    private bool isOn;

    public bool IsOn { get => isOn; set => isOn = value; }

    private void Start()
    {
        isOn = true;
        ShowHealth();
    }

    public void ShowHealth()
    {
        if(healthOn != null)
        {
            healthOn.SetActive(isOn);
        }
        if(healthOff != null)
        {
            healthOff.SetActive(!isOn);
        }
    }
}
