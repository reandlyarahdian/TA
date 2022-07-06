using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TabBTN : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TabGroup tabGroup;

    public Image bacground;

    public UnityEvent selectedEvents;
    public UnityEvent unselectedEvents;


    public Sprite defaultSprt;
    public Color hoverColor;
    public Sprite selectedSprt;
    public Color tempColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        bacground = GetComponent<Image>();
        tabGroup.Subs(this);
    }

    public void Select()
    {
        if(selectedEvents != null)
            selectedEvents.Invoke();

        this.bacground.sprite = selectedSprt;
        this.bacground.color = tempColor;
    }

    public void Unselect()
    {
        if(unselectedEvents != null)
            unselectedEvents.Invoke();
    }

    public void ResetBTN()
    {
        this.bacground.sprite = defaultSprt;
        this.bacground.color = tempColor;
    }
}
