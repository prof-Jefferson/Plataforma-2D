
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
	private Animator animator;
	private PlayerMovement playerMovement;
	private PlayerJump playerJump;

	void Start()
	{
		animator = GetComponent<Animator>();
		playerMovement = GetComponent<PlayerMovement>();
		playerJump = GetComponent<PlayerJump>();

		if (playerMovement != null)
		{
			playerMovement.OnMove += HandleMovementAnimation;
		}

		if (playerJump != null)
		{
			playerJump.OnJump += HandleJumpingAnimation;
		}

		if (playerJump != null)
		{
			playerJump.OnFalling += HandleFallingAnimation;
		}
	}

	private void HandleMovementAnimation(float move)
	{
		bool isWalking = move != 0;
		animator.SetBool("isWalking", isWalking);

		// Flip sprite based on direction
		if (isWalking)
		{
			transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
		}
	}

	private void HandleJumpingAnimation(bool isJumping)
	{
		animator.SetBool("isJumping", isJumping);
	}

	private void HandleFallingAnimation(bool isFalling)
	{
		animator.SetBool("isFalling", isFalling);
	}
}
