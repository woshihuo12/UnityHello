using UnityEngine;
using System.Collections;
using DG.Tweening;
using LuaInterface;
using System.Collections.Generic;
public class TweenHelper
{
    private static void SetTween<T>(T tweenCore, int easeType, LuaTable callBacks) where T : Tween
    {
        tweenCore.SetEase((Ease)easeType);
        if (callBacks == null) return;
        SetTweenCallBacks<Tween>(tweenCore, callBacks);
    }

    private static void SetTweenCallBacks<T>(T tweenCore, LuaTable callBacks) where T : Tween
    {
        if (callBacks == null) return;
        if (tweenCore == null) return;

        LuaFunction onComplete = callBacks.GetLuaFunction("OnComplete") as LuaFunction;
        if (onComplete != null)
        {
            tweenCore.OnComplete(() =>
            {
                onComplete.BeginPCall();
                onComplete.PCall();
                onComplete.EndPCall();

                onComplete.Dispose();
                onComplete = null;
            });
        }

        LuaFunction onUpdate = callBacks.GetLuaFunction("OnUpdate") as LuaFunction;
        if (onUpdate != null)
        {
            tweenCore.OnUpdate(() =>
            {
                onUpdate.BeginPCall();
                onUpdate.PCall();
                onUpdate.EndPCall();

                onUpdate.Dispose();
                onUpdate = null;
            });
        }
    }

    public static void SetTweensCapacity(int tweenersCapacity, int sequencesCapacity)
    {
        DOTween.SetTweensCapacity(tweenersCapacity, sequencesCapacity);
    }

    public static void SetDefaultAutoKill(bool isAuto)
    {
        DOTween.defaultAutoKill = isAuto;
    }

    public static bool GetDefaultAutoKill()
    {
        return DOTween.defaultAutoKill;
    }

    public static void SetUseSafeMode(bool isSafe)
    {
        DOTween.useSafeMode = isSafe;
    }

    public static bool GetUseSafeMode()
    {
        return DOTween.useSafeMode;
    }

    public static void Clear(bool destroy)
    {
        DOTween.Clear(destroy);
    }

    public static void ClearCachedTweens()
    {
        DOTween.ClearCachedTweens();
    }

    public static int Complete(System.Object targetOrId, bool withCallbacks)
    {
        return DOTween.Complete(targetOrId, withCallbacks);
    }

    public static int CompleteAll(bool withCallbacks)
    {
        return DOTween.CompleteAll(withCallbacks);
    }

    public static int Flip(System.Object targetOrId)
    {
        return DOTween.Flip(targetOrId);
    }

    public static int FlipAll()
    {
        return DOTween.FlipAll();
    }

    public static int Goto(System.Object targetOrId, float to, bool andPlay)
    {
        return DOTween.Goto(targetOrId, to, andPlay);
    }

    public static int GotoAll(float to, bool andPlay)
    {
        return DOTween.GotoAll(to, andPlay);
    }

    public static void Init(bool recycleAllByDefault, bool useSafeMode)
    {
        DOTween.Init(recycleAllByDefault, useSafeMode, LogBehaviour.ErrorsOnly);
    }

    public static int Kill(System.Object targetOrId, bool complete)
    {
        return DOTween.Kill(targetOrId, complete);
    }

    public static int KillAll(bool complete)
    {
        return DOTween.KillAll(complete);
    }

    public static int KillAll(bool complete, object[] idsOrTargetsToExclude)
    {
        return DOTween.KillAll(complete, idsOrTargetsToExclude);
    }

    public static int Pause(object targetOrId)
    {
        return DOTween.Pause(targetOrId);
    }

    public static int PauseAll()
    {
        return DOTween.PauseAll();
    }

    public static int Play(object targetOrId)
    {
        return DOTween.Play(targetOrId);
    }

    public static int Play(object target, object id)
    {
        return DOTween.Play(target, id);
    }

    public static int PlayAll()
    {
        return DOTween.PlayAll();
    }

    public static int PlayBackwards(object targetOrId)
    {
        return DOTween.PlayBackwards(targetOrId);
    }

    public static int PlayBackwardsAll()
    {
        return DOTween.PlayBackwardsAll();
    }

    public static int PlayForward(object targetOrId)
    {
        return DOTween.PlayForward(targetOrId);
    }

    public static int PlayForwardAll()
    {
        return DOTween.PlayForwardAll();
    }

    public static int Restart(object targetOrId, bool includeDelay)
    {
        return DOTween.Restart(targetOrId, includeDelay);
    }

    public static int Restart(object target, object id, bool includeDelay)
    {
        return DOTween.Restart(target, id, includeDelay);
    }

    public static int RestartAll(bool includeDelay)
    {
        return DOTween.RestartAll(includeDelay);
    }

    public static int Rewind(object targetOrId, bool includeDelay)
    {
        return DOTween.Rewind(targetOrId, includeDelay);
    }

    public static int RewindAll(bool includeDelay)
    {
        return DOTween.RewindAll(includeDelay);
    }

    public static int SmoothRewind(object targetOrId)
    {
        return DOTween.SmoothRewind(targetOrId);
    }

    public static int SmoothRewindAll()
    {
        return DOTween.SmoothRewindAll();
    }

    public static int TogglePause(object targetOrId)
    {
        return DOTween.TogglePause(targetOrId);
    }

    public static int TogglePauseAll()
    {
        return DOTween.TogglePauseAll();
    }

    public static List<Tween> TweensById(object id, bool playingOnly)
    {
        return DOTween.TweensById(id, playingOnly);
    }

    public static List<Tween> TweensByTarget(object target, bool playingOnly)
    {
        return DOTween.TweensByTarget(target, playingOnly);
    }

    public static void To(Color tweenValue, Color endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void To(double tweenValue, double endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void To(float tweenValue, float endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void To(int tweenValue, int endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void To(long tweenValue, long endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void To(Rect tweenValue, Rect endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void To(RectOffset tweenValue, RectOffset endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void To(string tweenValue, string endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void To(Vector2 tweenValue, Vector2 endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void To(Vector3 tweenValue, Vector3 endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void To(Vector4 tweenValue, Vector4 endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void ToAlpha(Color tweenValue, float endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.ToAlpha(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void Shake(Vector3 tweenValue, float duration, Vector3 strength, int vibrato, float randomness, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.Shake(() => tweenValue, x => tweenValue = x, duration, strength, vibrato, randomness);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void ShakeIgnoreZ(Vector3 tweenValue, float duration, float strength, int vibrato, float randomness,
        bool ignoreZAxis, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.Shake(() => tweenValue, x => tweenValue = x, duration, strength, vibrato, randomness, ignoreZAxis);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }

    public static void MoveLocalX(Transform transform,
        float endPos, float duration, bool isSnaped,
        int easeType, LuaTable callBacks)
    {
        var tweenCore = transform.DOLocalMoveX(endPos, duration, isSnaped);
        if (tweenCore == null) return;
        SetTween(tweenCore, easeType, callBacks);
    }
}
