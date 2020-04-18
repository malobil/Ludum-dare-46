// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""InGameInputs"",
            ""id"": ""98faa84a-c851-4188-b471-5e36ca564e87"",
            ""actions"": [
                {
                    ""name"": ""Construct"",
                    ""type"": ""Button"",
                    ""id"": ""1c6c5929-e963-4036-828b-5a7c5c2166b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UnConstruct"",
                    ""type"": ""Button"",
                    ""id"": ""f3f7c362-cf57-4cd2-8c29-53cd4064b0e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""d46ab858-ce17-4373-b2c5-f46bd37006ee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Value"",
                    ""id"": ""7bdeda3f-b0e3-44ea-b767-7a8e75e27e22"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""25d50f86-e88e-4643-8cc7-a9099dd5bb51"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Construct"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""528d3641-d9c2-46ac-b820-e48692a02186"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Construct"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a79c44de-6c76-4459-af4a-2151aca68a16"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27887716-fc6d-426b-95bf-7e6b9f29c2af"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UnConstruct"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Movement"",
                    ""id"": ""509b3065-11d0-4fc9-8d93-8fa33b0ade0a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fe469514-ce16-407e-850a-e38b970ddd52"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d47ab8d3-1b5f-4779-81a6-9d6d80e7f9a7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a9c5066e-85b4-4914-9e22-c73502612a64"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3475aca7-9961-4e72-a7fa-fe6db04a3106"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InGameInputs
        m_InGameInputs = asset.FindActionMap("InGameInputs", throwIfNotFound: true);
        m_InGameInputs_Construct = m_InGameInputs.FindAction("Construct", throwIfNotFound: true);
        m_InGameInputs_UnConstruct = m_InGameInputs.FindAction("UnConstruct", throwIfNotFound: true);
        m_InGameInputs_MousePosition = m_InGameInputs.FindAction("MousePosition", throwIfNotFound: true);
        m_InGameInputs_CameraMovement = m_InGameInputs.FindAction("CameraMovement", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // InGameInputs
    private readonly InputActionMap m_InGameInputs;
    private IInGameInputsActions m_InGameInputsActionsCallbackInterface;
    private readonly InputAction m_InGameInputs_Construct;
    private readonly InputAction m_InGameInputs_UnConstruct;
    private readonly InputAction m_InGameInputs_MousePosition;
    private readonly InputAction m_InGameInputs_CameraMovement;
    public struct InGameInputsActions
    {
        private @PlayerInput m_Wrapper;
        public InGameInputsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Construct => m_Wrapper.m_InGameInputs_Construct;
        public InputAction @UnConstruct => m_Wrapper.m_InGameInputs_UnConstruct;
        public InputAction @MousePosition => m_Wrapper.m_InGameInputs_MousePosition;
        public InputAction @CameraMovement => m_Wrapper.m_InGameInputs_CameraMovement;
        public InputActionMap Get() { return m_Wrapper.m_InGameInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameInputsActions set) { return set.Get(); }
        public void SetCallbacks(IInGameInputsActions instance)
        {
            if (m_Wrapper.m_InGameInputsActionsCallbackInterface != null)
            {
                @Construct.started -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnConstruct;
                @Construct.performed -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnConstruct;
                @Construct.canceled -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnConstruct;
                @UnConstruct.started -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnUnConstruct;
                @UnConstruct.performed -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnUnConstruct;
                @UnConstruct.canceled -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnUnConstruct;
                @MousePosition.started -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnMousePosition;
                @CameraMovement.started -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.performed -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.canceled -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnCameraMovement;
            }
            m_Wrapper.m_InGameInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Construct.started += instance.OnConstruct;
                @Construct.performed += instance.OnConstruct;
                @Construct.canceled += instance.OnConstruct;
                @UnConstruct.started += instance.OnUnConstruct;
                @UnConstruct.performed += instance.OnUnConstruct;
                @UnConstruct.canceled += instance.OnUnConstruct;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @CameraMovement.started += instance.OnCameraMovement;
                @CameraMovement.performed += instance.OnCameraMovement;
                @CameraMovement.canceled += instance.OnCameraMovement;
            }
        }
    }
    public InGameInputsActions @InGameInputs => new InGameInputsActions(this);
    public interface IInGameInputsActions
    {
        void OnConstruct(InputAction.CallbackContext context);
        void OnUnConstruct(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
    }
}
