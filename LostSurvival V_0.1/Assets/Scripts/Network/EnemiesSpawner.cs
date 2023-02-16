using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    PhotonView pv;
    public GameObject[] Enemies;
    private void Start()
    {
        pv = GetComponent<PhotonView>();
        if(pv.IsMine)
            Spawn();
    }
    void Spawn()
    {

        foreach(GameObject spawnLocation in spawnLocations) 
        {
        
        PhotonNetwork.Instantiate(getEnemyName(),spawnLocation.transform.position,Quaternion.identity);    

        }
    }
    public string getEnemyName()
    {
        int index = Random.Range(0, Enemies.Length);
        return Enemies[index].name;
    }
}
