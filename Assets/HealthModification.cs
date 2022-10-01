using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModification : MonoBehaviour
{

    HealthBar myHealthBar;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        myHealthBar = player.GetComponent<HealthBar>(); 
        myHealthBar.SetMaxHealth(10);
        myHealthBar.SetHealth(2);   
        Debug.Log(myHealthBar.getHealth());

    }

    // Update is called once per frame
    void Update()
    {

    }
}
