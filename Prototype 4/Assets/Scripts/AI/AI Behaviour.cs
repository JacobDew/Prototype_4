using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIBehaviour : MonoBehaviour
{
    private GameObject[] m_Entities;
    private GameObject m_Player;


	// Use this for initialization
	void Start()
    {
        m_Entities = GameObject.FindGameObjectsWithTag("Entities");
        m_Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}
}
