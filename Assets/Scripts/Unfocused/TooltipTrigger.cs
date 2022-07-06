using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerClickHandler
{
    public string Text;
    public bool clicked;
    Coroutine delayCor;
    public void OnPointerClick(PointerEventData eventData)
    {
        clicked = true;
        if(delayCor != null)
            StopCoroutine(delayCor);
        delayCor = StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        TooltipSystem.current.Show(Text);
        yield return new WaitForSeconds(1f);
        TooltipSystem.current.Hide();
        clicked = false;
    }
}
