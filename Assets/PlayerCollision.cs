using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

public GameObject gameItem;
public Text score;
public GameObject panel;
public GameObject information;
public GameObject health_bar;
public GameObject closeButton;
private int collidedTime =0;

private void Start()
{
    panel.SetActive(false);
    closeButton.SetActive(false);
    information.SetActive(false);
}


private void OnCollisionExit(Collision other)
{
    Debug.Log("WE Hit something"+ collidedTime);
    collidedTime++;
if(collidedTime>=2){
    Debug.Log("WE destorying");
    score.text = "Score: 1/1";
    score.color = new Color(0,222,255);
    health_bar.SetActive(false);
    panel.SetActive(true);
    closeButton.SetActive(true);
    information.SetActive(true);
    Destroy(gameItem);
}
    
}
private void OnCollisionEnter(Collision other)
{
    Debug.Log("WE Hit something"+ collidedTime);
    collidedTime++;
if(collidedTime>=2){
    Debug.Log("WE destorying");
    score.text = "Score: 1/1";
    score.color = new Color(0,222,255);
    health_bar.SetActive(false);
    panel.SetActive(true);
    closeButton.SetActive(true);
    information.SetActive(true);
    Destroy(gameItem);
}
}
}
