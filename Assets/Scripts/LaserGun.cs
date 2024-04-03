using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Weapon
{
    [SerializeField] private LineRenderer _laserBeam;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private ParticleSystem _effectAttack;
    [SerializeField] private ParticleSystem _hitEffect;

    private float _maxDistance=50f;
    private float _currentTime;
    private float _speedAttak;
    private bool _isAttack;

    private void Start()
    {
        _speedAttak = _weapon.SpeedAttack;
        _laserBeam.enabled = false;
        _effectAttack.Stop();
    }

    private void Update()
    {
        Shoot();
    }

    public override void Shoot()
    {
        if (!_laserBeam.enabled) return;

        Ray ray = new Ray(_attackPosition.position, _attackPosition.forward);
        bool cast = Physics.Raycast(ray, out RaycastHit hit, _maxDistance);
        Vector3 hitPosition = cast ? hit.point : _attackPosition.position + _attackPosition.forward * _maxDistance;
        DrawLaserBeam(_attackPosition.position, hitPosition);

        if(cast)
        {
            if(!_hitEffect.isPlaying)
                _hitEffect.Play();

            _hitEffect.transform.position = hitPosition;
        }

        if (cast && hit.collider.TryGetComponent(out Explosion explosion))
        {
            float attackPerSecomd = _weapon.Damage/100;
            explosion.TakeDamage(attackPerSecomd);
        }


    }

    public void Activate()
    {
        if (!_laserBeam.enabled)
            _laserBeam.enabled = true;

        if(!_effectAttack.isPlaying)
            _effectAttack.Play();
        
    }

    public void Deactivate()
    {
        if (_laserBeam.enabled)
            _laserBeam.enabled = false;

        if (_effectAttack.isPlaying)
            _effectAttack.Stop();

        if(_hitEffect.isPlaying)
            _hitEffect.Stop();
    }

    private void DrawLaserBeam(Vector3 startPosition, Vector3 hitPosition)
    {
        _laserBeam.SetPosition(0, startPosition);
        _laserBeam.SetPosition(1, hitPosition);
    }

}
