using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuz_csharp_lab2._1
{

    /*
     DeviceStatus используется для представления общего статуса устройства:
        Field1: true означает, что устройство работает,
        Field2: true означает наличие ошибки.

     */
    public class DeviceStatus
    {
        public bool Field1 { get; set; }
        public bool Field2 { get; set; }

        // Конструктор по умолчанию
        public DeviceStatus(bool field1 = false, bool field2 = false)
        {
            Field1 = field1;
            Field2 = field2;
        }

        // Конструктор копирования
        public DeviceStatus(DeviceStatus original)
        {
            Field1 = original.Field1;
            Field2 = original.Field2;
        }

        // Метод для вычисления эквивалентности полей
        public bool AreFieldsEquivalent()
        {
            return Field1 == Field2;
        }

        public bool AreStatusOk()
        {
            return Field1 && !Field2;
        }

        // Перегружаемый метод ToString()
        public override string ToString()
        {
            return $"DeviceStatus: {Field1}, {Field2}";
        }
    }

    /*
     AdvancedDeviceSettings расширяет функциональность DeviceStatus, добавляя идентификатор устройства (Number).
        Метод AreFieldsAndNumberEquivalent() проверяет, что устройство работает без ошибок и имеет идентификатор (отличный от -1).
        Метод PrintInfo() предоставляет удобный способ вывода информации об устройстве.
     */
    public class AdvancedDeviceSettings : DeviceStatus
    {
        public int Number { get; set; }

        // Конструктор по умолчанию
        public AdvancedDeviceSettings(bool field1 = false, bool field2 = false, int number = -1)
            : base(field1, field2)
        {
            Number = number;
        }

        // Конструктор копирования
        public AdvancedDeviceSettings(DeviceStatus original, int number = -1)
            : base(original)
        {
            Number = number;
        }

        // Метод для проверки эквивалентности полей и числа
        public bool AreFieldsAndNumberEquivalent()
        {
            return base.AreFieldsEquivalent() && Number != -1;
        }

        public bool AreStatusAndNumberValid()
        {
            return base.AreStatusOk() && Number != -1;
        }

        // Метод для вывода информации о классе
        public void PrintInfo()
        {
            Console.WriteLine($"AdvancedDeviceSettings: {ToString()}, Number: {Number}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем устройство с статусом работы и без ошибки
            DeviceStatus device1 = new DeviceStatus(true, false);

            // Проверяем статус устройства
            Console.WriteLine(device1.ToString()); // Выводит: DeviceStatus: True, False

            // Создаем устройство с ошибкой
            DeviceStatus device2 = new DeviceStatus(false, true);
            Console.WriteLine(device2.ToString()); // Выводит: DeviceStatus: False, True

            // Создаем расширенные настройки для устройства
            AdvancedDeviceSettings advancedSettings1 = new AdvancedDeviceSettings(true, false, 12345);
            advancedSettings1.PrintInfo();

            // Проверяем эквивалентность полей и настроек
            bool areStatusAndNumberValid = advancedSettings1.AreStatusAndNumberValid();
            bool areEquivalent = advancedSettings1.AreFieldsAndNumberEquivalent();
            Console.WriteLine($"Устройство работает без ошибок и с заданным идентификатором: {areStatusAndNumberValid}");
            Console.WriteLine($"Соответствие полей и номера устройства: {areEquivalent}");

            Console.WriteLine("============================================================");

            AdvancedDeviceSettings advancedSettings2 = new AdvancedDeviceSettings(true, true, 1234);
            advancedSettings2.PrintInfo();

            // Проверяем эквивалентность полей и настроек
            bool areStatusAndNumberValid2 = advancedSettings2.AreStatusAndNumberValid();
            bool areEquivalent2 = advancedSettings2.AreFieldsAndNumberEquivalent();
            Console.WriteLine($"Устройство работает без ошибок и с заданным идентификатором: {areStatusAndNumberValid2}");
            Console.WriteLine($"Соответствие полей и номера устройства: {areEquivalent2}");

            Console.ReadKey();
        }
    }
}
