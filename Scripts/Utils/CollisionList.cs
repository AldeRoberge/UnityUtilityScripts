namespace Utils
{
    using UnityEngine;
    using System.Collections.Generic;

    /**
    * An utility class to find all of the current collisions on an object.
    * Uses OnCollisionEnter and OnCollisionLeave to add and remove current collisions from the list.
    *
    * Use GetNearestColliderOfType to find a currently colliding object of the given type.
    */
    public class CollisionList : MonoBehaviour
    {
        // List of the current collisions.
        private readonly List<GameObject> currentCollisions = new List<GameObject>();

        /**
        * Adds the GameObject collided with to the list.
        */
        void OnCollisionEnter(Collision col)
        {
            currentCollisions.Add(col.gameObject);
        }

        /**
        * Adds the GameObject collided with to the list.
        */
        void OnTriggerEnter(Collider col)
        {
            currentCollisions.Add(col.gameObject);
        }

        /**
        * Adds the GameObject collided with to the list.
        */
        void OnTriggerExit(Collider col)
        {
            currentCollisions.Add(col.gameObject);
        }

        /**
        * Removes the GameObject collided with from the list.
        */
        void OnCollisionExit(Collision col)
        {
            currentCollisions.Remove(col.gameObject);
        }

        /**
        * Returns the nearest object currently colliding of the given type.
        */
        public T GetNearestColliderOfType<T>() where T : MonoBehaviour
        {
            List<T> containingType = new List<T>();

            foreach (GameObject collision in currentCollisions)
            {
                if (collision.GetComponent<T>())
                    containingType.Add(collision.GetComponent<T>());
            }

            return GetNearObjects.GetNearestGameObject(gameObject.transform.position, containingType);
        }
    }
}