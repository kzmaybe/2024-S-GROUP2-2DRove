using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    SpitterBaseState currentState; //

    
    public SpitterSpawnState SpawnState = new SpitterSpawnState();
    public SpitterIdleState IdleState = new SpitterIdleState();
    public SpitterAggroState AggroState = new SpitterAggroState();
    public SpitterAttackState AttackState = new SpitterAttackState();
    public SpitterHitState HitState = new SpitterHitState();
    public SpitterDeathState DeathState = new SpitterDeathState();


    void Start()
    {
        currentState = SpawnState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    private void OnTriggerStay2D(Collider2D other){
        currentState.OnTriggerStay2D(this, other);
    }
    public void SwitchState(SpitterBaseState state){
        currentState = state;
        state.EnterState(this);
    }
}