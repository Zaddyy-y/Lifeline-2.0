using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player player;

    private Animator animator;

    private void Awake()
    {
        animator= GetComponent<Animator>();

        
    }

    private void Update()
    {
        // Animator parameter set to true if IsRunning method returns true/ if pplayer is moving 
        animator.SetBool("IsRunning", player.IsRunning());
    }
}
