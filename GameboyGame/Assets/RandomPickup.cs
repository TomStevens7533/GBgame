using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPickup : MonoBehaviour
{

    [SerializeField] private List<GameObject> _PickupList;
    // Start is called before the first frame update
    void Awake()
    {
        int random = Random.Range(0, _PickupList.Count);
        var go = Instantiate(_PickupList[random]);
        go.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
