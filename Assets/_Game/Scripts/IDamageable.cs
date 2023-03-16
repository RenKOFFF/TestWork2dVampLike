using System;

public interface IDamageable
{
    public event Action OnTakeDamageEvent; 
    public void TakeDamage(float damageValue);
    
}