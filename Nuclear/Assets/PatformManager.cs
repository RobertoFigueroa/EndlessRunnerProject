using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _platformPrefabs;
    [SerializeField]
    private int _zedOffset;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _platformPrefabs.Length; i++) 
        {
            Instantiate(_platformPrefabs[i], new Vector3(0,0,i*50), Quaternion.Euler(-90,0,0));
            _zedOffset += 50;
        }
    }

    public void RecyclerPlatform(GameObject platform)
    {
        //reposiciona la siguiente plataforma
        platform.transform.position = new Vector3(0, 0, _zedOffset);
        _zedOffset += 50;
    }
}
