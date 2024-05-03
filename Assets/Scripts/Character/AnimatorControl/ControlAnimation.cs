using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlAnimation
{
    Animator    _myAnimator;
    Entity      _myEntity;

    public ControlAnimation(Animator myAnim, Entity myEntity)
    {
        _myAnimator = myAnim;
        _myEntity   = myEntity;
        _myAnimator.SetBool("Death", false);
    }

    public void ArtificialUpdate()
    {
        switch (_myEntity.GetState())
        {
            case Entity.state.Death:
                _myAnimator.SetBool("Death", true);
                break;

            case Entity.state.Hurt:
                _myAnimator.SetBool("Hurt"      , true);
                _myAnimator.SetBool("Grubbing"  , false);
                break;

            case Entity.state.Sneak:
                _myAnimator.SetBool("Crouch"    , false);
                _myAnimator.SetBool("OnFloor"   , true);
                _myAnimator.SetBool("Grubbing"  , false);
                _myAnimator.SetBool("Walking"   , true);
                _myAnimator.SetBool("Running"   , false);
                _myAnimator.SetBool("Sneaking"  , true);
                break;

            case Entity.state.Craw:
                _myAnimator.SetBool("Crouch"    , true);
                _myAnimator.SetBool("OnFloor"   , true);
                _myAnimator.SetBool("Grubbing"  , false);
                _myAnimator.SetBool("Running"   , false);
                _myAnimator.SetBool("Sneaking"  , false);
                break;

            case Entity.state.Grubbing:
                _myAnimator.SetBool("Grubbing"  , true);
                _myAnimator.SetBool("OnFloor"   , true);
                _myAnimator.SetBool("Crouch"    , false);
                _myAnimator.SetBool("Walking"   , true);
                _myAnimator.SetBool("Running"   , false);
                _myAnimator.SetBool("Sneaking"  , false);
                break;

            case Entity.state.Running:
                _myAnimator.SetBool("Running"   , true);
                _myAnimator.SetBool("Walking"   , false);
                _myAnimator.SetBool("Grubbing"  , false);
                _myAnimator.SetBool("Crouch"    , false);
                _myAnimator.SetBool("OnFloor"   , true);
                _myAnimator.SetBool("Sneaking"  , false);
                break;

            case Entity.state.Walking:
                _myAnimator.SetBool("Walking"   , true);
                _myAnimator.SetBool("Running"   , false);
                _myAnimator.SetBool("Grubbing"  , false);
                _myAnimator.SetBool("Crouch"    , false);
                _myAnimator.SetBool("OnFloor"   , true);
                _myAnimator.SetBool("Sneaking"  , false);
                break;

            case Entity.state.IDLE:
                _myAnimator.SetBool("Walking"   , false);
                _myAnimator.SetBool("Running"   , false);
                _myAnimator.SetBool("Grubbing"  , false);
                _myAnimator.SetBool("Crouch"    , false);
                _myAnimator.SetBool("OnFloor"   , true);
                _myAnimator.SetBool("Sneaking"  , false);
                break;

            default:
                break;
        }
    }
}
