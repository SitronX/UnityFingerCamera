using System.Collections.Generic;
using UnityEngine;

public class GridOrdering : MonoBehaviour
{
    [SerializeField] List<DragImage> _allObjects;
    [SerializeField] GameObject _leftPanel;
    [SerializeField] GameObject _rightPanel;
    void Start()
    {
        for (int i = 0; i < _allObjects.Count; i++)
            _allObjects[i].TextUI.text = (i + 1).ToString();

        for(int i=0;i<5;i++)
        {
            GameObject obj = _allObjects[(int)(Random.value * _allObjects.Count)].gameObject;
             obj.transform.parent = _leftPanel.transform;
        }
    }
}
