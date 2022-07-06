using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cashier : MonoBehaviour
{
    public TextMeshPro text;
    public List<NamePrice> bought = new List<NamePrice>();
    public float Total;
    private Coroutine prices;
    private bool isCart;
    private float cash;
    private Cart cart;

    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cart"))
        {
            cart = other.GetComponent<Cart>();
            bought = cart.names;
            cash = cart.Cash;
            cart.ShowMoney(cash);
            isCart = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && isCart)
        {
            if(prices != null)
                StopCoroutine(prices);
            prices = StartCoroutine(PriceCalc());
        }
    }

    IEnumerator PriceCalc()
    {
        float a = 0;
        foreach (var grocery in sum(bought))
        {
            text.gameObject.SetActive(true);
            text.text = $"{grocery.Key} Rp{grocery.Value}";
            yield return new WaitForSeconds(1f);
            a += grocery.Value;
            text.gameObject.SetActive(false);
        }
        text.gameObject.SetActive(true);
        text.text = $"Total {a}";
        Total = a;
        TotalCalc();
    }

    private void TotalCalc()
    {
        cash -= Total;
        if(cash < 0)
        {
            cart.ShowMoney(cash);
        }
        else
        {
            cart.ShowMoney(cash);
        }
        GameManager.Instance.Die();
    }

    private Dictionary<string, float> sum( List<NamePrice> prices)
    {
        return prices
            .GroupBy(x => x.Name)
            .ToDictionary(
            g => g.Key.ToString(),
            g => g
            .Select(x => (x.Val))
            .Sum());
    }
}
