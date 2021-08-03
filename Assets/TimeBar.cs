using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    public Slider timeSlider;

    public Text timeText;

    public Gradient gradient;

    public Image fill;

    public GameObject panelOver;

    public float timeGame;

    private bool endTime;

    
    void Start()
    {
        endTime = false;
        timeSlider.maxValue = timeGame;
        timeSlider.value = timeGame;
        fill.color = gradient.Evaluate(1f);
    }

    
    void Update()
    {
        float time = timeGame - Time.time;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0} : {1:00}", minutes, seconds);
        if(time <= 0)
        {
            endTime = true;
            panelOver.SetActive(true);
        }
        if (endTime == false)
        {
            timeText.text = textTime;
            timeSlider.value = time;
            fill.color = gradient.Evaluate(timeSlider.normalizedValue);
        }


        
    }

}
