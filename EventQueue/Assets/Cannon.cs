using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    private bool m_isQuitting;
    private bool m_isLoaded = true;

    void OnEnable()
    {
        //Invoke("Init", 2f);
        EventBus.StartListening("Fire", Shoot);
        EventBus.StartListening("Reload", Reload);
    }
    /*
    private void Init()
    {
        EventBus.StartListening("Shoot", Shoot);
    }*/

    void OnApplicationQuit()
    {
        m_isQuitting = true;
    }

    void OnDisable()
    {
        if (!m_isQuitting)
        {
            EventBus.StopListening("Fire", Shoot);
            EventBus.StopListening("Reload", Reload);
        }
    }

    void Shoot()
    {
        if (m_isLoaded)
        {
            Debug.Log("Recieved a shoot event : shooting cannon!");
            m_isLoaded = false;
            //this.Invoke("flipLoaded", 0.5f);
            EventBus.HandleNewEvent("Reload");
        }
    }

    void Reload()
    {
        if (!m_isLoaded)
        {
            Debug.Log("Recieved a reload event : cannon reloaded!");
            m_isLoaded = true;
            //this.Invoke("flipLoaded", 0.5f);
        }
    }

    void flipLoaded()
    {
        m_isLoaded = !m_isLoaded;
    }
}
