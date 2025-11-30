using EventBusCore.Services;
using UnityEngine;

namespace EventBusCore.Samples
{
    public class EventRegisterAndCallSample : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            EventBusProvider.Bus = new EventBus();

            EventBusProvider.Bus.Subscribe<EventSample>(TesteRecived);
            EventBusProvider.Bus.Subscribe<EventSample2>((message) =>
            {
                Debug.Log("Event Sample 2 Received: " + message.Sample2);
            });

        }

        void OnDestroy()
        {
            EventBusProvider.Bus.Unsubscribe<EventSample>(TesteRecived);

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                EventBusProvider.Bus.Publish(new EventSample("Hello Event Bus!"));
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                EventBusProvider.Bus.Publish(new EventSample2("Hello Event Bus Sample 2!"));
            }

        }

        public void TesteRecived(EventSample message)
        {
            Debug.Log("Event Received: " + message.Sample);
        }

    }
}