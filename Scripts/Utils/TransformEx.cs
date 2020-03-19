using Photon.Pun;
using UnityEngine;

namespace Utils
{



    public static class GameObjectExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() ? gameObject.GetComponent<T>() : gameObject.AddComponent<T>();
        }
    }



    public class Vector3Utils
    {

        public static Vector3 RandomPointOnCircleEdge(float radius)
        {
            var vector2 = Random.insideUnitCircle.normalized * radius;
            return new Vector3(vector2.x, 0, vector2.y);
        }

    }


    public static class TransformEx {

        
        /**
         * Destroys self and all of its children.
         */
        public static void DestroySelfAndAllChildrens(this GameObject gameObject)
        {
            Transform transform = gameObject.transform;

            foreach (Transform child in transform) {
                Object.Destroy(child.gameObject);
            }
            
            Object.Destroy(gameObject);
            
        }
        
        
        /**
         * Photon PUN - Destroys self and all of its children.
         */
        public static void PUNDestroySelfAndAllChildrens(this GameObject gameObject)
        {
            Transform transform = gameObject.transform;

            foreach (Transform child in transform) {
                PhotonNetwork.Destroy(child.gameObject);
            }
            
            PhotonNetwork.Destroy(gameObject);
            
        }
        
        
    }
}