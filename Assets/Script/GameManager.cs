using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]public int Coin;
   [HideInInspector] public bool playerIsMoving;
 
    // Update is called once per frame
    public void CoinCount()
    {
        Coin++;
        Debug.Log(Coin);
    }
  
    

}
