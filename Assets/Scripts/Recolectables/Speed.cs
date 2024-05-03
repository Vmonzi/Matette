using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : PowerUps
{
  
    [SerializeField] float _resetTime;
    

    public override void GetPwUP(BaseCharacter character)
    {
        character.AddSpeed(_recolectableValue, _resetTime);
        _audio.Play();
        Destroy(this.gameObject,0.2f);
        
    }
}
