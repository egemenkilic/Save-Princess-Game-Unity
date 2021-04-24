using UnityEngine.UI;
using UnityEngine;

public class Timer: MonoBehaviour
{
    public float time;
    public Text timeText;
    public bool timerActive;
    public Text timeTextUI;
    public Text highScore;
    public GameObject endTrigger;

    



    void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("F2");
        timeText.text = time.ToString("F1");
        timerActive = true;
        
        //PlayerPrefs.DeleteAll();
    }

    
    void Update()
    {
        if (timerActive == true)
        {
            time += Time.deltaTime;
            
            timeText.text = time.ToString("F1");
            

        }
        timeTextUI.text = time.ToString("F1");
        if (timerActive==false && endTrigger.GetComponent<EndTrigger>().winGame==0) 
        {
            if (time < PlayerPrefs.GetFloat("HighScore", float.MaxValue))
            { //Checks HighScore or compare with max value
                PlayerPrefs.SetFloat("HighScore", time);
                highScore.text = time.ToString("F2");

                if (time < PlayerPrefs.GetFloat("HighScore", float.MaxValue))
                {
                    PlayerPrefs.SetFloat("HighScore", time);
                    highScore.text = time.ToString("F2");
                    PlayerPrefs.Save();//Saves PlayerPrefs to save the HighScore that was changed
                }
            }


        }
       

    }
}
