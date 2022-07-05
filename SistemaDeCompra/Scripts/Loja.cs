using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    public string[] productAvaliabe;
    public KeyCode upList = KeyCode.Keypad8;
    public KeyCode donwList = KeyCode.Keypad2;
    public KeyCode active = KeyCode.F;
    public Text[] textProducts;
    public int actualItem;
    public Transform player;
    public bool inActive;

    ProductsInGame productsInGame;
    int maxItem;
    
    bool dot;
    private void Start()
    {
        productsInGame = GetComponent<ProductsInGame>();
    }


    void CheckInput()
    {
        if(Vector3.Distance(player.position, transform.position) <= 3)
        {
            if(Input.GetKey(active))
            {
                inActive = true;
                Debug.Log("Entrou Na Loja!");
            }
           Debug.Log("Click em F para entrar na loja!");
        }
        else
        {
            if(inActive)
            {
                inActive = false;
                Debug.Log("Saiu Da Loja!");
            }
        }
    }

    private void Update() {
        CheckInput();
        updateTexts();
        selectItem();
    }    

    public void BuyProduct()
    {
        productsInGame.Buy(productAvaliabe[actualItem]);
    }

    void updateTexts()
    {
        for(int i = 0; i < productAvaliabe.Length; i++)
        {
            if(inActive)
            {
                textProducts[i].text = productAvaliabe[i];
            }
            else
            {
                textProducts[i].text = " ";
            }

            if(i == actualItem)
            {
                textProducts[actualItem].color = Color.red;
                textProducts[actualItem].fontSize = 25;
            }
            else
            {
                textProducts[i].color = Color.white;
                textProducts[i].fontSize = 15;
            }
        }
    }

    bool wait;

    void selectItem()
    {
        maxItem = textProducts.Length - 1;

        if(Input.GetKey(upList) && !wait)
        {
            actualItem--;
            StartCoroutine("waiting");
            wait = true;
        }    
        if(Input.GetKey(donwList) && !wait)
        {
            actualItem++;
            StartCoroutine("waiting");
            wait = true;
        }       

        if(actualItem > maxItem)
        {
            actualItem = maxItem;
        }

        if(actualItem < 0)
        {
            actualItem = 0;
        }
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(1);
        wait = false;
    }
}
