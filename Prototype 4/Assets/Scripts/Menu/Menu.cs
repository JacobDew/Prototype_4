﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

	
	// Update is called once per frame
	void Update()
    {
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Test");
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
