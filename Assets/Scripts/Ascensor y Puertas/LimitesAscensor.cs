using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesAscensor : MonoBehaviour
{
    //Monzi Victoria - Ivo Aguielra
    public Collider     up;
    public Collider     down;
    public Collider     buttomUp;
    public Collider     buttomDown;
    public PuertasAsc[] doors;

    private void Start()
    {
        up.enabled = !enabled;
        down.enabled = enabled;
        buttomUp.enabled = !enabled;
        buttomDown.enabled = enabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        Ascensor ascensor = other.GetComponent<Ascensor>();
        if (ascensor)
        {
            ascensor.LetsMove -= ascensor.Movement;
            ascensor.SetMove(false);
            foreach (PuertasAsc door in doors)
            {
                ascensor.LetsMove -= door.Close;
                ascensor.LetsMove += door.Open;
            }
            if(ascensor.GetPos() == Ascensor.posicion.down)
            {
                ascensor.SetPos(Ascensor.posicion.up);
            }
            else
            {
                ascensor.SetPos(Ascensor.posicion.down);
            }
            Invoke("ChangeEnabled", .5f);
        }
    }

    private void ChangeEnabled()
    {
        up.enabled = !up.enabled;
        down.enabled = !down.enabled;
        buttomUp.enabled = !buttomUp.enabled;
        buttomDown.enabled = !buttomDown.enabled;
    }
}
