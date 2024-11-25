// DuckController.cs
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]

public class Duck : MonoBehaviour
{
    public DuckType type;
    public bool isAlive = true;
    public float speed;
    public int pointsValue;
    public Vector3 direction;

    // Add these variables
[SerializeField] 
private float escapeDuration = 10f;
private float timeAlive = 0f;


    //delegate
    public delegate void DuckHandler(int points);
    public static event DuckHandler OnDuckShot;

    public static event DuckHandler OnDuckEscaped;


    public void Initialize(DuckType duckType, float baseSpeed, int points)
    {
        type = duckType;
        speed = baseSpeed * (type == DuckType.Fast ? 2f : 1f);
        pointsValue = type == DuckType.Golden ? points * 3 : points;
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(0.1f, 1f), 0).normalized;
       
    }

    void Update()
    {
        if (isAlive)
        {
            direction = Vector3.left; 

            transform.position += direction * speed * Time.deltaTime;
            timeAlive += Time.deltaTime;

            if(timeAlive < escapeDuration/2)
            {
               
                 direction = Vector3.up; 
                transform.position += direction * speed * Time.deltaTime;

                direction = Vector3.left; 
                transform.position += direction * speed * Time.deltaTime;

                
            }

            if(timeAlive >  escapeDuration)
            {
                direction = Vector3.down; 
                transform.position += direction * speed * Time.deltaTime;
            }
          
            if (timeAlive >= escapeDuration)
            {
                OnDuckEscaped?.Invoke(-pointsValue); // Lose points when duck escapes
                Destroy(gameObject);
            }

            //if the mouse is clicked down, the duck is shot
           if (Input.GetMouseButtonDown(0))
           {
            
              OnMouseDown();
          }
        }

        
    }

    private void OnMouseDown()
    {
        //if mouse position id the same than the duck position then we hit the duck

        // Step 1.4: Trigger the event when duck is clicked
        OnDuckShot?.Invoke(pointsValue);
        Destroy(gameObject);
    }
}


public enum DuckType 
{
    Normal,
    Golden,
    Fast
}

