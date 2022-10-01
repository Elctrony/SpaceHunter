using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonController : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 6f;

    public float turnSmoothTime = 0.25f;
    float turnSmoothVelocity;

     HealthBar myHealthBar;
    [SerializeField] GameObject player;
    public float timer = 30f;

/// <summary>
/// Start is called on the frame when a script is enabled just before
/// any of the Update methods is called the first time.
/// </summary>
private void Start()
{
        
        myHealthBar = player.GetComponent<HealthBar>(); 
        myHealthBar.SetMaxHealth(timer);
}

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;
        timer -= Time.deltaTime;
        myHealthBar.SetHealth(timer);
        
    
        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity, turnSmoothTime );
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            controller.Move(direction * speed * Time.deltaTime); 
        }
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("We hit something");
        if(other.gameObject.tag=="Respawn"){
            timer=30f;
            Debug.Log("Respawn");
            Destroy(other.gameObject);
        }else if(other.gameObject.tag=="Damage"){
            timer-=10;
            Debug.Log("Damage");
            Destroy(other.gameObject);
        }
    }
}
