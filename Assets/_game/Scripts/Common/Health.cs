using UnityEngine;
using UnityEngine.Events;
using System;

public class Health : MonoBehaviour
{

    [SerializeField] private int _currentHealth = 100;
    [SerializeField] private int _healthMax = 100;
    [SerializeField] AudioClip _hurtSound = null;
    [SerializeField] AudioClip _deathSound = null;

    public event Action<float, float> OnHealthChanged = delegate { };
    public event Action onHealthUpgraded = delegate { };

    public UnityEvent OnKilled;
    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        //AudioSource audioSource = AudioHelper.PlayClip2D(_hurtSound, 1, false);
        //audioSource.pitch = UnityEngine.Random.Range(.5f, 1);
        OnHealthChanged?.Invoke(_currentHealth, _healthMax);
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            /*if (_deathSound != null)
            {
                audioSource = AudioHelper.PlayClip2D(_deathSound, 1, false);
                audioSource.pitch = UnityEngine.Random.Range(.5f, 1);
            }*/
            Kill();
        }

    }

    public void Kill()
    {
        OnKilled?.Invoke();
        Destroy(gameObject);
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _healthMax);
        OnHealthChanged?.Invoke(_currentHealth, _healthMax);
    }

    public void IncreaseMaxHealth(int amount)
    {
        _healthMax += amount;
        _currentHealth += amount;
        OnHealthChanged?.Invoke(_currentHealth, _healthMax);
        onHealthUpgraded?.Invoke();
        //Debug.Log("Max Health: " + _healthMax);
    }

}
