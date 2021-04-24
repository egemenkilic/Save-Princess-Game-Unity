using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            collider.transform.GetComponent<CharacterStats>().Regen(1);
            Destroy(gameObject);
        }
    }
}