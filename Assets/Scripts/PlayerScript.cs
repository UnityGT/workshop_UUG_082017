using UnityEngine;

public class PlayerScript : MonoBehaviour {

    CharacterController controller;
    Animator animator;
    public float jumpImpulse;
    public float gravity = 20.0F;
    Vector3 velocity;
    bool shouldUpdate;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.Play("Salute");
    }
	
	// Update is called once per frame
	void Update () {
        if (!shouldUpdate)
        {
            return;
        }
        if (controller.isGrounded && Input.anyKeyDown)
        {
            velocity.y = jumpImpulse;
        }
        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void Init()
    {
        animator.Play("Running@loop");
        shouldUpdate = true;
    }

    public void Stop()
    {
        shouldUpdate = false;
        animator.Play("Damaged@loop");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Fence"))
        {
            GameObject.FindObjectOfType<GameManager>().Stop();
        }
    }
}
