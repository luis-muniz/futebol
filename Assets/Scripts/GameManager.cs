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
    private int bolasNum = 3;
    private bool bolaMorreu = false;
    private int bolasEmCena = 0;
    private Transform pos;
    private bool possuiTiro;

    public void setBolasNum(int bolasNum)
    {
        this.bolasNum -= bolasNum;
    }

    public int getBolaEmCena()
    {
        return this.bolasEmCena;
    }

    public void setBolaEmCena(int bolasEmCena)
    {
        this.bolasEmCena = bolasEmCena;
    }

    public bool getPossuiTiro()
    {
        return this.possuiTiro;
    }

    public void setPossuiTiro(bool possuiTiro)
    {
        this.possuiTiro = possuiTiro;
    }

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
        this.pos = GameObject.Find("PosicaoInicialBola").GetComponent<Transform>();
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
    }

    private void NascBolas()
    {
        if(this.bolasNum > 0 && bolasEmCena == 0)
        {
            Instantiate(this.bola, new Vector2(this.pos.position.x, this.pos.position.y), Quaternion.identity);
            this.bolasEmCena += 1;
            this.possuiTiro = true;
        }
    }  
}
