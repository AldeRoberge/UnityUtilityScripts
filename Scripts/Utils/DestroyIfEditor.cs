using UnityEngine;

namespace Utils
{
    public class DestroyIfEditor : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (Application.isEditor)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
