using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{

    public int Numberofplayers = 2;
    public GameObject win;
    public GameObject lose;


    

    public void Defeat() {
        Numberofplayers = Numberofplayers-1;

    }

    public void showWin()
    {
        win.SetActive(true);
        lose.SetActive(false);

    }

    public void showlose()
    {
        lose.SetActive(true);
        win.SetActive(false);
    }
}
