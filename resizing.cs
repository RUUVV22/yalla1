using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resizing : MonoBehaviour
{
    //public GameObject toggle;
    //public Text toggleText;
    public float padding = 10f;
    public float AdjustToggleSize(GameObject toggle)
    {
        if (toggle == null)
        {
            Debug.LogError("Toggle is missing.");
            return 0;
        }

        Text toggleText = toggle.GetComponentInChildren<Text>();
        if (toggleText == null)
        {
            Debug.LogError("Text component is missing.");
            return 0;
        }

        // Calculate the preferred width of the text
        float preferredWidth = toggleText.preferredWidth;

        // Get the RectTransform component of the toggle
        RectTransform toggleRectTransform = toggle.GetComponent<RectTransform>();

        // Set the width of the toggle based on the text width and padding
        toggleRectTransform.sizeDelta = new Vector2(preferredWidth + padding, toggleRectTransform.sizeDelta.y);

        // Return the calculated width
        return toggleRectTransform.sizeDelta.x;
    }
}
