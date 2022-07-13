using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameButtonManager : MonoBehaviour
{
    public string[] colors = {"Merah","Jingga","Kuning","Hijau","Biru","Nila","Ungu"};
    [SerializeField] TextMeshProUGUI text;
    int[] number = { 0, 1, 2, 3, 4, 5, 6 };
    int[] number2 = { 1, 5, 4, 6, 2, 0, 3 };
    int[] number3 = { 5, 6, 4, 2, 3, 0, 1 };



    private string ColorList(int[] list)
    {
        string _colors = $"{colors[list[0]]}, {colors[list[1]]}, {colors[list[2]]}, " +
            $"{colors[list[3]]}, {colors[list[4]]}, {colors[list[5]]}, {colors[list[6]]}";
        return _colors;
    } 
}
