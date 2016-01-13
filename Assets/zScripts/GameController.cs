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
	public Text wantedValue;
	public Text scoreText;
	public double wantedResistance;
	public double wantedVariance;
	public double numericalValue;
	public double variance;
	public double multiplierValue;
	int score;

	//timer variables
	private float startTime;
	private float restSeconds;
	private int roundedRestSeconds;
	private int displaySeconds;
	private int displayMinutes;
	public int countDownSeconds;
	public Text timerText;


	// Use this for initialization
	void Start () 
	{
		NewResistance ();
		score = 0;
	}

	void NewResistance()
	{
		wantedResistance = GenerateResistance ();
		wantedVariance = GenerateVariance ();
		//Debug.Log(CalculateDisplayTarget(wantedResistance,wantedVariance));
		wantedValue.text = CalculateDisplayTarget (wantedResistance, wantedVariance) + " Ohms" + "~" + wantedVariance + "%";
	}

	void Awake()
	{
		startTime = Time.time;
	}

	void FixedUpdate()
	{
		float guiTime = Time.time - startTime;

		restSeconds = countDownSeconds - guiTime;
		//display message

		if(restSeconds == 60)
		{
			print("one minute left");
		}

		if(restSeconds == 0)
		{
			print("time over");
		}

		roundedRestSeconds = Mathf.CeilToInt (restSeconds);
		displaySeconds = roundedRestSeconds % 60;
		displayMinutes = roundedRestSeconds / 60;

		string timer = string.Format ("{0:00}:{1:00}", displayMinutes, displaySeconds);

		//Debug.Log (timer);
		timerText.text = timer;

	}
	
	// Update is called once per frame
	void Update () 
	{
		string varianceTemp = GetVariance().ToString();
		value.text = CalculateDisplayValue () + " Ohms"  + "~" + varianceTemp + "%";
		numericalValue = CalculateNumericalValue ();
		variance = GetVariance ();

		if(wantedResistance == numericalValue && wantedVariance == variance)
		{
			score++;
			scoreText.text = score.ToString();
			NewResistance();
		}

	}

	double GetVariance ()
	{
		return band4.GetComponent<BandColorScript> ().bandValue;
	}

	double CalculateNumericalValue()
	{
		double temp = band1.GetComponent<BandColorScript>().bandValue + band2.GetComponent<BandColorScript>().bandValue;
		temp = temp * band3.GetComponent<BandColorScript> ().bandValue;
		return temp;
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

	double GenerateResistance()
	{
		double temp = Random.Range (0, 99);

		List<double> multipliers = new List<double>();

		multipliers.Add(0.01);
		multipliers.Add(0.10);
		multipliers.Add(1.0);
		multipliers.Add(100.0);
		multipliers.Add(1000.0);
		multipliers.Add(10000.0);
		multipliers.Add(100000.0);
		multipliers.Add(100000.0);
		multipliers.Add(1000000.0);
		//temp = temp * Random.Range(

		multiplierValue = multipliers[Random.Range(0,multipliers.Count)];
		return temp * multiplierValue;

	}

	double GenerateVariance()
	{
		List<double> variances = new List<double>();
		
		variances.Add(1);
		variances.Add(2);
		variances.Add(5);
		variances.Add(10);

		return variances [Random.Range (0, variances.Count)];
	}

	string CalculateDisplayTarget(double value, double var)
	{

		value = value / multiplierValue;
		Debug.Log (value);
		Debug.Log (multiplierValue);

		if(multiplierValue == 100)
		{
			return (value/10).ToString() + "k";
		}
		if(multiplierValue == 1000)
		{
			return value.ToString() + "k";
		}
		else if(multiplierValue == 10000)
		{
			return value.ToString() + "0k";
		}
		else if(multiplierValue == 100000)
		{
			return (value/10).ToString() + "M";
		}
		else if(multiplierValue == 1000000)
		{
			return value.ToString() + "M";
		}
		else
		{
			value = value * multiplierValue;
		}

		return value.ToString();
	}
}
