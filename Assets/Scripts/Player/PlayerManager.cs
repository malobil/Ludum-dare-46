using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private BuildingDatas m_SelectedBuild;
    
    private float actualMoney ;

    private PlayerInput inputs ;
    private Vector2 mousePosition;

    private void Awake()
    {
        inputs = new PlayerInput();
        inputs.InGameInputs.Construct.performed += ctx => Build();
        inputs.InGameInputs.UnConstruct.performed += ctx => UnBuild();
        inputs.Enable();   
    }

    private void Build()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(mouseRay, out hitInfo))
        {
            if(actualMoney >= m_SelectedBuild.cost)
            {
                if (hitInfo.transform.gameObject.GetComponentInParent<IConstructable>() != null)
                {
                    hitInfo.transform.gameObject.GetComponentInParent<IConstructable>().Construct(m_SelectedBuild);
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

    // Start is called before the first frame update
    void Start()
    {
        
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
}
