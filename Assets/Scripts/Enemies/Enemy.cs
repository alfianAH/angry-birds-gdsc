using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public float health = 50f;
        public UnityAction<GameObject> onEnemyDestroyed = delegate { };

        // private bool isHit;

        private void OnDestroy()
        {
            onEnemyDestroyed(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Rigidbody2D>() == null) return;

            if (other.gameObject.CompareTag("Bird"))
            {
                // isHit = true;
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Obstacle"))
            {
                float damage = other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
                // Debug.Log("Damage: " + damage);
                health -= damage;
                // Debug.Log("Health: " + health);
                if (health <= 0)
                {
                    // isHit = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
