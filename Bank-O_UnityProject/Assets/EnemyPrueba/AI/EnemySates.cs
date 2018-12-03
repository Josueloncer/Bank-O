using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySates : MonoBehaviour {

    public EnemyAI State;

    [HideInInspector]
    public Animator anim;

    int walkHash = Animator.StringToHash("walk");
    int damageHash = Animator.StringToHash("damage");
    int dieHash = Animator.StringToHash("die");

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(State.secondBeen == "damage")
        {
            anim.SetTrigger(damageHash);
        }

	}

    void FixedUpdate()
    {
        if(State.actualBeen == "walk")
        {
            anim.SetTrigger(walkHash);
        }

        if(State.actualBeen == "die")
        {
            anim.SetTrigger(dieHash);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Muerte") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
