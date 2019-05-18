﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public string levelText;
        public bool habilitado;
        public int desbloqueado;
        public bool txtDesbloqueado;
    }

    public GameObject botao;
    public Transform localBotao;
    public List<Level> levelList;

    private void Awake()
    {
        Destroy(GameObject.Find("UIManager"));
        Destroy(GameObject.Find("GameManager"));
    }

    void Start()
    {
        ListaLevelAdd();
    }

    void Update()
    {
        
    }

    public void ListaLevelAdd()
    {
        foreach(Level level in levelList)
        {
            GameObject botaoNovo = Instantiate(botao) as GameObject;
            BotaoLevel botaoLevelNovo = botaoNovo.GetComponent<BotaoLevel>();

            botaoLevelNovo.numeroDaFase.text = level.levelText;
            //botaoLevelNovo.desbloquado = level.desbloqueado;
            //botaoLevelNovo.GetComponent<Button>().interactable = level.habilitado;

            if(PlayerPrefs.GetInt("Fase" + botaoLevelNovo.numeroDaFase.text) == 1)
            {
                level.desbloqueado = 1;
                level.habilitado = true;
                level.txtDesbloqueado = true;
            }

            botaoLevelNovo.desbloquado = level.desbloqueado;
            botaoLevelNovo.GetComponent<Button>().interactable = level.habilitado;
            botaoLevelNovo.GetComponentInChildren<Text>().enabled = level.txtDesbloqueado;

            botaoLevelNovo.GetComponent<Button>().onClick.AddListener(()=>EscolherFase("Fase" + botaoLevelNovo.numeroDaFase.text));

            botaoNovo.transform.SetParent(localBotao, false);
        }
    }

    public void EscolherFase(string fase)
    {
        SceneManager.LoadScene(fase);
    }
}
