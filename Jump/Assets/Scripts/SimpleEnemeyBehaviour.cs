using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemeyBehaviour : MonoBehaviour
{
    public int speed;
    public int turnDelay;
    public int health;

    //Drop denemeleri   
    public bool drops;
    public GameObject theDrops;
    public Transform dropPoint;


    bool faceRight = false;

    private void Start()
    {
        StartCoroutine(SwitchDirections());
    }



    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }


    IEnumerator SwitchDirections()
    {
        yield return new WaitForSeconds(turnDelay);
        Switch();
    }

    private void Switch()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

        speed *= -1;

        StartCoroutine(SwitchDirections());
    }



    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            if (drops) Instantiate(theDrops,dropPoint.position,dropPoint.rotation);
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<CharacterStats>().TakeDamage(1);
        }
    }


}
