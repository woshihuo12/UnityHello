using UnityEngine;
using System.Collections;
using System;
public class TimeTicker
{
    protected float mTotalTime;
    protected float mNowTime;
    protected bool mReverse;
    protected UniTimer mTimer;
    protected float mFreq = 0.01f;
    protected bool mIsTicking = false;

    public Action<TimeTicker> OnTick;
    public Action<TimeTicker> OnEnd;

    public float TotalTime
    {
        get
        {
            return mTotalTime;
        }
        private set
        {
            mTotalTime = value;
        }
    }

    public float NowTime
    {
        get
        {
            return mNowTime;
        }
        private set
        {
            mNowTime = value;
        }
    }

    public float OverTime
    {
        get
        {
            if (IsTicking == false) return 0f;
            if (IsReverse) return NowTime;
            return TotalTime - NowTime;
        }
    }

    public bool IsTicking
    {
        get
        {
            return mIsTicking;
        }
        private set
        {
            mIsTicking = value;
        }
    }

    public bool IsReverse
    {
        get
        {
            return mReverse;
        }
        private set
        {
            mReverse = value;
        }
    }

    public TimeTicker()
    {
        mTotalTime = 0;
        mNowTime = 0;
        mIsTicking = false;
    }

    public void Start(float time)
    {
        init(time, false);
    }

    public void StartReverse(float time)
    {
        init(time, true);
    }

    public void Pause(bool pause)
    {
        if (mTimer != null) mTimer.Pause(pause);
    }

    public bool IsPause()
    {
        if (mTimer != null) return mTimer.mIsPaused;
        else return false;
    }

    private void init(float time, bool reverse)
    {
        if (IsTicking) return;
        IsTicking = true;
        TotalTime = time;
        mReverse = reverse;
        if (mReverse)
        {
            NowTime = time;
        }
        else
        {
            NowTime = 0;
        }
        if (mTimer != null)
        {
            mTimer.Stop();
            mTimer.Start(mTotalTime, mFreq, (t) =>
            {
                tick();
            },
            (t) =>
            {
                end();
            });
        }
        else
        {
            mTimer = UniTimer.Create(mTotalTime, mFreq, (t) =>
            {
                tick();
            },
            (t) =>
            {
                end();
            });
        }
    }

    public void Stop()
    {
        if (!IsTicking) return;
        mIsTicking = false;
        if (mTimer != null)
        {
            mTimer.Stop();
        }
    }

    private void tick()
    {
        if (mReverse)
        {
            mNowTime -= mFreq;
            if (mNowTime < 0) mNowTime = 0;
        }
        else
        {
            mNowTime += mFreq;
            if (mNowTime > mTotalTime) mNowTime = mTotalTime;
        }
        if (OnTick != null)
        {
            OnTick(this);
        }
    }

    private void end()
    {
        if (mReverse)
        {
            mNowTime = 0;
        }
        else
        {
            mNowTime = mTotalTime;
        }
        if (OnEnd != null)
        {
            OnEnd(this);
        }
        Stop();
    }
}
