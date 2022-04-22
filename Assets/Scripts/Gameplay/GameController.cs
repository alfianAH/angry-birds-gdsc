using System.Collections.Generic;
using Birds;
using Enemies;
using UnityEngine;

namespace Gameplay
{
    public class GameController : MonoBehaviour
    {
        public SlingShooter slingShooter;
        public List<Bird> birds;
        public List<Enemy> enemies;

        private bool isGameEnded;

        private void Start()
        {
            foreach (var bird in birds)
            {
                bird.onBirdDestroyed += ChangeBird;
            }

            

            slingShooter.InitiateBird(birds[0]);
        }

        private void ChangeBird()
        {
            
            birds.RemoveAt(0);
            if (birds.Count > 0)
            {
                slingShooter.InitiateBird(birds[0]);
            }
        }

        private void CheckGameEnd(GameObject destroyedEnemy)
        {
            
        }
    }
}