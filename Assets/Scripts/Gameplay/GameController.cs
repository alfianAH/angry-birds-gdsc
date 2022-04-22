using System.Collections.Generic;
using Birds;
using UnityEngine;

namespace Gameplay
{
    public class GameController : MonoBehaviour
    {
        public SlingShooter slingShooter;
        public List<Bird> birds;

        private void Start()
        {
            slingShooter.InitiateBird(birds[0]);
        }
    }
}