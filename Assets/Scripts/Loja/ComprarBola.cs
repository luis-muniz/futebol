using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprarBola : MonoBehaviour
{
   public int bolaID;

   public void Comprar()
   {
        for (int i = 0; i < BolasShop.instance.bolasList.Count; i++)
        {
            if (BolasShop.instance.bolasList[i].bolaID == bolaID && !BolasShop.instance.bolasList[i].bolaComprou)
            {
                BolasShop.instance.bolasList[i].bolaComprou = true;                
            }
        }
        BolasShop.instance.UpdateSprite(bolaID);
    }
    
}
