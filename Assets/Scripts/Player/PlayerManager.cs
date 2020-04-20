using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Singleton { get; private set; }

    [Header("Preview")]
    [SerializeField] private Color m_PreviewColor;
    [SerializeField] private Color m_PreviewColorError;
    [SerializeField] private LayerMask m_PreviewLayers;
    private GameObject actualPreviewBuilding;
    private List<GameObject> previewBuildingList = new List<GameObject>();
    private List<Material> previewBuildingMaterials = new List<Material>();
    private ConstructableTerrain targetedConstructTerrain;

    private BuildingDatas m_SelectedBuild;

    private int selectedBuildingRotation = 0;

    public float actualMoney;
    public float actualFaith;
    public float actualFood;
    public float actualWater;
    public float actualEntertainment;
    public float actualPopulation;
    public float actualPopulationCapacity;

    [Header("Balance")]
    [SerializeField] private float faithLoosePerSecond;
    [SerializeField] private float foodLoosePerSecond;
    [SerializeField] private float waterLoosePerSecond;
    [SerializeField] private float entertainmentLoosePerSecond;
    [SerializeField] private float timeToAddPopulation = 15f;
    [SerializeField] private float populationAdd;
    [SerializeField] private float ressourceLooseAddPerHab = 1f ;


    [SerializeField] private float faithToWin;

    [Header("Population")]
    public GameObject prefabPeopleF;
    public GameObject prefabPeopleM;
    public Transform peoplePopPoint;

    private bool havePopAM = true;

    private PlayerInput inputs;
    private Vector2 mousePosition;

    private bool gameIsPEnd= false;

    private void Awake()
    {
        if (Singleton != null)
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
        inputs.InGameInputs.Pause.performed += ctx => PauseGame();
        inputs.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Singleton.UpdateMoneyText(actualMoney);
        UIManager.Singleton.UpdateEntertainmentText(actualEntertainment);
        UIManager.Singleton.UpdateFaithText(actualFaith);
        UIManager.Singleton.UpdateFoodText(actualFood);
        UIManager.Singleton.UpdatePopulationText(actualPopulation, actualPopulationCapacity);
        UIManager.Singleton.UpdateWaterText(actualWater);
        StartCoroutine(LooseRessources());
        StartCoroutine(GainPop());
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
        foreach (GameObject previews in previewBuildingList)
        {
            Destroy(previews);
        }

        previewBuildingMaterials.Clear();
        previewBuildingList.Clear();
        selectedBuildingRotation = 0;

        for (int i = 0; i < m_SelectedBuild.prefabs.Count; i++)
        {
            GameObject spawnedPrefab = Instantiate(m_SelectedBuild.prefabs[i]);

            if (spawnedPrefab.GetComponent<Collider>())
            {
                spawnedPrefab.GetComponent<Collider>().enabled = false;
            }

            if (spawnedPrefab.GetComponent<Building>())
            {
                spawnedPrefab.GetComponent<Building>().enabled = false;
            }

            if (spawnedPrefab.GetComponent<Renderer>())
            {
                Renderer spawnedPrefabRend = spawnedPrefab.GetComponent<Renderer>();
                SetMaterialTransparent(spawnedPrefabRend.material);
                spawnedPrefabRend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                spawnedPrefabRend.receiveShadows = false;
                previewBuildingMaterials.Add(spawnedPrefabRend.material);
            }

            foreach (Transform childs in spawnedPrefab.transform)
            {
                if (childs.GetComponent<Renderer>())
                {
                    Renderer childRendComp = childs.GetComponent<Renderer>();
                    SetMaterialTransparent(childRendComp.material);
                    childRendComp.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    childRendComp.receiveShadows = false;
                    previewBuildingMaterials.Add(childRendComp.material);
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

            if (Physics.Raycast(mouseRay, out hitInfo, 999f, m_PreviewLayers) && !hitInfo.transform.gameObject.CompareTag("Collect"))
            {
                targetedConstructTerrain = hitInfo.transform.gameObject.GetComponentInParent<ConstructableTerrain>();

                if (targetedConstructTerrain != null)
                {
                    if (!targetedConstructTerrain.CheckNearTile(actualPreviewBuilding.GetComponent<Building>().buildingDirection, m_SelectedBuild.tileSize))
                    {
                        ChangeAllPreviewMatColor(m_PreviewColorError);
                    }
                    else
                    {
                        ChangeAllPreviewMatColor(m_PreviewColor);
                    }
                }
                else
                {
                    ChangeAllPreviewMatColor(m_PreviewColorError);
                }

                actualPreviewBuilding.transform.position = hitInfo.transform.position;
                actualPreviewBuilding.SetActive(true);
            }
            else
            {
                targetedConstructTerrain = null;
                actualPreviewBuilding.SetActive(false);
            }
        }
        else if (UIManager.Singleton.CheckCursorOnUI() && m_SelectedBuild != null)
        {
            actualPreviewBuilding.SetActive(false);
        }
    }

    private void Build()
    {
        if (m_SelectedBuild != null && !UIManager.Singleton.CheckCursorOnUI())
        {
            if (actualMoney >= m_SelectedBuild.cost)
            {
                if (targetedConstructTerrain != null)
                {
                    targetedConstructTerrain.Construct(m_SelectedBuild, selectedBuildingRotation);
                    AddMoney(-m_SelectedBuild.cost);
                    UIManager.Singleton.UpdateMoneyText(actualMoney);
                }
            }
        }
    }

    private void Collect()
    {
        if (!UIManager.Singleton.CheckCursorOnUI())
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(mouseRay, out hitInfo))
            {
                Debug.Log(hitInfo.collider.gameObject);
                if (hitInfo.transform.gameObject.CompareTag("Collect"))
                {
                    hitInfo.transform.gameObject.GetComponentInParent<Building>().CollectThisType();
                }
            }
        }
    }

    private void UnBuild()
    {
        if (!UIManager.Singleton.CheckCursorOnUI())
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
        if (m_SelectedBuild != null)
        {
            if (selectedBuildingRotation <= 0)
            {
                selectedBuildingRotation = m_SelectedBuild.prefabs.Count - 1;
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
        if (m_SelectedBuild != null)
        {
            if (selectedBuildingRotation >= m_SelectedBuild.prefabs.Count - 1)
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
        if (actualFaith + addedValue < 0)
        {
            actualFaith = 0;
        }
        else
        {
            actualFaith += addedValue;
        }

        UIManager.Singleton.UpdateFaithText(actualFaith);

        if(actualFaith <= 0)
        {
            UIManager.Singleton.ShowLosse();
            gameIsPEnd = true;
            inputs.Disable();
        }

        if (actualFaith >= faithToWin)
        {
            UIManager.Singleton.ShowVictory();
            gameIsPEnd = true;
            inputs.Disable();
        }
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
        if (actualPopulation + addedValue < 0)
        {
            actualPopulation = 0;
        }
        else
        {
            actualPopulation += addedValue;
        }

        UIManager.Singleton.UpdatePopulationText(actualPopulation, actualPopulationCapacity);
        foodLoosePerSecond += ressourceLooseAddPerHab;
        waterLoosePerSecond += ressourceLooseAddPerHab;
        entertainmentLoosePerSecond += ressourceLooseAddPerHab;
    }

    public void AddPopulationCapacity(float addedValue)
    {
        if (actualPopulationCapacity + addedValue < 0)
        {
            actualPopulationCapacity = 0;
        }
        else
        {
            actualPopulationCapacity += addedValue;
        }

        UIManager.Singleton.UpdatePopulationText(actualPopulation, actualPopulationCapacity);
    }

    IEnumerator LooseRessources()
    {
        yield return new WaitForSeconds(1f);

        if(actualEntertainment <= 0 || actualFood <= 0 || actualWater <= 0 || actualPopulation > actualPopulationCapacity)
        {
            AddFaith(-faithLoosePerSecond);
        }
        else
        {
            AddFaith(faithLoosePerSecond);
        }

        AddFood(-foodLoosePerSecond);
        AddWater(-waterLoosePerSecond);
        AddEntertainment(-entertainmentLoosePerSecond);
        StartCoroutine(LooseRessources());
    }

    IEnumerator GainPop()
    {
        yield return new WaitForSeconds(timeToAddPopulation);
        AddPopulation(populationAdd);
        SpawnAnHabitant();
        StartCoroutine(GainPop());
    }

    void SpawnAnHabitant()
    {
        if (havePopAM)
        {
            Instantiate(prefabPeopleF, peoplePopPoint.position, prefabPeopleF.transform.rotation);
            havePopAM = false;
        }
        else
        {
            Instantiate(prefabPeopleM, peoplePopPoint.position, prefabPeopleF.transform.rotation);
            havePopAM = true;
        }

    }

    void ChangeAllPreviewMatColor(Color newColor)
    {
        foreach (Material mats in previewBuildingMaterials)
        {
            mats.color = newColor;
        }
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

    void PauseGame()
    {
        UIManager.Singleton.TogglePause();
    }

}
