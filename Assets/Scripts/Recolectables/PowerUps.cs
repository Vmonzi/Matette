using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUps : MonoBehaviour, IRotateObject
{
    //Casella, Maximiliano
    //Clase padre para los Powerups que se vayan incorporando 

    [SerializeField] protected float _rotY;
    [SerializeField] protected AudioSource _audio;
    [SerializeField] protected float _recolectableValue;
    bool _picked;

    public bool IsPicked { get { return _picked; } }

    private void Update()
    {
        Rotate();
    }
    public virtual void GetPwUP(BaseCharacter character)
    {

    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0f, _rotY, 0f) * Time.deltaTime);
    }

    public void SetPicked(bool get) { _picked = get; }
}

    
