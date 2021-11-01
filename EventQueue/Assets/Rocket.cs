using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private bool m_isQuitting;
    private bool m_IsLaunched;

    void OnEnable()
    {
        EventBus.StartListening("Shoot", Launch);
    }

    void OnApplicationQuit()
    {
        m_isQuitting = true;
    }

    void OnDisable()
    {
        if (!m_isQuitting)
        {
            EventBus.StopListening("Shoot", Launch);
        }
    }

    void Launch()
    {
        if (!m_IsLaunched)
        {
            m_IsLaunched = true;
            Debug.Log("Recieved a launch event : rocket yeeting!");
        }
        else
        {
            if (m_IsLaunched)
               Debug.Log("Recieved a launch event : rocket already launched!");
            else //m_TargetSet == false
            { 
               Debug.Log("Recieved a launch event : rocket target not set!");
            }
        }
    }
}
