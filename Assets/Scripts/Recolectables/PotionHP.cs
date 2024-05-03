using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHP : PowerUps
{
    
    public override void GetPwUP(BaseCharacter character)
    {
        if (character.GetCurrentLife < character.GetMaxLife && !IsPicked)
        {
            character.AddLife(_recolectableValue);
            _audio.Play();
            SetPicked(true);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
