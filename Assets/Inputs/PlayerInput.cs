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
                },
                {
                    ""name"": ""RotateCamera"",
                    ""type"": ""Button"",
                    ""id"": ""e650695c-fbf2-4a0c-8ca2-71944dd84442"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""39b8e418-2e93-456e-b6dc-2b647715233f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""68d49809-8142-4db4-ac40-08aae45ce50f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""4e79f008-9cbd-40b8-8e08-ce6734d84b04"",
                    ""expectedControlType"": ""Button"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""d89526e0-237b-4a9e-be0b-1f4e20f763f8"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9b4dede-e0a3-44e6-bc11-be8a87ba94cf"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58d16f25-fb7a-4d8b-8b2b-38d3fd343b0b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1979a61c-ef4f-495c-986e-791e344b19ed"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        m_InGameInputs_RotateCamera = m_InGameInputs.FindAction("RotateCamera", throwIfNotFound: true);
        m_InGameInputs_MouseDelta = m_InGameInputs.FindAction("MouseDelta", throwIfNotFound: true);
        m_InGameInputs_RotateLeft = m_InGameInputs.FindAction("RotateLeft", throwIfNotFound: true);
        m_InGameInputs_RotateRight = m_InGameInputs.FindAction("RotateRight", throwIfNotFound: true);
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
    private readonly InputAction m_InGameInputs_RotateCamera;
    private readonly InputAction m_InGameInputs_MouseDelta;
    private readonly InputAction m_InGameInputs_RotateLeft;
    private readonly InputAction m_InGameInputs_RotateRight;
    public struct InGameInputsActions
    {
        private @PlayerInput m_Wrapper;
        public InGameInputsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Construct => m_Wrapper.m_InGameInputs_Construct;
        public InputAction @UnConstruct => m_Wrapper.m_InGameInputs_UnConstruct;
        public InputAction @MousePosition => m_Wrapper.m_InGameInputs_MousePosition;
        public InputAction @CameraMovement => m_Wrapper.m_InGameInputs_CameraMovement;
        public InputAction @RotateCamera => m_Wrapper.m_InGameInputs_RotateCamera;
        public InputAction @MouseDelta => m_Wrapper.m_InGameInputs_MouseDelta;
        public InputAction @RotateLeft => m_Wrapper.m_InGameInputs_RotateLeft;
        public InputAction @RotateRight => m_Wrapper.m_InGameInputs_RotateRight;
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
                @RotateCamera.started -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.performed -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.canceled -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnRotateCamera;
                @MouseDelta.started -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnMouseDelta;
                @RotateLeft.started -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.performed -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.canceled -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnRotateLeft;
                @RotateRight.started -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnRotateRight;
                @RotateRight.performed -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnRotateRight;
                @RotateRight.canceled -= m_Wrapper.m_InGameInputsActionsCallbackInterface.OnRotateRight;
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
                @RotateCamera.started += instance.OnRotateCamera;
                @RotateCamera.performed += instance.OnRotateCamera;
                @RotateCamera.canceled += instance.OnRotateCamera;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
                @RotateLeft.started += instance.OnRotateLeft;
                @RotateLeft.performed += instance.OnRotateLeft;
                @RotateLeft.canceled += instance.OnRotateLeft;
                @RotateRight.started += instance.OnRotateRight;
                @RotateRight.performed += instance.OnRotateRight;
                @RotateRight.canceled += instance.OnRotateRight;
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
        void OnRotateCamera(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnRotateLeft(InputAction.CallbackContext context);
        void OnRotateRight(InputAction.CallbackContext context);
    }
}
