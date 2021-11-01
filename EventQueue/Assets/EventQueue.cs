using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public abstract class EventQueue : Singleton<EventQueue>
{
    //private Dictionary<string, Queue<UnityEvent>> m_EventQueue;
    protected float curTime = 0.0f;
    //Item1 is previous fire time, item
    /*private float missleLastFireTime;
    private const float missleDelay = 1.5f;
    private float cannonLastFireTime;
    private const float cannonFireReloadDelay = 2.0f;*/

    //test code
    protected Queue<(string, UnityEvent)> m_EventQueue;



    public override void Awake()
    {
        base.Awake();
        Instance.Init();
    }
    private void Init()
    {
        if (Instance.m_EventQueue == null)
        {
            //Instance.m_EventQueue = new Dictionary<string, Queue<UnityEvent>>();
            Instance.m_EventQueue = new Queue<(string, UnityEvent)>();
        }
    }
    public static void HandleEvent(string eventName, UnityEvent newEvent)
    {
        //Debug.Log(2);
        //Instance.m_EventQueue.Enqueue((eventName, newEvent));
        if (eventName == "Fire" || eventName == "Reload")
        {
        //Debug.Log(3);
            FireReloadEventQueue.EnqueueEvent(eventName, newEvent);
        }
    }

    protected static void EnqueueEvent(string eventName, UnityEvent newEvent)
    {
       // Debug.Log(4);

        Instance.m_EventQueue.Enqueue((eventName, newEvent));
    }

    public virtual void FixedUpdate()
    {
        curTime += Time.deltaTime;
    }

        /*
        public static void EnqueueEvent(string eventName, UnityEvent newEvent)
        {
            Queue<UnityEvent> thisEventQueue;
            if (Instance.m_EventQueue.TryGetValue(eventName, out thisEventQueue))
            {
                //Debug.Log(1);
                thisEventQueue.Enqueue(newEvent);
            }
            else
            {
                //Debug.Log(2);
                thisEventQueue = new Queue<UnityEvent>();
                thisEventQueue.Enqueue(newEvent);
                Instance.m_EventQueue.Add(eventName, thisEventQueue);
            }
        }

        public void FixedUpdate()
        {
            curTime += Time.deltaTime;
            ShootMissle();
            FireCannon();
        }

        private void ShootMissle()
        {
            if (missleLastFireTime + missleDelay < curTime)
            {
                Queue<UnityEvent> thisEventQueue;
                if (Instance.m_EventQueue.TryGetValue("Shoot", out thisEventQueue))
                {
                //Debug.Log(3);
                    if (thisEventQueue.Count > 0)
                    {
                //Debug.Log(4);
                        thisEventQueue.Dequeue()?.Invoke();
                        missleLastFireTime = curTime;
                    }
                }
            }
        }

        private void FireCannon()
        {
            if (cannonLastFireTime + cannonFireReloadDelay < curTime)
            {
                Queue<UnityEvent> thisEventQueue;
                if (Instance.m_EventQueue.TryGetValue("Fire", out thisEventQueue))
                {
                    if (thisEventQueue.Count > 0)
                    {
                        thisEventQueue.Dequeue().Invoke();
                        cannonLastFireTime = curTime;
                    }
                }
            }
        }*/
    }