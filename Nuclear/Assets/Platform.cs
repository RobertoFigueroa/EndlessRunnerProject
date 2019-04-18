using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PatformManager _platformManager;

    private void OnEnable()
    {
        _platformManager = GameObject.FindObjectOfType<PatformManager>();   
    }
    private void OnBecameInvisible()
    {
        //recicla la plataforma
        _platformManager.RecyclerPlatform(this.gameObject);
    }
}
