using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_NoiseEnemy : MonoBehaviour
{
    private Tweener _shakeTweener;
    private Vector3 _initPosition;

    public bool Ex = false;

    private void Start()
    {
        // 初期位置を保持
        _initPosition = transform.position;
    }

    private void Update()
    {
        if (Ex) 
        {
            Ex = false;
            StartShake(0.2f, 0.5f, 100, 180, false);
        }


    }

    /// <summary>
    /// 揺れ開始
    /// </summary>
    /// <param name="duration">時間</param>
    /// <param name="strength">揺れの強さ</param>
    /// <param name="vibrato">どのくらい振動するか</param>
    /// <param name="randomness">ランダム度合(0〜180)</param>
    /// <param name="fadeOut">フェードアウトするか</param>
    public void StartShake(float duration, float strength, int vibrato, float randomness, bool fadeOut)
    {
        // 前回の処理が残っていれば停止して初期位置に戻す
        if (_shakeTweener != null)
        {
            _shakeTweener.Kill();
            gameObject.transform.position = _initPosition;
        }
        // 揺れ開始
        _shakeTweener = gameObject.transform.DOShakePosition(duration, strength, vibrato, randomness, fadeOut).SetLink(gameObject); ;
    }
}
