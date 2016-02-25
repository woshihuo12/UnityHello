using System;

public class Foo : IDisposable
{
    private bool mDisposed;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if(!mDisposed)
        {
            if (disposing)
            {
                // 释放托管资源
            }
            // 释放非托管资源

            mDisposed = true;
        }
    }

    ~Foo()
    {
        Dispose(false);
    }
}
