using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            collider.transform.GetComponent<CharacterStats>().GetCoin(1);
            Destroy(gameObject);
        }
    }
}
