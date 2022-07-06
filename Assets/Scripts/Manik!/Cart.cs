using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Cart : MonoBehaviour
{
    public List<NamePrice> names = new List<NamePrice>();
	public float Cash;
	public TextMeshPro text;

    private void Start()
    {
		Cash = Random.Range(100f, 1000f);
		text.text = Cash.ToString();
		text.gameObject.SetActive(false);
    }

    public void AddObject(string name, float price)
    {
		NamePrice namePrice = new NamePrice(name, price);
		names.Add(namePrice);
    }

	public void ShowMoney(float total)
    {
		text.gameObject.SetActive(true);
		text.text = total.ToString();
    }
}

public class NamePrice
	{
		public string Name { get; set; }
		public float Val{ get; set; }
		public NamePrice(string name, float val){
			this.Name = name; this.Val = val;
		}
			
	}
