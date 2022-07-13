using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonCollor : MonoBehaviour
{
    public string color;
    public ColoringButton buttons;

    private void Coloring()
    {
        switch (buttons)
        {
            case ColoringButton.Me:
                color = "Merah";
                break;
            case ColoringButton.Ji:
                color = "Jingga";
                break;
            case ColoringButton.Ku:
                color = "Kuning";
                break;
            case ColoringButton.Hi:
                color = "Hijau";
                break;
            case ColoringButton.Bi:
                color = "Biru";
                break;
            case ColoringButton.Ni:
                color = "Nila";
                break;
            case ColoringButton.U:
                color = "Ungu";
                break;
            default:
                break;
        }
    }
}

public enum ColoringButton{
    Me,
    Ji,
    Ku,
    Hi,
    Bi,
    Ni,
    U
}
