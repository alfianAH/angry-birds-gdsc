using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay{
    public class SlingShooter : MonoBehaviour
    {
        public CircleCollider2D collider;
        private Vector2 startPos;

        [SerializeField] private float radius = 0.75f;

        [SerializeField] private float throwSpeed = 30f;
        
        private void Start()
        {
            startPos = transform.position;
        }

        private void OnMouseUp()
        {
            
        }

        private void OnMouseDrag()
        {
            
        }
    }
}