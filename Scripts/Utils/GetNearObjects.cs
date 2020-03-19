using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils
{
    /**
     * Utility class to help find the nearest object of a given type.
     *
     * Example use :
     *     DoorController nearestDoor = GetNearestObjectOfType<DoorController>();
     */
    public static class GetNearObjects
    {
        public static T GetNearestGameObject<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            return GetNearestGameObject<T>(gameObject.transform.position);
        }

        public static T GetNearestGameObject<T>(Vector3 position) where T : MonoBehaviour
        {
            return GetNearestGameObject(position, Object.FindObjectsOfType<T>().ToList());
        }

        public static T GetNearestGameObject<T>(Vector3 myPosition, List<T> allObjs) where T : MonoBehaviour
        {
            T nearestObject = null;
            float nearestObjectDistance = float.MaxValue;

            foreach (T objects in allObjs)
            {
                float distance = Vector3.Distance(myPosition, objects.transform.position);

                if (distance < nearestObjectDistance)
                {
                    nearestObjectDistance = distance;
                    nearestObject = objects;
                }
            }

            return nearestObject;
        }
        
        public static List<T> GetSortedListOfGameObjectByDistance<T>(Vector3 position) where T : MonoBehaviour
        {
            List<T> distance = Object.FindObjectsOfType<T>().ToList();

            distance = distance.OrderBy(
                x => Vector2.Distance(position, x.transform.position)
            ).ToList();

            return distance;
        }
    }
}