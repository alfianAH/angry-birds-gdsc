using Birds;
using UnityEngine;

namespace Gameplay{
    public class SlingShooter : MonoBehaviour
    {
        public CircleCollider2D shootAreaCollider;
        public LineRenderer trajectory;
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

        private void DisplayTrajectory(float distance)
        {
            if(bird == null) return;

            Vector2 velocity = startPos - (Vector2) transform.position;
            int segmentCount = 5;
            Vector2[] segments = new Vector2[segmentCount];
            
            // Trajectory's start position is mouse's current position
            segments[0] = transform.position;
            
            // Start velocity
            Vector2 segVelocity = distance * throwSpeed * velocity;
            for (int i = 1; i < segmentCount; i++)
            {
                float elapsedTime = i * Time.fixedDeltaTime * 5;
                segments[i] = segments[0] + segVelocity * elapsedTime +
                    0.5f * Mathf.Pow(elapsedTime, 2) * Physics2D.gravity;
            }
            
            trajectory.positionCount = segmentCount;
            for (int i = 0; i < segmentCount; i++)
            {
                trajectory.SetPosition(i, segments[i]);
            }
        }
    }
}