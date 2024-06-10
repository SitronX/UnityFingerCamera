using System.Linq;
using UnityEngine;

public class PlaceablePosition : MonoBehaviour
{
    public Transform Figure { get; set; }

    [SerializeField] MeshRenderer _meshRenderer;

    Color _transparentColor = new Color(0, 0, 0, 0);

    private void Start()
    {
        Collider[] figures= Physics.OverlapBox(transform.position,new Vector3(0.1f,0.1f,0.1f),Quaternion.identity,1<<8);
        if (figures.Length > 0)
            Figure = figures.First().transform;
    }
    public void ClearHighlight()
    {
        if (_meshRenderer.material.color !=_transparentColor)
            _meshRenderer.material.color = _transparentColor;
    }
    public void SetHighlightColor(Color col)
    {
        _meshRenderer.material.color=col;   
    }
    public void PlaceFigureIntoPosition(Transform figure)
    {
        Figure.transform.position = transform.position;
    }

}
