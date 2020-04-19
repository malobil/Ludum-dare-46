using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Singleton { get; private set; }

   
    [SerializeField] private Color m_PreviewColor;
    private GameObject actualPreviewBuilding;
    private List<GameObject> previewBuildingList = new List<GameObject>();
    private BuildingDatas m_SelectedBuild;

    private int selectedBuildingRotation = 0;
    
    public float actualMoney ;
    public float actualFaith ;
    public float actualFood ;
    public float actualWater ;
    public float actualEntertainment ;
    public float actualPeople ;

    [Header("Balance")]
    [SerializeField] private float faithLoosePerSecond ;
    [SerializeField] private float foodLoosePerSecond ;
    [SerializeField] private float waterLoosePerSecond ;
    [SerializeField] private float entertainmentLoosePerSecond ;


    private PlayerInput inputs ;
    private Vector2 mousePosition;

    private void Awake()
    {
        if(Singleton != null)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
        }

        inputs = new PlayerInput();
        inputs.InGameInputs.Construct.performed += ctx => Build();
        inputs.InGameInputs.Construct.performed += ctx => Collect();
        inputs.InGameInputs.UnConstruct.performed += ctx => UnBuild();
        inputs.InGameInputs.RotateLeft.performed += ctx => RotateLeft();
        inputs.InGameInputs.RotateRight.performed += ctx => RotateRight();
        inputs.Enable();   
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Singleton.UpdateMoneyText(actualMoney);
        UIManager.Singleton.UpdateEntertainmentText(actualEntertainment);
        UIManager.Singleton.UpdateFaithText(actualFaith);
        UIManager.Singleton.UpdateFoodText(actualFood);
        UIManager.Singleton.UpdatePopulationText(actualPeople);
        UIManager.Singleton.UpdateWaterText(actualWater);
        StartCoroutine(LooseRessources());
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = inputs.InGameInputs.MousePosition.ReadValue<Vector2>();
        PreviewBuild();
    }

    public void SetNewBuilding(BuildingDatas newSelectedBuilding)
    {
        m_SelectedBuild = newSelectedBuilding;
        SetupPreviewObjects();
    }

    private void SetupPreviewObjects()
    {
        foreach(GameObject previews in previewBuildingList)
        {
            Destroy(previews);
        }

        previewBuildingList.Clear();
        selectedBuildingRotation = 0;

        for(int i = 0; i < m_SelectedBuild.prefabs.Count; i++)
        {
            GameObject spawnedPrefab = Instantiate(m_SelectedBuild.prefabs[i]);

            if (spawnedPrefab.GetComponent<Collider>())
            {
                spawnedPrefab.GetComponent<Collider>().enabled = false;
            }

            if(spawnedPrefab.GetComponent<Building>())
            {
                spawnedPrefab.GetComponent<Building>().enabled = false;
            }

            if (spawnedPrefab.GetComponent<Renderer>())
            {
                SetMaterialTransparent(spawnedPrefab.GetComponent<Renderer>().material);
                spawnedPrefab.GetComponent<Renderer>().material.color = m_PreviewColor;
                spawnedPrefab.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                spawnedPrefab.GetComponent<Renderer>().receiveShadows = false;
            }

            foreach (Transform childs in spawnedPrefab.transform)
            {
                if (childs.GetComponent<Renderer>())
                {
                    Renderer childRendComp = childs.GetComponent<Renderer>();
                    SetMaterialTransparent(childRendComp.material);
                    childRendComp.material.color = m_PreviewColor;
                    childRendComp.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    childRendComp.receiveShadows = false;
                }

                if (childs.GetComponent<Collider>())
                {
                    childs.GetComponent<Collider>().enabled = false;
                }
            }

            spawnedPrefab.SetActive(false);
            previewBuildingList.Add(spawnedPrefab);
        }

        actualPreviewBuilding = previewBuildingList[0];
    }

    private void PreviewBuild()
    {
        if (m_SelectedBuild != null && !UIManager.Singleton.CheckCursorOnUI())
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(mouseRay, out hitInfo) && hitInfo.transform.gameObject.GetComponentInParent<IConstructable>() != null)
            {
                    actualPreviewBuilding.transform.position = hitInfo.transform.position;
                    actualPreviewBuilding.SetActive(true);
            }
            else
            {
                actualPreviewBuilding.SetActive(false);
            }
        }
        else if(UIManager.Singleton.CheckCursorOnUI() && m_SelectedBuild != null)
        {
            actualPreviewBuilding.SetActive(false);
        }
    }

    private void Build()
    {
        if(m_SelectedBuild != null && !UIManager.Singleton.CheckCursorOnUI())
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

    private void Collect()
    {
        if(!UIManager.Singleton.CheckCursorOnUI())
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(mouseRay, out hitInfo))
            {
                if (hitInfo.transform.gameObject.CompareTag("Collect"))
                {
                    hitInfo.transform.gameObject.GetComponentInParent<Building>().Collect();
                }

            }
        }
    }

    private void UnBuild()
    {
        if(!UIManager.Singleton.CheckCursorOnUI())
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
    }

    private void RotateLeft()
    {
        if(m_SelectedBuild != null)
        {
            if (selectedBuildingRotation <= 0)
            {
                selectedBuildingRotation = m_SelectedBuild.prefabs.Count-1;
            }
            else
            {
                selectedBuildingRotation--;
            }

            actualPreviewBuilding.SetActive(false);
            actualPreviewBuilding = previewBuildingList[selectedBuildingRotation];
        }
       
    }

    private void RotateRight()
    {
        if(m_SelectedBuild != null)
        {
            if (selectedBuildingRotation >= m_SelectedBuild.prefabs.Count-1)
            {
                selectedBuildingRotation = 0;
            }
            else
            {
                selectedBuildingRotation++;
            }

            actualPreviewBuilding.SetActive(false);
            actualPreviewBuilding = previewBuildingList[selectedBuildingRotation];
        }
    }

    private void OnDisable()
    {
        inputs.InGameInputs.Construct.performed -= ctx => Build();
        inputs.Disable();
    }

    public void AddFaith(float addedValue)
    {
        if(actualFaith + addedValue < 0)
        {
            actualFaith = 0;
        }
        else
        {
            actualFaith += addedValue;
        }
       
        UIManager.Singleton.UpdateFaithText(actualFaith);
    }

    public void AddMoney(float addedValue)
    {
        if (actualMoney + addedValue < 0)
        {
            actualMoney = 0;
        }
        else
        {
            actualMoney += addedValue;
        }

        UIManager.Singleton.UpdateMoneyText(actualMoney);
    }

    public void AddFood(float addedValue)
    {
        if (actualFood + addedValue < 0)
        {
            actualFood = 0;
        }
        else
        {
            actualFood += addedValue;
        }

        UIManager.Singleton.UpdateFoodText(actualFood);
    }

    public void AddWater(float addedValue)
    {
        if (actualWater + addedValue < 0)
        {
            actualWater = 0;
        }
        else
        {
            actualWater += addedValue;
        }

        UIManager.Singleton.UpdateWaterText(actualWater);
    }

    public void AddEntertainment(float addedValue)
    {
        if (actualEntertainment + addedValue < 0)
        {
            actualEntertainment = 0;
        }
        else
        {
            actualEntertainment += addedValue;
        }

        UIManager.Singleton.UpdateEntertainmentText(actualEntertainment);
    }

    public void AddPopulation(float addedValue)
    {
        if (actualPeople + addedValue < 0)
        {
            actualPeople = 0;
        }
        else
        {
            actualPeople += addedValue;
        }

        UIManager.Singleton.UpdatePopulationText(actualPeople);
    }

    IEnumerator LooseRessources()
    {
        yield return new WaitForSeconds(1f);
        AddFaith(-faithLoosePerSecond);
        AddFood(-foodLoosePerSecond);
        AddWater(-waterLoosePerSecond);
        AddEntertainment(-entertainmentLoosePerSecond);
        StartCoroutine(LooseRessources());
    }

    void SetMaterialTransparent(Material mat)
    {
        mat.SetOverrideTag("RenderType", "Transparent");
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
    }

}
