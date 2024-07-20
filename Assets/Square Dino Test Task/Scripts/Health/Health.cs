using System;
using UnityEngine;

namespace SquareDinoTestTask.Health
{
    public class Health : MonoBehaviour, IHealth
    {
        public event Action OnHealthChanged;
        public event Action OnNoHealthLeft;

        public float HealthPercent => (float)currentHealth / maxHealth;
        
        private int maxHealth;
        private int currentHealth;

        public void SetMaxHealth(int maxHealth)
        {
            this.maxHealth = maxHealth;
            currentHealth = this.maxHealth;
        }

        public void TakeDamage(int damage)
        {
            int suggestedHealth = Mathf.Max(0, currentHealth - damage);

            if (currentHealth == suggestedHealth)
            {
                return;
            }

            currentHealth = suggestedHealth;
            OnHealthChanged?.Invoke();

            if (currentHealth > 0)
            {
                return;
            }
            
            OnNoHealthLeft?.Invoke();
        }
    }
}