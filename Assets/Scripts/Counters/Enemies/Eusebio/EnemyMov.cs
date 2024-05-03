using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Victoria Monzi
public class EnemyMov
{
    Rigidbody _enemy;
    Rigidbody _rbPj;
    float _velocidadEnemy;



    //Constructor de Movimiento
    public EnemyMov(Rigidbody rb, Rigidbody pj, float velocidad)
    {
        _enemy = rb;
        _rbPj = pj;
        _velocidadEnemy = velocidad;

    }
    //Movimiento
    public void EnemyMovement()
    {
        _enemy.transform.LookAt(new Vector3(_rbPj.position.x, _enemy.position.y, _rbPj.position.z));
        _enemy.transform.position = Vector3.MoveTowards(_enemy.position, new Vector3(_rbPj.position.x, _enemy.position.y, _rbPj.position.z), _velocidadEnemy * Time.deltaTime);
    }

    public void EnemyQuiet()
    {
        _velocidadEnemy = 0;
    }
}
