using System.Collections;
using UnityEngine;

public class ClickParticle : MonoBehaviour, IPoolable
{
    private ParticleSystem _clickParticle;
    private float _duration;
    private WaitForSeconds _particleDuration;

    public string _name = "ClickParticle";
    public string Name => _name;
    public GameObject PoolingObject => gameObject;

    private void Awake()
    {
        _clickParticle = GetComponent<ParticleSystem>();
        _duration = _clickParticle.main.duration;
        _particleDuration = new WaitForSeconds(_duration);
    }

    private void SetPosAndPlay(Vector3 mousePos)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = mousePos;
        StartCoroutine(ParticleCoroutine());
    }

    private IEnumerator ParticleCoroutine()
    {
        _clickParticle.Play();
        yield return _particleDuration;
        Reset();
    }


    public void Reset()
    {
        StopParticle();
    }
    private void StopParticle()
    {
        _clickParticle.Stop();
        gameObject.SetActive(false);
    }
}
