using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    private GameObject currentGun;
    public float timeRemaining = 0.2f;
    public bool timerIsRunning = false;


    void Start()
    {
        currentGun = gameObject;
        timerIsRunning = true;
    }

    private void AimAtCursor()
    {
        Vector2 aimFrom = currentGun.transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float y1 = aimFrom.y;
        float y2 = mousePos.y;
        float x1 = aimFrom.x;
        float x2 = mousePos.x;

        float angle = Mathf.Atan2(y2 - y1, x2 - x1) * 180 / Mathf.PI;

        currentGun.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    void Update()
    {
        /*
        AimAtCursor();
        */

        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                    timeRemaining -= Time.deltaTime;
            }
            else
            {
               if (Input.GetKey(KeyCode.Space))
                {
                    Instantiate(Prefab, transform.position, transform.rotation, transform.parent);
                    timeRemaining = 0.2f;
                }
            }
        }

        
    }
}
