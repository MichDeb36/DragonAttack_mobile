using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float jumpForce;
    [SerializeField] Animator cameraAnimator;
    [SerializeField] GameObject fire;
    DragonPosition actualyPosition;
    Vector3 outerLeftPosition = new Vector3(-7f, 0.5f, 0f);
    Vector3 innerLeftPosition = new Vector3(-3.5f, 0.5f, 0f);
    Vector3 innerRightPosition = new Vector3(3.5f, 0.5f, 0f);
    Vector3 outerRightPosition = new Vector3(7f, 0.5f, 0f);
    private Animator animator;

    enum DragonPosition
    {
        outerLeftSide,
        innerLeftSide,
        innerRightSide,
        outerRightSide,
        NumberOfPosition
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        actualyPosition = DragonPosition.innerLeftSide;
        transform.position = innerLeftPosition;

    }
    void SetOuterLeftSide()
    {
        transform.position = outerLeftPosition;
        actualyPosition = DragonPosition.outerLeftSide;
    }
    void SetInnerLeftSide()
    {
        transform.position = innerLeftPosition;
        actualyPosition = DragonPosition.innerLeftSide;
    }
    void SetInnerRightSide()
    {
        transform.position = innerRightPosition;
        actualyPosition = DragonPosition.innerRightSide;
    }
    void SetOuterRightSide()
    {
        transform.position = outerRightPosition;
        actualyPosition = DragonPosition.outerRightSide;
    }
    public void MoveLeft()
    {
        if (actualyPosition == DragonPosition.outerRightSide)
            SetInnerRightSide();
        else if (actualyPosition == DragonPosition.innerRightSide)
            SetInnerLeftSide();
        else if (actualyPosition == DragonPosition.innerLeftSide)
            SetOuterLeftSide();
    }

    public void MoveRight()
    {
        if (actualyPosition == DragonPosition.outerLeftSide)
            SetInnerLeftSide();
        else if (actualyPosition == DragonPosition.innerLeftSide)
            SetInnerRightSide();
        else if (actualyPosition == DragonPosition.innerRightSide)
            SetOuterRightSide();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tank")
        {
            animator.SetTrigger("Dead");
            cameraAnimator.SetTrigger("Dead");
            fire.SetActive(false);  
            GameManager.Instance.EndGame();
        }
    }
}
