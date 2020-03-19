using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Utils
{


// Proximity trigger class with radius
// Interactable object with trigger, static and radius 
// with PlayerController
    public class ProximityTrigger : MonoBehaviour
    {
        public UnityEvent OnProximity = new UnityEvent();
        public UnityEvent OnProximityLeave = new UnityEvent();

        public void Start()
        {
            bool hasColliderTrigger = false;

            foreach (var boxCollider in GetComponentsInChildren<BoxCollider>())
            {
                if (boxCollider.isTrigger)
                {
                    hasColliderTrigger = true;
                }
            }

            if (!hasColliderTrigger)
            {
                Debug.LogError(
                    "Watch out! A proximity trigger requires the object to have a collider of type trigger as a child.");
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Invoking enter...");
                OnProximity.Invoke();
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Invoking exit...");
                OnProximityLeave.Invoke();
            }
        }
    }
}