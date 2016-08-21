using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LoadingPanelBehaviour : StateMachineBehaviour
{
    FirstPersonController m_FPS;

	 // Disables player control during intro animation
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_FPS = GameObject.FindObjectOfType<FirstPersonController>();
        m_FPS.enabled = false;
	}

	// Enables player control when intro animation ends
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        m_FPS.enabled = true;
	}
}
