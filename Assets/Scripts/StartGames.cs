﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGames : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKey)
            SceneManager.LoadScene("Stage1");
    }
}