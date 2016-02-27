using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UniTimer
{
    public float mInterval { get; private set; }
    public float mFreq { get; private set; }
    public Action<UniTimer> mCallUpdate { get; private set; }
    public Action<UniTimer> mCallBack { get; private set; }

    public float mOverTime { get; set; }
    public float mCallTime { get; set; }
    public bool mIsPaused { get; private set; }
    public bool mIsDeleted { get; private set; }
    public bool mIsInvokeNow { get; set; }

    protected UniTimer()
    {
    }

    public static UniTimer Create(float _interval, Action<UniTimer> _callBack)
    {
        UniTimer timer = new UniTimer();
        timer.Start(_interval, _callBack);
        return timer;
    }

    public static UniTimer Create(float _interval, float _freq, Action<UniTimer> _callUpdate, Action<UniTimer> _callBack)
    {
        UniTimer timer = new UniTimer();
        timer.Start(_interval, _freq, _callUpdate, _callBack);
        return timer;
    }

    public void Start(float _interval, Action<UniTimer> _callBack)
    {
        Start(_interval, 0f, null, _callBack);
    }

    public void Start(float _interval, float _freq, Action<UniTimer> _callUpdate, Action<UniTimer> _callBack)
    {
        mInterval = _interval;
        mFreq = _freq;
        mCallUpdate = _callUpdate;
        mCallBack = _callBack;
        mIsInvokeNow = false;
        mIsPaused = false;
        mIsDeleted = false;
        SimpleTimerManager timerManager = AppFacade.Instance.GetManager<SimpleTimerManager>();
        if (timerManager != null)
        {
            timerManager.AddTimer(this);
        }
    }

    public void Pause(bool pause)
    {
        mIsPaused = pause;
    }

    public void Stop()
    {
        mIsDeleted = true;
        mInterval = 0f;
        mFreq = 0f;
        mCallUpdate = null;
        mCallBack = null;
    }
}

public class SimpleTimerManager : Manager
{
    private List<UniTimer> mTimers = new List<UniTimer>();
    Queue<UniTimer> mEndTimers = new Queue<UniTimer>();
    private float mReqRate = 0.01f;

    public void AddTimer(UniTimer _timer)
    {
        _timer.mCallTime = 0f;
        _timer.mOverTime = 0f;
        if (!mTimers.Contains(_timer))
        {
            mTimers.Add(_timer);
        }
    }

    private void RemoveTimer(UniTimer _timer)
    {
        if (mTimers.Contains(_timer))
        {
            mTimers.Remove(_timer);
        }
    }

    void Start()
    {
        InvokeRepeating("UpdateTimer", mReqRate, mReqRate);
        InvokeRepeating("CallBackTimer", mReqRate, mReqRate);
    }

    void OnDestroy()
    {
        CancelInvoke("UpdateTimer");
        CancelInvoke("CallBackTimer");
    }

    void UpdateTimer()
    {
        if (mTimers.Count <= 0) return;
        for (int i = 0; i < mTimers.Count; )
        {
            UniTimer timer = mTimers[i];
            if (timer.mIsPaused || timer.mIsDeleted)
            {
                ++i;
            }
            else
            {
                if (timer.mFreq > 0)
                {
                    timer.mCallTime += mReqRate;
                }
                timer.mOverTime += mReqRate;
                if (timer.mOverTime >= timer.mInterval
                    && timer.mInterval >= 0)
                {
                    RemoveTimer(timer);
                    mEndTimers.Enqueue(timer);
                }
                else
                {
                    if (timer.mFreq > 0
                        && (timer.mIsInvokeNow || timer.mCallTime >= timer.mFreq)
                        && timer.mCallUpdate != null)
                    {
                        timer.mIsInvokeNow = false;
                        timer.mCallTime = 0f;
                        timer.mCallUpdate(timer);
                    }
                    ++i;
                }
            }
        }
        /////////////////////////清除标记为删除的事件///////////////////////////
        for (int i = mTimers.Count - 1; i >= 0; i--)
        {
            if (mTimers[i].mIsDeleted) { RemoveTimer(mTimers[i]); }
        }
    }

    void CallBackTimer()
    {
        if (mEndTimers.Count <= 0) return;
        UniTimer timer = mEndTimers.Dequeue();
        if (timer != null && timer.mCallBack != null) timer.mCallBack(timer);
    }
}
