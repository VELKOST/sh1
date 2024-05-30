namespace PluginInterface
{
    public interface IPlugin
    {
        void Initialize();
        void Execute();
        void Terminate();
        string Name { get; }
    }
}
