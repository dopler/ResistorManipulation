using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BandColorScript : MonoBehaviour 
{

	public List<Material> bandColors;
	public int materialIndex;
	public int bandNumber;

	public double bandValue;


	// Use this for initialization
	void Start () 
	{
		materialIndex = 0;
		this.GetComponent<MeshRenderer>().material = bandColors [materialIndex];
		bandValue = 0;

	}


	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Right()
	{
		if(materialIndex == bandColors.Count -1)
		{
			materialIndex = 0;
		}
		else
		{
			materialIndex =  Mathf.Abs ((materialIndex + 1) % bandColors.Count);
		}

		this.GetComponent<MeshRenderer>().material = bandColors [materialIndex];
		bandValue = GetBandValue (bandNumber, materialIndex);

	}

	public void Left()
	{
		if(materialIndex == 0)
		{
			materialIndex = bandColors.Count - 1;
		}
		else
		{
			materialIndex =  Mathf.Abs ((materialIndex - 1) % bandColors.Count);
		}
		this.GetComponent<MeshRenderer>().material = bandColors [materialIndex];
		bandValue = GetBandValue (bandNumber, materialIndex);
	}

	public double GetBandValue(int bandNum, int index)
	{
		switch(bandNum)
		{
			case 1:
				return index * 10;
			case 2:
				if(index == 0)
				{
					return 0;
				}
				return index-1;
			case 3:
				if(index == 0)
				{
					return 0;
				}
				else if(index == 8)
				{
					return 0.1;
				}
				else if(index == 9)
				{
					return 0.01;
				}

				double total = 1.0;
				for(int i = 0; i < index - 1; i++)
				{
					total *= 10;
				}
				return total;
			case 4:
				if(index == 0)
				{
					return 0;
				}
				else if(index == 1)
				{
					return 1;
				}
				else if(index == 2)
				{
					return 2;
				}
				else if(index == 3)
				{
					return 5;
				}
				else if(index == 4)
				{
					return 10;
				}
				return 0;
			default:
				return 0;
		}

	}
}
