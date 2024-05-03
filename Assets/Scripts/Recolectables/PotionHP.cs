using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHP : PowerUps
{
    //Casella, Maximiliano


    //Hereda de Powerup y se modifica para sumar vida al player al colisionar (si su variable de vida es menor a 100)
    
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
