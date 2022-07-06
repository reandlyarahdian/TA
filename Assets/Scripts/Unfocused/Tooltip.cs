using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI textContent;
    public List<TooltipTrigger> triggers;

    public void SetText(string text)
    {
        textContent.text = text;
    }
    private void Update()
    {
        foreach(var trigger in triggers)
        {
            if (trigger.clicked)
            {
                transform.position = trigger.transform.position + (Vector3.up * 75f);
            }
        }
    }
}
