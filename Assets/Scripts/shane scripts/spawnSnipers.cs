using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSnipers : MonoBehaviour
{

    public GameObject sniperset1;
    public GameObject sniperset2;
    public GameObject sniperset3;
    public GameObject sniperset4;
    public GameObject sniperset5;

    bool set1 = false;
    bool set2 = false;
    bool set3 = false;
    bool set4 = false;
    bool set5 = false;

    int rand = Random.Range(0, 4);

    // Update is called once per frame
    void Update()
    {
        if (GG.score >= 10000 && set1 == false)
        {
            sniperset1.SetActive(true);
        }

        if (GG.score >= 20000 && set2 == false)
        {
            sniperset2.SetActive(true);
        }

        if (GG.score >= 25000 && set3 == false)
        {
            sniperset3.SetActive(true);
        }

        if (GG.score >= 30000 && set4 == false)
        {
            sniperset4.SetActive(true);
        }

        if (GG.score >= 40000 && set5 == false)
        {
            sniperset5.SetActive(true);
        }
    }


}
