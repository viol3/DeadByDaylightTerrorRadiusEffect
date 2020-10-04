using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrorRadiusEffect : MonoBehaviour
{
    [SerializeField] private SoundTransitorBase _soundTransitor;

    [SerializeField] private Transform _owner;
    [SerializeField] private Transform _target;

    //from near to far
    [SerializeField] private float[] _distances;

    public void UpdateTransitor()
    {
        if(_target == null)
        {
            return;
        }
        for (int i = 0; i < _distances.Length; i++)
        {
            if(Vector3.Distance(_target.position, _owner.position) < _distances[i])
            {
                Debug.Log(_distances.Length - i - 1);
                _soundTransitor.SetIndex(_distances.Length - i - 1);
                return;
            }
        }
        _soundTransitor.SetIndex(_distances.Length);
    }
}
