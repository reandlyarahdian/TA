using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Linq;

public class Cart : MonoBehaviour
{
    public List<NamePrice> names = new List<NamePrice>();
	public float Cash;
	public TextMeshPro text;

    private void Start()
    {
		Cash = Random.Range(99, 301);
		text.text = Cash.ToString();
		text.gameObject.SetActive(false);
    }

    public void AddObject(string name, float price)
    {
		NamePrice namePrice = new NamePrice(name, price);
		ManikLevelManager.instance.Compare(namePrice);
		names.Add(namePrice);
    }

	public void ShowMoney(float total)
    {
		text.gameObject.SetActive(true);
		text.text = total.ToString();
    }
}

[System.Serializable]
public class NamePrice
	{
		public string Name;
		public float Val;
		public NamePrice(string name, float val){
			this.Name = name; this.Val = val;
		}
			
	}
