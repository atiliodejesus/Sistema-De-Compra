using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsInGame : MonoBehaviour
{
   public PlayerAccount player;
   public GameObject[] objectsOfProducts;
   public float[] costOfProducts;
   public string[] nameOfProducts;
   public bool[] comprados;

   int indexForBuy;

   bool isBuy;

    public void Buy(string name)
    {
        for(int t = 0; t < nameOfProducts.Length; t++)
        {
            if(nameOfProducts[t] == name)
            {
                indexForBuy = t;
                StartCoroutine("buy");
            }
        }
    }
    bool dot;
    IEnumerator buy()
    {
        yield return new WaitForSeconds(0);
        if(!isBuy && !comprados[indexForBuy] && player.actualMoney >= costOfProducts[indexForBuy])
        {
            comprados[indexForBuy] = true;
            player.Reduce(costOfProducts[indexForBuy]);
            objectsOfProducts[indexForBuy].SetActive(true);
            Debug.Log("Compra Realizada!");
            if(!dot)
            {
                UISystemActive.AlertLog("Compra Realizada! menos " + costOfProducts[indexForBuy] + "MZM", 1);
                dot = true;
            }
            isBuy = true;
        }
        else
        {
            if(comprados[indexForBuy])
            {
                Debug.Log("O item ja foi adiquirido pelo player!");
                if(!dot)
                {
                    UISystemActive.AlertLog("O item ja foi comprado", 2);
                }
            }
            if(player.actualMoney < costOfProducts[indexForBuy])
            {
                if(!dot)
                {
                     UISystemActive.AlertLog("O Saldo da sua conta é insuficiente, é para compra " + ((player.actualMoney - costOfProducts[indexForBuy]) * -1) + "MZM", 2);
                }
            }
        }
        yield return new WaitForSeconds(5);
        isBuy = false;
        dot = false;
    }

}
