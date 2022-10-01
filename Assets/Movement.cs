using System;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Movement : MonoBehaviour
{
    public float handling=10;
    public float minThrust=10;
    public float maxThrust=10;
    public float acceleration=10;

 
    private float thrust = 0;

    private void Start()
    {
        
    }
 
    private void Update()
    {
        CalculateRotation();
        CalculateThrust();
    }
 
    private void CalculateRotation()
    {
        float pitch = -Input.GetAxis("Vertical") * Time.deltaTime *  handling;
        float yaw = Input.GetAxis("Horizontal") * Time.deltaTime *  handling;
        float roll = -Input.GetAxis("Roll") * Time.deltaTime *  handling;
 
        Vector3 keyboardRot = new Vector3(pitch, yaw, roll);
 
        transform.Rotate(keyboardRot);
    }
 
    private void CalculateThrust()
    {
        thrust += Input.GetAxis("Thrust") * Time.deltaTime *  acceleration;
        thrust = Mathf.Clamp(thrust,  minThrust,  maxThrust);
  
        transform.position += transform.forward * thrust * Time.deltaTime;
    }
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Finish"){

        Debug.Log("Mission Ended or Teleport");
        SceneManager.LoadScene(1);
        }
    }
}