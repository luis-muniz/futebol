using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    //bola
    [SerializeField]
    private GameObject bola;
    private int bolasNum;
    private bool isBolasEmCena;
    private Transform pos;
    private bool possuiTiro;

    //
    //private int cenaAtual;

    private bool goal;

    private bool jogoComecou;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        SceneManager.sceneLoaded += Carrega;
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        if (FasesManager.instance.fase != 4)
        {
            this.pos = GameObject.Find("PosicaoInicialBola").GetComponent<Transform>();
            this.StartGame();
        }
    }


    void Start()
    {

        ScoreManager.instance.gameStartScoreM();
    }

    void Update()
    {
        ScoreManager.instance.UpdateScore();

        UIManager.instance.UpdateUI();

        this.NascBolas();

        if (this.bolasNum == 0 && !this.goal)
        {
            this.GameOver();
        }

        if (this.goal)
        {
            this.WinGame();
        }
    }

    private void GameOver()
    {
        UIManager.instance.GameOverUI();
        jogoComecou = false;
    }

    private void WinGame()
    {
        UIManager.instance.WinGameUI();
        jogoComecou = false;

    }

    private void StartGame()
    {
        jogoComecou = true;
        this.bolasNum = 3;
        this.goal = false;
        this.isBolasEmCena = false;
        UIManager.instance.StartUI();
    }

    private void NascBolas()
    {
        if(this.bolasNum > 0 && isBolasEmCena == false)
        {
            Instantiate(this.bola, new Vector2(this.pos.position.x, this.pos.position.y), Quaternion.identity);
            this.isBolasEmCena = true;
            this.possuiTiro = true;
        }
    }

    //gets e sets
    public void setBolasNum(int bolasNum)
    {
        this.bolasNum -= bolasNum;
    }

    public int getBolasNum()
    {
        return this.bolasNum;
    }

    public bool getBolaEmCena()
    {
        return this.isBolasEmCena;
    }

    public void setBolaEmCena(bool isBolasEmCena)
    {
        this.isBolasEmCena = isBolasEmCena;
    }

    public bool getPossuiTiro()
    {
        return this.possuiTiro;
    }

    public void setPossuiTiro(bool possuiTiro)
    {
        this.possuiTiro = possuiTiro;
    }

    public bool isGoal()
    {
        return this.goal;
    }

    public void isGoal(bool goal)
    {
        this.goal = goal;
    }
}
