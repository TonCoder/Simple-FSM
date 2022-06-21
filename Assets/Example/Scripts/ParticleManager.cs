using System;
using System.Collections;
using Example.Scripts.Brokers;
using UnityEngine;

namespace Example.Scripts
{
    public class ParticleManager : MonoBehaviour
    {
        public ParticleSystem hitParticle;
        public ParticleSystem restoreParticle;
        public float stopEffectTimer = 0.5f;

        private bool _particleEnabled = false;
        private Coroutine _routine;

        private void OnEnable()
        {
            Effects_Broker.onPlayHitFx += ParticleHit;
            Effects_Broker.onPlayRestoreFx += ParticleRestore;
        }

        private void OnDisable()
        {
            Effects_Broker.onPlayHitFx -= ParticleHit;
            Effects_Broker.onPlayRestoreFx -= ParticleRestore;
        }

        private void ParticleHit(Vector3 pos) => StartParticles(pos, true);
        private void ParticleRestore(Vector3 pos) => StartParticles(pos, false);

        private void StartParticles(Vector3 pos, bool isHit)
        {
            if (_particleEnabled) return;
            if (isHit)
            {
                hitParticle.transform.position = pos;
                hitParticle.Play();
            }
            else
            {
                restoreParticle.transform.position = pos;
                restoreParticle.Play();
            }

            if (_routine != null) StopCoroutine(_routine);
            _routine = StartCoroutine(StopEffect());
        }

        private IEnumerator StopEffect()
        {
            yield return new WaitForSeconds(stopEffectTimer);
            hitParticle.Stop(true);
            restoreParticle.Stop(true);
            _particleEnabled = false;
        }
    }
}