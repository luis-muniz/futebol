using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FasesManager : MonoBehaviour
{
    public static FasesManager instance;

    public int fase = -1;
    [SerializeField]
    private GameObject uiManagerGo, gameManagerGO;

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

        SceneManager.sceneLoaded += VerificarFase;
    }

    public void VerificarFase(Scene cena, LoadSceneMode modo)
    {
        this.fase = SceneManager.GetActiveScene().buildIndex;
        if (this.fase != 4)
        {
            Instantiate(this.uiManagerGo);
            Instantiate(this.gameManagerGO);
        }
    }
}
