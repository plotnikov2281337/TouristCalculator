using System;
using System.Collections.Generic;

namespace Tourists
{
    class Program
    {
        static List<City> cities = new List<City>();

        static void Main(string[] args)
        {
            var DB = new CityDB(_cities: cities);
            DB.initial();

            Console.WriteLine("Добро пожаловать в калькулятор стоимости поездки!");
            Console.WriteLine("Пожалуйста, введите город вашего отправления:");
            Console.WriteLine("Все города должны быть написаны на русском!!");

            string departureCity = Console.ReadLine();
            City _departureCity = new City();

            foreach (var city in cities)
            {
                if (city.Name == departureCity) _departureCity = city;
            }

            Console.WriteLine("Пожалуйста, укажите до 3 городов, которые вы хотели бы посетить:");

            string[] citiesToVisit = new string[3];
            List<City> _citiesToVisit = new List<City>();

            for (int i = 0; i < 3; i++)
            {
                citiesToVisit[i] = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(citiesToVisit[i]))
                {
                    break;
                }
                foreach (var city in cities)
                {
                       if (city.Name == citiesToVisit[i]) _citiesToVisit.Add(city);
                   }
            }
            Console.WriteLine("Пожалуйста, введите стоимость вашей поездки:");
            double tripCost = Convert.ToDouble(Console.ReadLine());

            double totalCost = 0;

            

            for (int k = 0; k < _citiesToVisit.Count; k++)
            {
                totalCost += _citiesToVisit[k].Price;
            }

            foreach (var city in _citiesToVisit)
            {
                bool isFromEU = !(_departureCity.Name == "Мадрид" || _departureCity.Name == "Кишинёв" || _departureCity.Name == "Лондон");
                
                if (_departureCity.Name == "Мадрид")
                {
                    totalCost += DB.city3.Transit;
                }
                if (_departureCity.Name == "Кишинёв")
                {
                    totalCost += DB.city11.Transit;
                }
                if (_departureCity.Name == "Лондон")
                {
                    totalCost += DB.city5.Transit;
                }
                if (_departureCity.Name == "Рига")
                {
                    totalCost += DB.city8.Transit;
                }
                if (city.Name == "Ватикан")
                {
                    totalCost += totalCost * 0.5;
                }
                if (city.Name == "Берлин")
                {
                    totalCost += city.Transit * 0.13;
                }
                if (city.Name == "Палермо")
                {
                    if (_departureCity == DB.city5)
                        totalCost += city.Transit * 0.07;
                    if (_departureCity == DB.city9)
                        totalCost += city.Transit * 0.11;
                }
                if (city.Name == "Рига" && _departureCity == DB.city3)
                {
                    totalCost += city.Transit * 0.09;
                }
                if (city.Name == "Палермо")
                {
                    totalCost += DB.city1.Transit + DB.city8.Transit;
                }
                if (!isFromEU)
                {
                    totalCost += city.Transit * 0.04;
                }
                else
                {
                    totalCost += city.Transit;
                }
                _departureCity = city;
            }
            Console.WriteLine("Общая стоимость вашей поездки составляет: $" + totalCost);

            if (totalCost > tripCost)
            {
                Console.WriteLine("Вашего бюджета не хватит для выбранного маршрута.");
            }

            Console.ReadLine();
        }
}
