using System;

namespace SquareDinoTestTask.Health
{
    public interface IHealth
    {
        event Action OnHealthChanged;
        event Action OnNoHealthLeft;
        float HealthPercent { get; }
        void TakeDamage(int damage);
        void SetMaxHealth(int maxHealth);
    }
}