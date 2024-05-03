using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    void AddLife(float lifeToAdd);
    void ReceiveDamage(float damage);
    void AddSpeed(float speedToAdd, float timeToResetSpeed);
}
