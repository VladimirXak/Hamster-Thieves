using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterHoles : MonoBehaviour
{
    [SerializeField] private Transform[] transformHoles;

    private List<Vector2> listPositionHoles;

    private void Awake()
    {
        listPositionHoles = new List<Vector2>();

        foreach (var item in transformHoles)
        {
            listPositionHoles.Add(item.position);
        }

        transformHoles = null;
    }

    public Vector2 GetPositionHole()
    {
        int rndPos = Random.Range(0, listPositionHoles.Count);
        Vector2 position = listPositionHoles[rndPos];
        listPositionHoles.RemoveAt(rndPos);

        return position;
    }

    public void DropPositionHole(Vector2 positionHole)
    {
        listPositionHoles.Add(positionHole);
    }
}
