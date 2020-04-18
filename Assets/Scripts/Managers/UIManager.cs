using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [Header("Ressources UI")]
    [SerializeField] private TextMeshProUGUI m_FaithText;
    [SerializeField] private TextMeshProUGUI m_MoneyText;
    [SerializeField] private TextMeshProUGUI m_FoodText;
    [SerializeField] private TextMeshProUGUI m_WaterText;
    [SerializeField] private TextMeshProUGUI m_EntertainmentText;
    [SerializeField] private TextMeshProUGUI m_PopText;

    [Header("Event system")]
    [SerializeField] private EventSystem m_EventSyst;

    public static UIManager Singleton { get; private set; }

    private void Awake()
    {
        if(Singleton)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
        }
    }

    public void UpdateFaithText(float newValue)
    {
        m_FaithText.text = newValue.ToString();
    }

    public void UpdateMoneyText(float newValue)
    {
        m_MoneyText.text = newValue.ToString();
    }

    public void UpdateFoodText(float newValue)
    {
        m_FoodText.text = newValue.ToString();
    }

    public void UpdateWaterText(float newValue)
    {
        m_WaterText.text = newValue.ToString();
    }

    public void UpdateEntertainmentText(float newValue)
    {
        m_EntertainmentText.text = newValue.ToString();
    }

    public void UpdatePopulationText(float newValue)
    {
        m_PopText.text = newValue.ToString();
    }

    public bool CheckCursorOnUI()
    {
        return m_EventSyst.IsPointerOverGameObject() ;
    }
 }
