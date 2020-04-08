using UnityEngine;

namespace Sprites
{
    public class OnePlayerTest : MonoBehaviour
    {
        public static bool IsInDebugMode;

        [SerializeField] private bool inDebugMode;
        private void Awake()
        {
            IsInDebugMode = inDebugMode;
        }
    }
}
