using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenManager : MonoBehaviour
{
    [SerializeField] RectTransform Option, Play, Quest, Health, Coin, Star;
    [SerializeField] Image panelImg;
    [SerializeField] AnimationCurve ButtonCurve;
    [SerializeField] Image curtainR, curtainL;

    public GameObject Unavailable;

    public void Panel(bool active)
    {
        panelImg.gameObject.SetActive(active);
    }

    public void TweeningButtonsOut()
    {
        LeanTween.move(Option, new Vector3(60, 60, 0), 1f).setEase(ButtonCurve);
        LeanTween.move(Play, new Vector3(60, -60, 0), 1f).setEase(ButtonCurve);
        LeanTween.move(Quest, new Vector3(-60, -60, 0), 1f).setEase(ButtonCurve);
        LeanTween.move(Health, new Vector3(67.5f, 60, 0), 1f).setEase(ButtonCurve);
        LeanTween.move(Coin, new Vector3(400, 60, 0), 1f).setEase(ButtonCurve);
        LeanTween.move(Star, new Vector3(-200, 60, 0), 1f).setEase(ButtonCurve);
        var _color = panelImg.color;
        LeanTween.value(panelImg.gameObject, _color.a , .65f, 0.5f).setOnUpdate((float _value) => {
            _color.a = _value;
            panelImg.color = _color;
        });
    }
    public void TweeningButtonsIn()
    {
        LeanTween.move(Option, new Vector3(-60, -60, 0), 1f).setEase(ButtonCurve);
        LeanTween.move(Play, new Vector3(-60, 60, 0), 1f).setEase(ButtonCurve);
        LeanTween.move(Quest, new Vector3(60, 60, 0), 1f).setEase(ButtonCurve);
        LeanTween.move(Health, new Vector3(135, -60, 0), 1f).setEase(ButtonCurve);
        LeanTween.move(Coin, new Vector3(400, -60, 0), 1f).setEase(ButtonCurve);
        LeanTween.move(Star, new Vector3(-200, -60, 0), 1f).setEase(ButtonCurve);
        var _color = panelImg.color;
        LeanTween.value(panelImg.gameObject, _color.a, 0f,.5f).setOnUpdate((float _value) => {
            _color.a = _value;
            panelImg.color = _color;
        });
    }

    public void Scaling(GameObject obj, float xScale, float yScale, float zScale, float time)
    {
        Vector3 scale = obj.transform.localScale;
        LeanTween.value(obj, scale, new Vector3(xScale, yScale, zScale), time).setOnUpdate((Vector3 _value) => {
            scale = _value;
            obj.transform.localScale = scale;
        }).setEase(ButtonCurve);
    }

    public void ScalingObj(bool active)
    {
        if (active)
        {
            Unavailable.SetActive(true);
            Scaling(Unavailable, 1, 1, 1, .5f);
        }
        else
        {
            Unavailable.SetActive(false);
            Scaling(Unavailable, 0, 0, 0, .5f);
        }
    }

    public void Curtain (bool active)
    {
        if (active)
        {
            Scaling(curtainL.gameObject, 12, 1, 1, .5f);
            Scaling(curtainR.gameObject, 12, 1, 1, .5f);
        }
        else
        {
            Scaling(curtainL.gameObject, 0, 1, 1, .5f);
            Scaling(curtainR.gameObject, 0, 1, 1, .5f);
        }
    }
}


