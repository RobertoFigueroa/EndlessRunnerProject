using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatformManager : MonoBehaviour
{
  
    public GameObject[] _platformPrefabs;
    public GameObject[] _obstacles;
    [SerializeField]
    private int _zedOffset;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _platformPrefabs.Length; i++) 
        {
            Instantiate(_platformPrefabs[i], new Vector3(0,0,i*150), Quaternion.Euler(-90,0,0));    
            _zedOffset += 150;
        }
        
    }

    public void RecyclerPlatform(GameObject platform)
    {
        //reposiciona la siguiente plataforma
        platform.transform.position = new Vector3(0, 0, _zedOffset);
        _zedOffset += 150;
        GameController.points += 5;

    }

    public int getOffset()
    {
        return _zedOffset;
    }
}
