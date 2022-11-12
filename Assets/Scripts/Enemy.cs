using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public float _health = 3;
    public float Health {
        set {
            _health = value;
            if(_health <= 0) {
                Defeated();
            }
        }
        get {
            return _health;
        }
    }
    public void Start() {
        animator = GetComponent<Animator>();
    }
    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
    public void Defeated() {
       animator.SetTrigger("Defeated");
    }
    void OnHit(float damage){
        Debug.Log("Slime hit for " + damage);
    }
}
