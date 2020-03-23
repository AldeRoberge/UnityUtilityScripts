using _03_Client.Scripts.Utils;
using UnityEngine;

namespace _01_Main.Scripts
{
    public class TimeManager : Singleton<TimeManager>
    {
        public float slowdownFactor = 0.25f;
        public float slowdownLength = 2f;

        public void SlowDown()
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

            // After you release 'Space', time will back to normal in 2 sec
        }

        void Update()
        {

            if (Time.timeScale != 1)
            {
                Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            }
            

        }
    }
}