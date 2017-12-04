using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour {

    [SerializeField]
    private Slider TimeSlider;

    [SerializeField]
    private Text TimeText;

    private GameScript Game;

	// Use this for initialization
	void Start () {
        Game = GetComponent<GameScript>();
	}
	
	// Update is called once per frame
	void Update () {
        TimeSlider.maxValue = Game.PersonDelay;
        TimeSlider.minValue = 0;
        TimeSlider.value = Game.timeRemaining;

        TimeText.text = Game.timeRemaining + "s";
	}
}
