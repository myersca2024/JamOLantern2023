using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkAnimationController : MonoBehaviour
{
    private Animator npcWalkAnimator;

    private void Awake()
    {
        npcWalkAnimator = GetComponent<Animator>();
    }

    public void SetSadWalk(bool sadWalk)
    {
        npcWalkAnimator.SetBool("SadWalk", sadWalk);
    }

    public void SetTrickOrTreat(bool trickOrTreat)
    {
        npcWalkAnimator.SetBool("TrickOrTreat", trickOrTreat);
    }
}
