 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Implements the toggle switch functionality. When the toggle is to active,
/// the color of it is changed to the one set up in the inspector.
/// </summary>
public class SwitchToggle : MonoBehaviour
{
    // RectTransform provides us with the current position of the handle.
    [SerializeField] RectTransform uiHandleRectTransform;

    // Stores the anchored position of the handle.
    Vector2 handleCurrentAnchoredPosition;

    // Toggle component variable, is assigned on awake.
    Toggle toggle;

    // The color that the handle and the button change to when activated.
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;

    // The default color of the handle and the button, should be taken from the
    // appropriate elements on awake.
    Image backgroundImage, handleImage;
    Color backgroundDefaultColor, handleDefaultColor;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        handleCurrentAnchoredPosition = uiHandleRectTransform.anchoredPosition;
        
        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;

        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn) OnSwitch(true);
        else OnSwitch(false);
    }

    private void Start()
    {
            
    }
    // Changes color of the button and the position of the handle depending on the boolean.
    void OnSwitch(bool on)
    {
        uiHandleRectTransform.anchoredPosition = on ? handleCurrentAnchoredPosition * -1 : handleCurrentAnchoredPosition;
        backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor;
        handleImage.color = on ? handleActiveColor : handleDefaultColor;
    }

    // Remove listener if the object is destroyed. I think this happens, when we switch to another screen/scene.
    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
