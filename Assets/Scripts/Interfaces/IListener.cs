public interface IListener
{
    void Start();
    void AddAllListeners();
    void RemoveAllListeners();
    void OnDestroy();
}