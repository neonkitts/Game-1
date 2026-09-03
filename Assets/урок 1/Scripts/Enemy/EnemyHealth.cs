using System.Collections;
using GameCore.ExperienceSystem;
using GameCore.Health;
using GameCore.UI;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyHealth : ObjectHealth
    {
        private WaitForSeconds _tick = new WaitForSeconds(1f);
        private DamageTextSpawner _damageTextSpawner;
        private ExperienceSpawner _experienceSpawner;
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            _damageTextSpawner.Activate(transform, (int)damage);
            if (CurrentHealth <= 0)
            {
                gameObject.SetActive(false);
                ChanceToDropExperience();
            }
               
        }

        public void Burn(float damage) => StartCoroutine(StartBurn(damage));

        private void ChanceToDropExperience()
        {
            if (Random.Range(0f, 100f) <= 90f) 
                _experienceSpawner.Spawn(transform.position);
        }

        private IEnumerator StartBurn(float damage)
        {
            if(gameObject.activeSelf == false)
                yield break;
            float tickDamage = damage / 3f;
            if (tickDamage < 1f)
                tickDamage = 1f;
            float roundDamage = Mathf.Round(tickDamage);
            for (int i = 0; i < 5; i++)
            {
                TakeDamage(roundDamage);
                yield return _tick;
            }
        }

        [Inject] private void Construct(DamageTextSpawner damageTextSpawner, ExperienceSpawner experienceSpawner)
        {
            _experienceSpawner = experienceSpawner;
            _damageTextSpawner = damageTextSpawner;
        }
    }
}