using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class temp : MonoBehaviour
{
    [SerializeField]public TMP_Text player_1_name;
    [SerializeField] public TMP_Text player_1_health;
    [SerializeField] public TMP_Text player_2_name;
    [SerializeField] public TMP_Text player_2_health;
    [SerializeField] public TMP_Text Result;

  /*  public  GameObject player1;
    public GameObject player2;*/
    public GameObject upperUI;
    public GameObject LowerUI;

    private void Start()
    {

        enableUpperUI();
        disableLowerUI();
    }


    public void setName_1(string txt)
    {
        player_1_name.text = txt.ToString();
    }
    public void setName_2(string txt)
    {
        player_2_name.text = txt.ToString();
    }
    public void setHealth_1(string txt)
    {
        player_1_health.text = txt.ToString();
    }
    public void setHealth_2(string txt)
    {
        player_2_health.text = txt.ToString();
    }
    public void setResult(string txt)
    {
        Result.text = txt.ToString();
    }
    public string getResult()
    {
        return Result.text;
    }
    public void enableUpperUI() { upperUI.SetActive(true); }
    public void enableLowerUI() { LowerUI.SetActive(true); }
    public void disableUpperUI() { upperUI.SetActive(false); }
    public void disableLowerUI() { LowerUI.SetActive(false); }

/*public void SetNames()
    {
        player1 = GameObject.FindGameObjectWithTag("MalePlayer");
        player2 = GameObject.FindGameObjectWithTag("FemalePlayer");

        setHealth_1);
        setHealth_2(player2.GetComponent<PhotonView>().Owner.NickName);
    }*/
}
