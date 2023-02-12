using System;
using System.Collections.Generic;

namespace Tourists
{
    class Program
    {
        static List<City> cities = new List<City>();

        static void Main(string[] args)
        {
            var DB = new CityDB();
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

            bool isFromEU = !(_departureCity.Name == "Мадрид" || _departureCity.Name == "Кишинёв" || _departureCity.Name == "Лондон");

            for (int k = 0; k < _citiesToVisit.Count; k++)
            {
                totalCost += _citiesToVisit[k].Price;
            }

            foreach (var city in _citiesToVisit)
            {
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

        class CityDB
        {
            public void initial()
            {
                city1.Name = "Берлин";
                city1.Price = 399;
                city1.Transit = 175;
                cities.Add(city1);

                city2.Name = "Прага";
                city2.Price = 300;
                city2.Transit = 270;
                cities.Add(city2);

                city3.Name = "Париж";
                city3.Price = 350;
                city3.Transit = 220;
                cities.Add(city3);

                city4.Name = "Рига";
                city4.Price = 250;
                city4.Transit = 170;
                cities.Add(city4);

                city5.Name = "Лондон";
                city5.Price = 390;
                city5.Transit = 270;
                cities.Add(city5);

                city6.Name = "Ватикан";
                city6.Price = 500;
                city6.Transit = 350;
                cities.Add(city6);

                city7.Name = "Палерио";
                city7.Price = 230;
                city7.Transit = 150;
                cities.Add(city7);

                city8.Name = "Варшава";
                city8.Price = 300;
                city8.Transit = 190;
                cities.Add(city8);

                city9.Name = "Кишинёв";
                city9.Price = 215;
                city9.Transit = 110;
                cities.Add(city9);

                city10.Name = "Мадрид";
                city10.Price = 260;
                city10.Transit = 190;
                cities.Add(city10);

                city11.Name = "Будапешт";
                city11.Price = 269;
                city11.Transit = 230;
                cities.Add(city11);
            }
            public City city1 = new City();
            public City city2 = new City();
            public City city3 = new City();
            public City city4 = new City();
            public City city5 = new City();
            public City city6 = new City();
            public City city7 = new City();
            public City city8 = new City();
            public City city9 = new City();
            public City city10 = new City();
            public City city11 = new City();
        }
    }
}
