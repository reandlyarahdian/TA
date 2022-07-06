using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem current;

    public Tooltip tooltip;

    private void Awake()
    {
        current = this;
    }
    public void Show(string text)
    {
        current.tooltip.SetText(text);
        current.tooltip.gameObject.SetActive(true);
    }

    public void Hide()
    {
        current.tooltip.gameObject.SetActive(false);
    }
}
