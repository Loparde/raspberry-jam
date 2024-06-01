using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour, IGameEventListener<float>
{
    [SerializeField] private GameEventFloat onPlayerDamaged;
    [SerializeField] private Health playerHealth;

    public void OnInvoke(float health)
    {
        Debug.Log("DamageDealer: " + health);
    }

    private void Start()
    {
        onPlayerDamaged.RegisterListener(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            playerHealth.TakeDamage(10.0f);
        }
    }

    private void OnDestroy()
    {
        onPlayerDamaged.UnregisterListener(this);
    }
}
