using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ShootEventQueue : EventQueue
{
    private const float fireSpeed = 3.0f;
    private float timeSincePreAction;

    private (string, UnityEvent) curEvent = (null, null);

    /*public void Awake()
    {
        base.Awake();
    }*/

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        //Debug.Log("curTime" + curTime);
        if (curEvent != (null, null))
        {
            if (curTime > timeSincePreAction + fireSpeed)
            {
                curEvent.Item2.Invoke();
                timeSincePreAction = curTime;
                curEvent = (null, null);
                GetNextEvent();
            }
        }
        else
            GetNextEvent();
    }
    private void GetNextEvent()
    {
        if (m_EventQueue.Count > 0)
        {
            curEvent = m_EventQueue.Dequeue();
            //Debug.Log(5);
            //Debug.Log(curEvent);


        }
    }
}

