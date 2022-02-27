using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;  
    public float powerUpStrength = 15.0f;
    public bool hasPowerUp = false;
    public GameObject powerUpIndicator;
    public GameObject GameObject;
  
    public FixedJoystick _joystick;
    public float _speed;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
       
    }
    
    
    void Update()
    {

        playerRb.AddForce(new Vector3(_joystick.Horizontal * _speed, playerRb.velocity.y, _joystick.Vertical * _speed ));
                
        powerUpIndicator.transform.position = transform.position + new Vector3(0,-0.4f,0);       
                
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOver");
            
            
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownroutine());
        }
    }

    IEnumerator PowerupCountdownroutine()
    {
        Score.scoreValue += 5;
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to" + hasPowerUp);
        }
        

    }          
}
