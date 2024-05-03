using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Maximiliano Casella 
//Victoria Monzi
public class VisionRange
{
    float _range;
    LayerMask _pj;
    public bool _alerta;
    Transform _transform;

    public VisionRange(Transform t, float range, bool alerta, LayerMask player)
    {
        _range = range;
        _pj = player;
        this._alerta = alerta;
        _transform = t;
    }

    //Seteo del area de vision del enemigo en la escena
    public void VisionRangeUpdate()
    {
        _alerta = Physics.CheckSphere(_transform.transform.position, _range, _pj);
       
    }



   
}
