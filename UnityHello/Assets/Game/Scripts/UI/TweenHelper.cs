using UnityEngine;
using System.Collections;
using DG.Tweening;
using LuaInterface;
public class TweenHelper
{
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

    

    public static void To(Vector3 tweenValue, Vector3 endValue, float duration, int easeType, LuaTable callBacks)
    {
        var tweenCore = DOTween.To(() => tweenValue, x => tweenValue = x, endValue, duration);
        if (tweenCore == null) return;
        tweenCore.SetEase((Ease)easeType);
        if (callBacks == null) return;
        SetTweenCallBacks<Tween>(tweenCore, callBacks);
    }

    public static void MoveLocalX(Transform transform,
        float endPos, float duration, bool isSnaped,
        int easeType, LuaTable callBacks)
    {
        var tweenCore = transform.DOLocalMoveX(endPos, duration, isSnaped);
        if (tweenCore == null) return;
        tweenCore.SetEase((Ease)easeType);
        if (callBacks == null) return;
        SetTweenCallBacks<Tween>(tweenCore, callBacks);
    }
}
