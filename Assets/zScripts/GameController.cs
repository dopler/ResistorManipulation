using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject band1;
	public GameObject band2;
	public GameObject band3;
	public GameObject band4;

	public Text value;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		string varianceTemp = GetVariance ();
		value.text = CalculateDisplayValue () + "% Ohms"  + "~" + varianceTemp ;
	}

	string GetVariance ()
	{
		return band4.GetComponent<BandColorScript> ().bandValue.ToString ();
	}

	string CalculateDisplayValue()
	{
		double temp = band1.GetComponent<BandColorScript>().bandValue + band2.GetComponent<BandColorScript>().bandValue;
		//temp = temp * band3.GetComponent<BandColorScript> ().bandValue;
		if(band3.GetComponent<BandColorScript>().bandValue == 100)
		{
			return (temp/10).ToString() + "k";
		}
		if(band3.GetComponent<BandColorScript>().bandValue == 1000)
		{
			return temp.ToString() + "k";
		}
		else if(band3.GetComponent<BandColorScript>().bandValue == 10000)
		{
			return temp.ToString() + "0k";
		}
		else if(band3.GetComponent<BandColorScript>().bandValue == 100000)
		{
			return (temp/10).ToString() + "M";
		}
		else if(band3.GetComponent<BandColorScript>().bandValue == 1000000)
		{
			return temp.ToString() + "M";
		}
		else
		{
			temp = temp * band3.GetComponent<BandColorScript> ().bandValue;
		}

		return temp.ToString();
	}
}
