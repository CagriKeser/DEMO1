using System;
using UnityEngine;
using DG.Tweening;
public class StandAnimations : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject _gunStand;
    [SerializeField] private GameObject _tableStand;
    [SerializeField] private GameObject _gun;
    
    [Header("Settings")]
    [SerializeField] private float _tableDuration;
    [SerializeField] private float _gunStandDuration;
    
    [Header("EndTransforms")]
    [SerializeField] private Transform _endTransform;
    [SerializeField] private Transform _endTransform2;
    
    
    private Vector3 _tableStandPos;
    private void Start()
    {
       _tableStandPos = _tableStand.transform.position;
       StartAnimation();
    }

    private void StartAnimation()
    {
        _tableStand.transform.DOMove(_endTransform.position, _tableDuration).SetEase(Ease.Linear).OnComplete(() =>
        {
            
            _gunStand.transform.DOMove(_endTransform2.position, _gunStandDuration).SetEase(Ease.Linear).OnComplete(() =>
            {
                _gunStand.transform.SetParent(_tableStand.transform);
                _tableStand.transform.DOMove(_tableStandPos, _tableDuration).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        _gun.transform.SetParent(null);
                    }
                );
            });
        });
    }
    
    
}
