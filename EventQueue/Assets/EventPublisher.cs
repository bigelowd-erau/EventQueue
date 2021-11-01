using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher : Singleton<EventPublisher>
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
            EventBus.HandleNewEvent("Shoot");
        if (Input.GetKeyDown("f"))
            EventBus.HandleNewEvent("Fire");
    }
}
