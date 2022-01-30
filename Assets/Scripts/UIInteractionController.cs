using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;


public class UIInteractionController : MonoBehaviour
{
    [SerializeField] private GameObject uiController;
    [SerializeField] private GameObject baseController;
    [SerializeField] private InputActionReference inputActionReferenceUISwitcher;
    [SerializeField] private GameObject uiCanvasGameObject;
    private bool _isUICanvasActive = false;

  
    private void OnEnable()
    {
        inputActionReferenceUISwitcher.action.performed += ActivateUIMode;
    }
    private void OnDisable()
    {
        inputActionReferenceUISwitcher.action.performed -= ActivateUIMode;

    }

    private void Start()
    {
        //Deactivating UI Canvas Gameobject by default
        if (uiCanvasGameObject !=null)
        {
            uiCanvasGameObject.SetActive(false);

        }

        //Deactivating UI Controller by default
        uiController.GetComponent<XRRayInteractor>().enabled = false;
        uiController.GetComponent<XRInteractorLineVisual>().enabled = false;
    }

    /// <summary>
    /// This method is called when the player presses UI Switcher Button which is the input action defined in Default Input Actions.
    /// When it is called, UI interaction mode is switched on and off according to the previous state of the UI Canvas.
    /// </summary>
    /// <param name="obj"></param>
    private void ActivateUIMode(InputAction.CallbackContext obj)
    {
        if (!_isUICanvasActive)
        {
            _isUICanvasActive = true;

            //Activating UI Controller by enabling its XR Ray Interactor and XR Interactor Line Visual
            uiController.GetComponent<XRRayInteractor>().enabled = true;
            uiController.GetComponent<XRInteractorLineVisual>().enabled = true;

            //Deactivating Base Controller by disabling its XR Direct Interactor
            baseController.GetComponent<XRDirectInteractor>().enabled = false;

          

            //Activating the UI Canvas Gameobject
            uiCanvasGameObject.SetActive(true);
        }
        else
        {
            _isUICanvasActive = false;

            //De-Activating UI Controller by enabling its XR Ray Interactor and XR Interactor Line Visual
            uiController.GetComponent<XRRayInteractor>().enabled = false;
            uiController.GetComponent<XRInteractorLineVisual>().enabled = false;

            //Activating Base Controller by disabling its XR Direct Interactor
            baseController.GetComponent<XRDirectInteractor>().enabled = true;

            //De-Activating the UI Canvas Gameobject
            uiCanvasGameObject.SetActive(false);
        }

    }
}

