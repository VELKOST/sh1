using PluginInterface;

namespace SamplePlugin
{
    public class SamplePlugin : IPlugin
    {
        public string Name => "Sample Plugin";

        public void Initialize()
        {
            // Инициализация плагина
        }

        public void Execute()
        {
            // Выполнение основной логики плагина
        }

        public void Terminate()
        {
            // Завершение работы плагина
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
