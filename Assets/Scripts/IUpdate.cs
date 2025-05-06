public interface IUpdate
{
    void CustomUpdate();

    void StartUpdate()
    {
        CustomUpdateManager.Instance.AddToList(this);
    }

    void StopUpdate()
    {
        CustomUpdateManager.Instance.RemoveFromUpdateList(this);
    }
}
