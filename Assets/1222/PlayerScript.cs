using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public string m_sName;
    public bool m_bShowData;
    
    [SerializeField]
    public PlayerData m_Data;
    public List<string> m_Items;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(m_Data.m_fHp);
	}
}
