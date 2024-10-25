using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Noise : MonoBehaviour
{
    private Tweener _shakeTweener;
    private Vector3 _initPosition;

    public bool Ex = false;
    public bool thisEx = false;
    private void Start()
    {
        // 初期位置を保持
        _initPosition = transform.position;
    }

    private void Update()
    {
        if (Ex && !thisEx)
        {
            StartShake(1, 2, 60, 100, false);
            thisEx = true;
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
        _shakeTweener = gameObject.transform.DOShakePosition(duration, strength, vibrato, randomness, fadeOut);
    }
}
