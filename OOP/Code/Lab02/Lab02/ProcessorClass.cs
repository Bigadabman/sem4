using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    internal class ProcessorClass
    {

        
            // Свойства процессора
            public string Series { get; set; } // Серия процессора
            public string Model { get; set; } // Модель процессора
            public int CoreCount { get; set; } // Количество ядер
            public double Frequency { get; set; } // Частота процессора (в ГГц)
            public double MaxFrequency { get; set; } // Максимальная частота (в ГГц)
            public string Architecture { get; set; } // Разрядность архитектуры (x86 или x64)
            public int CacheSize { get; set; } // Размер кэша (в МБ или КБ)

            // Конструктор для инициализации объекта процессора
            public ProcessorClass(string series, string model, int coreCount, double frequency, double maxFrequency, string architecture, int cacheSize)
            {
                Series = series;
                Model = model;
                CoreCount = coreCount;
                Frequency = frequency;
                MaxFrequency = maxFrequency;
                Architecture = architecture;
                CacheSize = cacheSize;
            }

            // Метод для вывода информации о процессоре
            public void DisplayInfo()
            {
                Console.WriteLine($"Серия: {Series}");
                Console.WriteLine($"Модель: {Model}");
                Console.WriteLine($"Количество ядер: {CoreCount}");
                Console.WriteLine($"Частота: {Frequency} ГГц");
                Console.WriteLine($"Максимальная частота: {MaxFrequency} ГГц");
                Console.WriteLine($"Разрядность архитектуры: {Architecture}");
                Console.WriteLine($"Размер кэша: {CacheSize} КБ");
            }

            

        }

    }

