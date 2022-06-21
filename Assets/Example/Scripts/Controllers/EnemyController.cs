using System;
using Example.Scripts.Brokers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Example.Scripts.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        public float changeSpeed = 5f;

        private SpriteRenderer sprite;
        private bool _addingHealth = false;
        private bool _removeHealth = false;
        private float timer;

        private void OnEnable()
        {
            Health_Broker.onAddHealth += AddHealthFx;
            Health_Broker.onRemoveHealth += RemoveHealthFx;
        }

        private void OnDisable()
        {
            Health_Broker.onAddHealth -= AddHealthFx;
            Health_Broker.onRemoveHealth -= RemoveHealthFx;
        }

        private void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            timer += Time.deltaTime;

            if (timer < changeSpeed && _addingHealth)
            {
                sprite.color = Color.Lerp(sprite.color, Color.green, Time.deltaTime / changeSpeed);
            }
            else if (timer < changeSpeed && _removeHealth)
            {
                sprite.color = Color.Lerp(sprite.color, Color.red, Time.deltaTime / changeSpeed);
            }
            else
            {
                _addingHealth = false;
                _removeHealth = false;
                sprite.color = Color.white;
            }
        }

        private void AddHealthFx(float val)
        {
            _addingHealth = true;
            timer = 0;
            Effects_Broker.PlayRestoreEffect(transform.position);
        }

        private void RemoveHealthFx(float val)
        {
            timer = 0;
            _removeHealth = true;
            Effects_Broker.PlayHitEffect(transform.position);
        }
    }
}