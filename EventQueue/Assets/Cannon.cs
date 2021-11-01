using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    private bool m_isQuitting;
    private bool m_isLoaded = true;

    void OnEnable()
    {
        //EventBus.StartListening("Shoot", Shoot);
        //EventBus.StartListening("Fire", Reload);
    }

    void OnApplicationQuit()
    {
        m_isQuitting = true;
    }

    void OnDisable()
    {
        if (!m_isQuitting)
        {
            //EventBus.StopListening("Shoot", Shoot);
            //EventBus.StopListening("Fire", Reload);
        }
    }

    void Shoot()
    {
        if (m_isLoaded)
        {
            Debug.Log("Recieved a shoot event : shooting cannon!");
            m_isLoaded = false;
        }
    }

    void Reload()
    {
        if (!m_isLoaded)
        {
            Debug.Log("Recieved a reload event : reloading cannon!");
            m_isLoaded = true;
        }
    }
}
