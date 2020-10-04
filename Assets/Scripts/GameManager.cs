using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TerrorRadiusEffect _terrorRadiusEffect;
    [SerializeField] private SimpleInputMove _cameraMover;
    // Start is called before the first frame update
    void Start()
    {
        _cameraMover.OnMove += _terrorRadiusEffect.UpdateTransitor;
    }

}
