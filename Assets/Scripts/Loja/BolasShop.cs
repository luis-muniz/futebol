using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolasShop : MonoBehaviour
{
    public static BolasShop instance;
    public List<BolaItem> bolasList = new List<BolaItem>();
    public List<GameObject> bolasSuporteList = new List<GameObject>();

    public GameObject opcaoBola;
    public Transform conteudo;

    void Awake()
    {
        if (instance == null)
        {
            instance = this ;
        }    
    }

    void Start()
    {
        FillList();
    }

    void FillList()
    {
        foreach (BolaItem b in bolasList)
        {
            GameObject itensBolas = Instantiate(opcaoBola) as GameObject;
            itensBolas.transform.SetParent(conteudo, false);
            BolaSuporte item = itensBolas.GetComponent<BolaSuporte>();

            item.bolaID = b.bolaID;
            item.bolaPreco.text = b.bolaPreco.ToString();
            //inserindo o ID da bola nos botoes
            item.bolaComprarBtn.GetComponent<ComprarBola>().bolaID = b.bolaID;

            bolasSuporteList.Add(itensBolas);
            if (b.bolaComprou)
            {
                item.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + b.bolaNomeSprite);
                item.bolaPreco.text = "Usando!";
                item.bolaComprarBtn.GetComponent<Button>().interactable = false;
            }
            else
            {
                item.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + b.bolaNomeSprite +"_n");
            }
        }
    }

    public void UpdateSprite(int bola_id)
    {
        for (int i = 0; i<bolasSuporteList.Count; i++)
        {
            BolaSuporte aux = bolasSuporteList[i].GetComponent<BolaSuporte>();
            if (bola_id == aux.bolaID)
            {
                for (int j = 0; j<bolasList.Count; j++)
                {
                    if (bolasList[j].bolaID == bola_id && bolasList[j].bolaComprou)
                    {
                        aux.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + bolasList[j].bolaNomeSprite);
                        aux.bolaPreco.text = "Usar";
                    }
                }
            }
        }
    }
}
