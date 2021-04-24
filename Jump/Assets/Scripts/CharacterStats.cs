using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
	//UI
	public Image[] hearts;
	public GameObject gameOverUI;
	public GameObject timer;
	public GameObject endTrigger;
	

	//Stats
	public int health = 5;
	int maxHealth = 5;
	public AudioClip [] sounds;

	public int coin=0;

	public void GetCoin(int amount)
    {
		coin += amount;
		gameObject.GetComponent<AudioSource>().PlayOneShot(sounds[0]);
    }


	public void TakeDamage(int amount)
	{
		hearts[health - 1].enabled = false;
		health -= amount;
	}

	public void Regen(int amount)
	{
		health += amount;
		gameObject.GetComponent<AudioSource>().PlayOneShot(sounds[1]);

		for (int i = 0; i < health; i++)
		{
			hearts[i].enabled = true;
		}
	}

	private void Update()
	{
		if(health > maxHealth)
		{
			health = maxHealth;
		}

		if (health <= 0)
		{
			FindObjectOfType<GameManager>().GameOver();
			gameOverUI.SetActive(true);
			gameObject.GetComponent<AudioSource>().PlayOneShot(sounds[2]);
			timer.GetComponent<Timer>().timerActive = false;
			GetComponent<CharacterController>().enabled = false;
		}

        if (endTrigger.GetComponent<EndTrigger>().winGame == 0)
        {
			gameObject.GetComponent<AudioSource>().PlayOneShot(sounds[3]);
			GetComponent<CharacterController>().enabled = false;
		}

	}
}
