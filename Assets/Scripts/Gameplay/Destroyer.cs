using UnityEngine;

namespace Gameplay
{
    public class Destroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            string tag = other.tag;

            if (tag == "Bird" || tag == "Enemy" || tag == "Obstacle")
            {
                Destroy(other.gameObject);
            }
        }
    }
}