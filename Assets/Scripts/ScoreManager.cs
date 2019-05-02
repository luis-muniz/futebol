﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public int moedas;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void gameStartScoreM()
    {
        if (PlayerPrefs.HasKey("moedasSave"))
        {
            this.moedas = PlayerPrefs.GetInt("moedasSave");
        }
        else
        {
            this.moedas = 100;
            PlayerPrefs.SetInt("moedasSave",moedas);
        }
    }

    public void UpdateScore()
    {
        this.moedas = PlayerPrefs.GetInt("moedasSave");
    }

    public void ColetaMoedas(int coin)
    {
        this.moedas += coin;
        this.SalvarMoedas(this.moedas);
    }

    public void PerdeMoedas(int coin)
    {
        this.moedas -= coin;
        this.SalvarMoedas(this.moedas);
    }

    public void SalvarMoedas(int coin)
    {
        PlayerPrefs.SetInt("moedasSave", coin);
    }
}
