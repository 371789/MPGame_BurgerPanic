using Unity.Netcode;
using UnityEngine;

public class PlayerAnimator : NetworkBehaviour
{
    [SerializeField] Player player;
    private Animator animator;
    private string IS_WALKING = "IsWalking";

    private void Awake()
    {
        animator = GetComponent<Animator>();
       
    }
    private void Update()
    {
        if (!IsOwner) return;
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
