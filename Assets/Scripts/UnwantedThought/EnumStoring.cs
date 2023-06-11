using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Check
{
    empty,
    kabur,
    tabrak,
    menang,
    kanan,
    kiri,
    lurus,
    putarbalik
}

public class EnumStoring : MonoBehaviour
{
    public Check check;
}
