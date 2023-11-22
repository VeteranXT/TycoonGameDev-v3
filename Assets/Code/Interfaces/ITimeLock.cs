

/// <summary>
/// Represent interface that is locked behind time
/// </summary>
public interface  ITimeLock
{
    public bool IsLocked { get; }
    public int UnlockYear { get; }
    public int UnlockMonth { get; }
    public bool AlreadyUnlocked { get; }
    void Unlock(int year, int month);
    void Lock();
}