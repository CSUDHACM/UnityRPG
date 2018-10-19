using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {

    public string ArmorName;
    public int defense;
    private double percentDefense;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetArmorDefense()
    {
        return defense;
    }

    public double GetPercentDefense()
    {
        return percentDefense;
    }
}
