using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FasesManager : MonoBehaviour
{
    public int fase;
    public static FasesManager instance;

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
    }
}
