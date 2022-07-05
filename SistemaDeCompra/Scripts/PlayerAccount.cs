using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAccount : MonoBehaviour
{
   public float actualMoney;
   public Text moneyText; 

   void ShowMoney()
   {
       moneyText.text = "Dinheiro: " + actualMoney;
   } 

    private void Update() 
    {
        ShowMoney();
    }

   public void Reduce(float value)
   {
       if(actualMoney >= value)
       {
           actualMoney = actualMoney - value;
       }
   }

   public void Add(float value)
   {
       actualMoney = actualMoney + value;
   }
}
