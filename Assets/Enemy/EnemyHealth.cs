using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] 
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitpoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;
    Enemy enemy;
    // Start is called before the first frame update
    private void Start() 
    {
        enemy = GetComponent<Enemy>();    
    }
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other) 
    {
        ProcessHit();    
    }

    void ProcessHit()
    {
        currentHitPoints--;
        if(currentHitPoints <= 0)
        {
            maxHitPoints += difficultyRamp;
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
