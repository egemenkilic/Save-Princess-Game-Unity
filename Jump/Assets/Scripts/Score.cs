using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    

    void Update()
    {
        scoreText.text = player.GetComponent<CharacterStats>().coin.ToString();
    }
}
