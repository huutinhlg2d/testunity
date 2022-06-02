using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    //Use to switch between Force Modes
    enum ModeSwitching { Start, Stop };
    ModeSwitching m_ModeSwitching;

    //Use this to change the different kinds of force
    ForceMode2D m_ForceMode;
    //Start position of the RigidBody, use to reset
    Vector2 m_StartPosition;

    //Use to apply force to RigidBody
    Vector2 m_NewForce;

    //Use to manipulate the RigidBody of a GameObject
    Rigidbody2D m_Rigidbody;

    void Start()
    {
        //Fetch the RigidBody component attached to the GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();
        //Start at first mode (nothing happening yet)
        m_ModeSwitching = ModeSwitching.Start;

        //Initialising the force to use on the RigidBody in various ways
        m_NewForce = new Vector2(-5.0f, 1.0f);

        //This is the RigidBody's starting position
        m_StartPosition = m_Rigidbody.transform.position;
    }

    void Update()
    {
        //Switching modes depending on button presses
        switch (m_ModeSwitching)
        {
            //This is the starting mode which resets the GameObject
            case ModeSwitching.Stop:

                //Reset to starting position of RigidBody
                m_Rigidbody.transform.position = m_StartPosition;
                //Reset the velocity of the RigidBody
                m_Rigidbody.velocity = new Vector2(0f, 0f);
                break;
            case ModeSwitching.Start:
                
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    m_NewForce = new Vector2(0, 5.0f);
                    m_Rigidbody.AddForce(m_NewForce, ForceMode2D.Impulse);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    m_NewForce = new Vector2(0, -5.0f);
                    m_Rigidbody.AddForce(m_NewForce, ForceMode2D.Impulse);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    m_NewForce = new Vector2(-5.0f, 0);
                    m_Rigidbody.AddForce(m_NewForce, ForceMode2D.Impulse);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow)) 
                {
                    m_NewForce = new Vector2(5.0f, 0);
                    m_Rigidbody.AddForce(m_NewForce, ForceMode2D.Impulse);
                }
                break;
        }
    }

    //These are the Buttons for telling what Force to apply as well as resetting
    void OnGUI()
    {
        //If reset button pressed
        if (GUI.Button(new Rect(100, 0, 150, 30), "Stop"))
        {
            //Switch to start/reset case

            m_ModeSwitching = ModeSwitching.Stop;
        }

        //Impulse button pressed
        if (GUI.Button(new Rect(100, 30, 150, 30), "Start"))
        {
            //Switch to Impulse mode (apply impulse forces to GameObject)

            m_ModeSwitching = ModeSwitching.Start;
        }
    }
}
