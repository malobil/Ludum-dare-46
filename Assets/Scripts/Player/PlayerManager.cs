using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Singleton { get; private set; }

    [SerializeField] private BuildingDatas m_SelectedBuild;

    private int selectedBuildingRotation = 0;
    
    public float actualMoney ;
    public float actualFaith ;
    public float actualFood ;
    public float actualWater ;
    public float actualEntertainment ;
    public float actualPeople ;


    private PlayerInput inputs ;
    private Vector2 mousePosition;

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

        inputs = new PlayerInput();
        inputs.InGameInputs.Construct.performed += ctx => Build();
        inputs.InGameInputs.UnConstruct.performed += ctx => UnBuild();
        inputs.InGameInputs.RotateLeft.performed += ctx => RotateLeft();
        inputs.InGameInputs.RotateRight.performed += ctx => RotateRight();
        inputs.Enable();   
    }

    private void Build()
    {
        if(m_SelectedBuild != null)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(mouseRay, out hitInfo))
            {
                if (actualMoney >= m_SelectedBuild.cost)
                {
                    if (hitInfo.transform.gameObject.GetComponentInParent<IConstructable>() != null)
                    {
                        hitInfo.transform.gameObject.GetComponentInParent<IConstructable>().Construct(m_SelectedBuild, selectedBuildingRotation);
                        AddMoney(-m_SelectedBuild.cost);
                        UIManager.Singleton.UpdateMoneyText(actualMoney);
                    }
                }

            }
        }
    }

    private void UnBuild()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(mouseRay, out hitInfo))
        {
            if (hitInfo.transform.gameObject.GetComponentInParent<IUnconstructable>() != null)
            {
                hitInfo.transform.gameObject.GetComponentInParent<IUnconstructable>().UnContruct();
            }
        }
    }

    private void RotateLeft()
    {
        if(m_SelectedBuild != null)
        {
            if (selectedBuildingRotation <= 0)
            {
                selectedBuildingRotation = m_SelectedBuild.prefabs.Count;
            }
            else
            {
                selectedBuildingRotation--;
            }
        }
       
    }

    private void RotateRight()
    {
        if(m_SelectedBuild != null)
        {
            if (selectedBuildingRotation >= m_SelectedBuild.prefabs.Count)
            {
                selectedBuildingRotation = 0;
            }
            else
            {
                selectedBuildingRotation++;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Singleton.UpdateMoneyText(actualMoney);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = inputs.InGameInputs.MousePosition.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        inputs.InGameInputs.Construct.performed -= ctx => Build();
        inputs.Disable();
    }

    public void AddFaith(float addedValue)
    {
        actualFaith += addedValue;
    }

    public void AddMoney(float addedValue)
    {
        actualMoney += addedValue;
    }

    public void AddFood(float addedValue)
    {
        actualFood += addedValue;
    }

    public void AddWater(float addedValue)
    {
        actualWater += addedValue;
    }

    public void AddEntertainment(float addedValue)
    {
        actualEntertainment += addedValue;
    }

    public void AddPopulation(float addedValue)
    {
        actualPeople += addedValue;
    }

}
