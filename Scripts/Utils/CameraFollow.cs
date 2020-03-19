using UnityEngine;

namespace Utils.Camera
{
    public class CameraFollow : Singleton<CameraFollow>
    {
        public Transform target;

        [Range(0.01f, 1.0f)] public float Smoothness = 0.5f;
        public Vector3 _cameraOffset;

        public void Start()
        {
            Screen.fullScreen = false;
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }

        public void SetTarget(Transform target)
        {
            if (GetComponent<FlyCamera>())
            {
                Destroy(GetComponent<FlyCamera>());
            }

            this.target = target;
            
            // Set the camera offset to 0,0 (the statue)
            _cameraOffset = transform.position - new Vector3(0,0,0);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (target == null)
            {
                return;
            }

            Vector3 newPos = target.position + _cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, Smoothness);
        }
    }
}