using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BuildingDatas buildingSelect ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectBuilding()
    {
        PlayerManager.Singleton.SetNewBuilding(buildingSelect);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Singleton.ShowBuildingPreviewUI();
        UIManager.Singleton.SetupPreviewDataInfos(buildingSelect);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Singleton.HideBuildingPreviewUI();
    }
}
