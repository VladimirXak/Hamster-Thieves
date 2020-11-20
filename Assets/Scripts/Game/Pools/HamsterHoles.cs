using System.Collections.Generic;
using UnityEngine;

public class HamsterHoles : MonoBehaviour
{
    [SerializeField] private Transform[] _transformHoles;

    private List<Vector2> _listPositionHoles;

    private void Awake()
    {
        _listPositionHoles = new List<Vector2>();

        foreach (var item in _transformHoles)
        {
            _listPositionHoles.Add(item.position);
        }

        _transformHoles = null;
    }

    public Vector2 GetPositionHole()
    {
        int rndPos = Random.Range(0, _listPositionHoles.Count);
        Vector2 position = _listPositionHoles[rndPos];
        _listPositionHoles.RemoveAt(rndPos);

        return position;
    }

    public void DropPositionHole(Vector2 positionHole)
    {
        _listPositionHoles.Add(positionHole);
    }
}
