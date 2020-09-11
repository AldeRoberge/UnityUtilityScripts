using System;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class allows for events to be called on the main thread.
 */
namespace Loader
{
    public class Dispatcher : MonoBehaviour
    {
        private readonly List<Action> pending = new List<Action>();

        public static Dispatcher Instance { get; private set; }

        public void Invoke(Action fn)
        {
            lock (pending)
            {
                pending.Add(fn);
            }
        }

        private void InvokePending()
        {
            lock (pending)
            {
                foreach (Action action in pending)
                {
                    try
                    {
                        action();
                    }
                    catch (Exception e)
                    {
                        // If there is no Catch, the pending list never clears.
                        Debug.LogError("Error happened during invoking action with Dispatcher. This is the error : ");
                        Debug.LogError(e);
                    }
                }

                pending.Clear();
            }
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        private void Update()
        {
            InvokePending();
        }
    }
}
