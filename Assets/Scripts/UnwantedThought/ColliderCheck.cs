using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] private Check check;
    [SerializeField]UnityEvent kabur,
    tabrak,
    menang,
    kanan,
    kiri,
    lurus,
    putarbalik;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            check = other.GetComponent<EnumStoring>().check;
            switch (check)
            {
                case Check.empty:
                    break;
                case Check.kabur:
                    kabur.Invoke();
                    break;
                case Check.tabrak:
                    tabrak.Invoke();
                    break;
                case Check.menang:
                    menang.Invoke();
                    break;
                case Check.kanan:
                    kanan.Invoke();
                    break;
                case Check.kiri:
                    kiri.Invoke();
                    break;
                case Check.lurus:
                    lurus.Invoke();
                    break;
                case Check.putarbalik:
                    putarbalik.Invoke();
                    break;
            }
        }
    }
}
