using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  [Header("General Player Ship Settings")]
  [Tooltip("Horizontal speed")][SerializeField] float xSpeed = 10f; 
  [Tooltip("Horizontal screen range")][SerializeField] float xRange = 7f;
  [Tooltip("Vertical speed")][SerializeField] float ySpeed = 5.5f; 
  [Tooltip("Vertical screen range")][SerializeField] float yRange = 4.5f;

  //For rotation
  [Header("Tuning based on player input")]
  [SerializeField] float pitchFactor = -15f; 
  [SerializeField] float rollFactor = -20f;

  [Header("Tuning based on screen position")]
  [SerializeField] float yawFactor = 2.5f; 
  [SerializeField] float controlPitch = -2f;

  //Array of lasers
  [Header("Laser gun array")]
  //Text will be shown on hover
  [Tooltip("Add all laser guns here")][SerializeField] GameObject[] lasers;
  float clampX, clampY, xRoll, yRoll;
   
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessShooting();
    
    }

    void OnCollisionEnter(Collision other) {
        ReloadLevel();
    }
    void ReloadLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
    // Left, right, up, down movement
     void ProcessTranslation()
    {
         xRoll = Input.GetAxis("Horizontal");
         yRoll = Input.GetAxis("Vertical");
        //left to right
        float XPos = xRoll * Time.deltaTime * xSpeed;
        float newXPos = transform.localPosition.x + XPos;
        clampX = Mathf.Clamp(newXPos, -xRange, xRange);

        //up and down
        float YPos = yRoll * Time.deltaTime * ySpeed;
        float newYPos = transform.localPosition.y + YPos;
        //Clamp movement
        clampY = Mathf.Clamp(newYPos, -yRange, yRange);
        
        //update the position as necessary
        transform.localPosition = new Vector3(
            clampX, clampY, 
            transform.localPosition.z);
    
    }

    //Rotation of the ship
    void ProcessRotation() {
        {
            //pitch coupled with xroll and position on screen
            float posPitch = transform.localPosition.y * controlPitch;
            float inputXPitch = yRoll * pitchFactor;
            float pitch = posPitch + inputXPitch;

            //yaw coupled with position on screen
            float yaw = transform.localPosition.x * yawFactor;

            //Coupled with xroll 
            float roll = xRoll * rollFactor;
            transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        }
    }
    //Firing 
    void ProcessShooting()
    {

        //Default left Ctrl or mouse key
            
        if(Input.GetButton("Fire1")) {

        ActivateLasers(true);
        }
        else {

        ActivateLasers(false);
        }
    }

    void ActivateLasers(bool input)
    {
        foreach(GameObject laser in lasers)
        {
            var thing = laser.GetComponent<ParticleSystem>().emission;
            
                thing.enabled  = input;
         
        }
    }
}
