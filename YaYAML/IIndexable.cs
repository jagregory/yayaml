namespace YaYAML
{
    public interface IIndexable<TKey, TValue>
    {
        TValue this[TKey key] { get; }
    }
}