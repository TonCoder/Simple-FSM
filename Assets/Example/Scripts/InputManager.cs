using Example.Scripts.Brokers;
using UnityEngine;

namespace Example.Scripts
{
    public class InputManager : MonoBehaviour
    {
        public Vector2 hitRange = new Vector2(0, 200);

        public void HitEnemy()
        {
            var randHit = Random.Range(hitRange[0], hitRange[1]);
            Health_Broker.RemoveHealth(-randHit);
        }

        public void RestoreEnemy()
        {
            var randHit = Random.Range(hitRange[0], hitRange[1]);
            Health_Broker.AddHealth(randHit);
        }
    }
}