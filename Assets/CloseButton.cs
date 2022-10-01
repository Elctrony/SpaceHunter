using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{

    public GameObject panel;
    public GameObject information;
    public GameObject health_bar;
    public GameObject closeButton;
    public Button yourButton;

	void Start () {
		yourButton.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
        information.SetActive(false);
        panel.SetActive(false);
        health_bar.SetActive(true);
        closeButton.SetActive(false);

	}
}
