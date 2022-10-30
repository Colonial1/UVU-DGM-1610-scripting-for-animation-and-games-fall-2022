using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDropdown : MonoBehaviour
{
    private PlatformEffector2D effector2D;
    public float waitTime;
    
    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.DownArrow))
      {
            waitTime = 0.5f;
      }
       
        if(Input.GetKey(KeyCode.DownArrow))
        {
          if(waitTime <=0)
          {
            effector2D.rotationalOffset = 100f;
            waitTime = 0.5f;
          }
          else
          {
            waitTime -= Time.deltaTime;
          }
        }

        if(Input.GetKey(KeyCode.W))
        {
          effector2D.rotationalOffset = 0;  
        }
    }
}
