﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;

    public float healthBarLength;

    // Use this for initialization
    void Start()
    {
        healthBarLength = Screen.width / 6;
    }

    // Update is called once per frame
    void Update()
    {
        AddjustCurrentHealth(0);
    }

    void OnGUI()
    {

        Vector2 targetPos;
        targetPos = Camera.main.WorldToScreenPoint(transform.position);

        GUI.Box(new Rect(targetPos.x, Screen.height - targetPos.y, 60, 20), curHealth + "/" + maxHealth);

    }

    public void AddjustCurrentHealth(int adj)
    {
        curHealth += adj;

        if (curHealth < 0)
            curHealth = 0;

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;

        healthBarLength = (Screen.width / 6) * (curHealth / (float)maxHealth);
    }
}