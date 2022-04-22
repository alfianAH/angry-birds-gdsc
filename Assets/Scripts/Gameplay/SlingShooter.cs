using Birds;
using UnityEngine;

namespace Gameplay{
    public class SlingShooter : MonoBehaviour
    {
        public CircleCollider2D shootAreaCollider;
        private Vector2 startPos;

        [SerializeField] private float radius = 0.75f;

        [SerializeField] private float throwSpeed = 30f;

        private Bird bird;
        
        private void Start()
        {
            startPos = transform.position;
        }

        private void OnMouseUp()
        {
            shootAreaCollider.enabled = false;
            var position = transform.position;
            Vector2 velocity = startPos - (Vector2) position;
            float distance = Vector2.Distance(startPos, position);

            bird.Shoot(velocity, distance, throwSpeed);
            
            // Set sling shooter to start position
            gameObject.transform.position = startPos;
        }

        private void OnMouseDrag()
        {
            // Change mouse position to world position
            Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Calculate it so that the 'rubber' of the catapult is within the specified radius
            Vector2 dir = p - startPos;
            if (dir.sqrMagnitude > radius)
                dir = dir.normalized * radius;
            transform.position = startPos + dir;
        }

        public void InitiateBird(Bird bird)
        {
            this.bird = bird;
            this.bird.MoveTo(gameObject.transform.position, gameObject);
            shootAreaCollider.enabled = true;
        }
    }
}