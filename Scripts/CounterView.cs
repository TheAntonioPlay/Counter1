using System.Collections;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    private WaitForSeconds _waitTime = new WaitForSeconds(0.5f);
    private Counter _counter;
    private Coroutine _counterCoroutine = null;
    private bool _isCounting = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                StopCounter();
            }
            else
            {
                StartCounter();
            }
        }
    }

    private void StartCounter()
    {
        if (_counterCoroutine == null)
        {
            _isCounting = true;
            _counterCoroutine = StartCoroutine(IncreaseCounter());
        }
    }

    private void StopCounter()
    {
        if (_counterCoroutine != null)
        {
            StopCoroutine(IncreaseCounter());
            _counterCoroutine = null;
            _isCounting = false;
        }
    }

    private IEnumerator IncreaseCounter()
    {
        while (true)
        {
            yield return _waitTime;

            if (_counterText != null)
            {
                _counter.Increment();
                _counterText.text = "" + _counter.CounterValue;
            }
        }
    }
}
