using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystemActive : MonoBehaviour
{
    public Loja store;
    public GameObject[] objects;
    public Text alertText;

    static string alertT;
    static bool report;
    static int levelAlert;

    public static void AlertLog(string alert, int level)
    {
        alertT = alert;
        levelAlert = level;
        report = true;
    }

    private void Update() 
    {
        CheckAlert();
        CheckDesactive();
    }

    void CheckAlert()
    {
        if(report)
        {
            StartCoroutine("Alert", alertT);
        }

        if(levelAlert == 1)
        {
            alertText.color = Color.green; 
        }

        if(levelAlert == 2)
        {
            alertText.color = Color.red;        
        }
    }

    void CheckDesactive()
    {
        for(int y = 0; y < objects.Length; y++)
        {
            objects[y].SetActive(store.inActive);
        }
    }

    IEnumerator Alert(string text)
    {
        yield return new WaitForSeconds(0.1f);
        alertText.text = text;
        yield return new WaitForSeconds(5);
        alertText.text = " ";
        yield return new WaitForSeconds(1);
        alertT = " ";
        levelAlert = 0;
    }
}
