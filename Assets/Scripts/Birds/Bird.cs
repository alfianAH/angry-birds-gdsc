using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Birds
{
    public class Bird : MonoBehaviour
    {
        public  enum BirdState{ Idle, Thrown }
        private Rigidbody2D birdRigidbody;
        private CircleCollider2D birdCollider;

        private BirdState birdState;
        private float minVelocity = 0.05f;
        private bool flagDestroy = false;

        private void Start()
        {
            birdCollider = GetComponent<CircleCollider2D>();
            birdRigidbody = GetComponent<Rigidbody2D>();
            
            birdRigidbody.bodyType = RigidbodyType2D.Kinematic;
            birdCollider.enabled = false;
            birdState = BirdState.Idle;
        }

        private void FixedUpdate()
        {
            if (birdState == BirdState.Idle &&
                birdRigidbody.velocity.sqrMagnitude >= minVelocity)
            {
                birdState = BirdState.Thrown;
            }

            if (birdState == BirdState.Thrown &&
                birdRigidbody.velocity.sqrMagnitude < minVelocity &&
                !flagDestroy)
            {
                // Destroy object after 2 seconds
                // if its speed is less than minimum velocity
                flagDestroy = true;
                StartCoroutine(DestroyAfter(2));
            }
        }

        private IEnumerator DestroyAfter(float seconds)
        {
            
        }
        
        /// <summary>
        /// Initiate position and change bird's parent
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parent"></param>
        public void MoveTo(Vector2 target, GameObject parent)
        {
            
        }
        
        /// <summary>
        /// Throw bird to direction, distance and velocity
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="distance"></param>
        /// <param name="speed"></param>
        public void Shoot(Vector2 velocity, float distance, float speed)
        {
            
        }
    }
}