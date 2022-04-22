using UnityEngine;

namespace Birds
{
    public class YellowBird : Bird
    {
        [SerializeField] private float boostForce = 100f;
        [SerializeField] private bool hasBoost = false;

        private void Boost()
        {
            if (State == BirdState.Thrown && !hasBoost)
            {
                BirdRigidbody.AddForce(BirdRigidbody.velocity * boostForce);
                hasBoost = true;
            }
        }

        public override void OnTap()
        {
            Debug.Log("boost");
            Boost();
        }
    }
}