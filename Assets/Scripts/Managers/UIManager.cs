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

    [Header("BuildingPreview")]
    [SerializeField] private GameObject m_PreviewUI;
    [SerializeField] private TextMeshProUGUI m_PreviewNameText;
    [SerializeField] private TextMeshProUGUI m_PreviewCostText;
    [SerializeField] private TextMeshProUGUI m_PreviewMoneyText;
    [SerializeField] private TextMeshProUGUI m_PreviewFoodText;
    [SerializeField] private TextMeshProUGUI m_PreviewWaterText;
    [SerializeField] private TextMeshProUGUI m_PreviewEntertainmentText;
    [SerializeField] private TextMeshProUGUI m_PreviewPopulationText;

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
        m_FaithText.text = newValue.ToString("F0");
    }

    public void UpdateMoneyText(float newValue)
    {
        m_MoneyText.text = newValue.ToString("F0");
    }

    public void UpdateFoodText(float newValue)
    {
        m_FoodText.text = newValue.ToString("F0");
    }

    public void UpdateWaterText(float newValue)
    {
        m_WaterText.text = newValue.ToString("F0");
    }

    public void UpdateEntertainmentText(float newValue)
    {
        m_EntertainmentText.text = newValue.ToString("F0");
    }

    public void UpdatePopulationText(float newValue)
    {
        m_PopText.text = newValue.ToString("F0");
    }

    public void SetupPreviewDataInfos(BuildingDatas data)
    {
        m_PreviewCostText.text = data.cost + "money";
        m_PreviewNameText.text = data.name;
        m_PreviewMoneyText.text = data.money + "money/sec";
        m_PreviewFoodText.text = data.food + "food/sec";
        m_PreviewWaterText.text = data.water + "water/sec";
        m_PreviewEntertainmentText.text = data.entertainment + "entertainment/sec";
        m_PreviewPopulationText.text = data.population + "population";
    }

    public void ShowBuildingPreviewUI()
    {
        m_PreviewUI.SetActive(true);
    }

    public void HideBuildingPreviewUI()
    {
        m_PreviewUI.SetActive(false);
    }

    public bool CheckCursorOnUI()
    {
        return m_EventSyst.IsPointerOverGameObject() ;
    }
 }
