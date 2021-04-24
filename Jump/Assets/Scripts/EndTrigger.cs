using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject timer;
    public GameObject winUI;
    public GameObject knight;
    public int winGame=1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (knight.GetComponent<CharacterStats>().coin == 15)
        {
            timer.GetComponent<Timer>().timerActive = false;
            winGame = 0;
            winUI.SetActive(true);
            Debug.Log("won");

        }
        

    }



}
