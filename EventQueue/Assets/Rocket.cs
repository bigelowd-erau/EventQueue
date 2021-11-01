using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private bool m_isQuitting;

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
        Debug.Log("Recieved a launch event : rocket yeeting!");
    }
}
