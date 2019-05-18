using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //moedas
    public static UIManager instance;
    public Text pontosUI;

    //bola
    private Text bolasText;

    //lose
    private GameObject losePainel;
    private Button reiniciarFaseBtnLose;
    private Button voltarFaseLoseBtnLose;

    //win
    private GameObject winPainel;
    private Button reiniciarFaseBtnWin;
    private Button voltarFaseLoseBtnWin;
    private Button proximaFaseBtnWin;

    //pause
    private GameObject pausePainel;
    private Button pauseBtn;
    private Button pauseReturnBtn;
    private Button pauseFasesBtn;

    //
    private int moedasAntes, moedasDepois;

    public void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
       
        SceneManager.sceneLoaded += Carrega;
        this.LigaDesligaPainel();
    }



    void Carrega(Scene cena, LoadSceneMode modo)
    {
        if (FasesManager.instance.fase != 4)
        {
            //elementos da UI pontos e bolas
            this.pontosUI = GameObject.Find("PontosUI").GetComponent<Text>();
            this.bolasText = GameObject.Find("BolasText").GetComponent<Text>();
            //paineis
            this.losePainel = GameObject.Find("PanelLose");            
            this.winPainel = GameObject.Find("PanelWin");
            this.pausePainel = GameObject.Find("PanelPause");
            //botoes de pause
            this.pauseBtn = GameObject.Find("PauseBotao").GetComponent<Button>();
            this.pauseReturnBtn = GameObject.Find("PauseReturnBtn").GetComponent<Button>();
            this.pauseFasesBtn = GameObject.Find("PauseFasesBtn").GetComponent<Button>();
            //botoes de lose
            this.voltarFaseLoseBtnLose = GameObject.Find("VoltarFasesLoseBtn").GetComponent<Button>();
            this.reiniciarFaseBtnLose = GameObject.Find("ReiniciarFaseBtn").GetComponent<Button>();
            //botoes de win
            this.reiniciarFaseBtnWin = GameObject.Find("ReiniciarFaseWinBtn").GetComponent<Button>();
            this.voltarFaseLoseBtnWin = GameObject.Find("VoltarFasesWinBtn").GetComponent<Button>();
            this.proximaFaseBtnWin = GameObject.Find("ProximaFaseWinBtn").GetComponent<Button>();

            //pause eventos
            this.pauseBtn.onClick.AddListener(this.PauseGameUI);
            this.pauseReturnBtn.onClick.AddListener(this.PauseReturnGameUI);
            this.pauseFasesBtn.onClick.AddListener(this.FasesPause);
            //lose eventos
            this.reiniciarFaseBtnLose.onClick.AddListener(this.ReiniciarFase);
            this.voltarFaseLoseBtnLose.onClick.AddListener(this.Fases);
            //win eventos
            this.reiniciarFaseBtnWin.onClick.AddListener(this.ReiniciarFase);
            this.voltarFaseLoseBtnWin.onClick.AddListener(this.Fases);
            this.proximaFaseBtnWin.onClick.AddListener(this.ProximaFase);

            //
            this.moedasAntes = PlayerPrefs.GetInt("moedasSave");

        }
    }

    public void StartUI()
    {
        this.LigaDesligaPainel();
    }

    public void UpdateUI()
    {
        pontosUI.text = ScoreManager.instance.getMoedas().ToString();
        bolasText.text = GameManager.instance.getBolasNum().ToString();
        this.moedasDepois = ScoreManager.instance.getMoedas();
    }

    //gamer over
    public void GameOverUI()
    {
        this.losePainel.SetActive(true);
    }

     //game win
    public void WinGameUI()
    {
        this.winPainel.SetActive(true);
    }

    public void ProximaFase()
    {
        SceneManager.LoadScene(FasesManager.instance.fase + 1);
    }

    //game pause
    public void PauseGameUI()
    {
        this.pausePainel.SetActive(true);
        pausePainel.gameObject.GetComponent<Animator>().Play("PainelPause");
        Time.timeScale = 0;
    }
    private void FasesPause()
    {
        Time.timeScale = 1;
        if (!GameManager.instance.isGoal())
        {
            int resultado = this.moedasDepois - this.moedasAntes;
            ScoreManager.instance.PerdeMoedas(resultado);
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(4);
        }        
    }



    //win,lose,pause
    private void ReiniciarFase()
    {
        if (!GameManager.instance.isGoal())
        {
            SceneManager.LoadScene(FasesManager.instance.fase);
            int resultado = this.moedasDepois - this.moedasAntes;
            ScoreManager.instance.PerdeMoedas(resultado);
        }
        else
        {
            SceneManager.LoadScene(FasesManager.instance.fase);
        }
    }

    private void Fases()
    {
        if (!GameManager.instance.isGoal())
        {
            int resultado = this.moedasDepois - this.moedasAntes;
            ScoreManager.instance.PerdeMoedas(resultado);
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }

    public void PauseReturnGameUI()
    {        
        pausePainel.gameObject.GetComponent<Animator>().Play("PainelPauseReturn");
        Time.timeScale = 1;
        StartCoroutine(esperarPause());
    }

    IEnumerator esperarPause()
    {
        yield return new WaitForSeconds(0.8f);
        this.pausePainel.SetActive(false);
    }

    IEnumerator tempo()
    {
        yield return new WaitForSeconds(0.001f);
        this.losePainel.SetActive(false);
        this.winPainel.SetActive(false);
        this.pausePainel.SetActive(false);
    }



    private void LigaDesligaPainel()
    {
        StartCoroutine(tempo());
    }
}
