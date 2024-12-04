using System;

namespace AbstractFactoryExample
{
    // 1. Інтерфейси продуктів
    public interface IButton
    {
        void Render();
    }

    public interface ICheckbox
    {
        void Render();
    }

    // 2. Інтерфейс фабрики
    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    // 3. Реалізація продуктів для Windows
    public class WindowsButton : IButton
    {
        public void Render() => Console.WriteLine("Rendering Windows Button");
    }

    public class WindowsCheckbox : ICheckbox
    {
        public void Render() => Console.WriteLine("Rendering Windows Checkbox");
    }

    // 4. Реалізація продуктів для MacOS
    public class MacOSButton : IButton
    {
        public void Render() => Console.WriteLine("Rendering MacOS Button");
    }

    public class MacOSCheckbox : ICheckbox
    {
        public void Render() => Console.WriteLine("Rendering MacOS Checkbox");
    }

    // 5. Реалізація фабрик
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ICheckbox CreateCheckbox() => new WindowsCheckbox();
    }

    public class MacOSFactory : IGUIFactory
    {
        public IButton CreateButton() => new MacOSButton();
        public ICheckbox CreateCheckbox() => new MacOSCheckbox();
    }

    // 6. Основна програма
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Choose platform (Windows/MacOS):");
                string? platform = Console.ReadLine()?.Trim(); // Перевірка на null і видалення зайвих пробілів

                // Перевірка введення правильних даних
                if (string.IsNullOrEmpty(platform) || (platform != "Windows" && platform != "MacOS"))
                {
                    throw new ArgumentException("Invalid platform. Please enter 'Windows' or 'MacOS'.");
                }

                IGUIFactory factory = platform switch
                {
                    "Windows" => new WindowsFactory(),
                    "MacOS" => new MacOSFactory(),
                    _ => throw new ArgumentException("Unknown platform. Please enter 'Windows' or 'MacOS'.")
                };

                // Створення продуктів
                IButton button = factory.CreateButton();
                ICheckbox checkbox = factory.CreateCheckbox();

                // Відображення продуктів
                Console.WriteLine("Creating GUI elements:");
                button.Render();
                checkbox.Render();
            }
            catch (ArgumentException ex)
            {
                // Обробка помилки, якщо введено неправильну платформу
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Загальна обробка інших помилок
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
