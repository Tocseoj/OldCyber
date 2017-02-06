using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimController : StateMachineBehaviour {

	public int numberOfIdleAnims = 2;
	public float minTime = 11f;
	public float maxTime = 27f;
	float timeSinceStopped;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetInteger ("idle", 0);
		timeSinceStopped = Time.time;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (Time.time - timeSinceStopped > Random.Range(minTime, maxTime)) {
			if (numberOfIdleAnims > 0)
				animator.SetInteger ("idle", Random.Range (1, numberOfIdleAnims + 1));
			timeSinceStopped = Time.deltaTime;
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
