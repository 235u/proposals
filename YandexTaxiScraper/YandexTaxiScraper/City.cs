﻿using System.Collections.Generic;

namespace YandexTaxiScraper
{
    public sealed class City
    {
        public static readonly IReadOnlyCollection<City> Values = new List<City>
        {
            new City(104, "Абакан"),
            new City(165, "Анадырь"),
            new City(051, "Архангельск и область"),
            new City(052, "Астрахань и область"),
            new City(107, "Барнаул"),
            new City(053, "Белгород и область"),
            new City(158, "Биробиджан"),
            new City(116, "Благовещенск"),
            new City(118, "Брянск и область"),
            new City(136, "Великий Новгород и область"),
            new City(113, "Владивосток и Приморский край"),
            new City(100, "Владикавказ"),
            new City(119, "Владимир и область"),
            new City(120, "Волгоград и область"),
            new City(121, "Вологда и область"),
            new City(122, "Воронеж и область"),
            new City(086, "Горно-Алтайск"),
            new City(105, "Грозный"),
            new City(318, "Дербент"),
            new City(147, "Екатеринбург и область"),
            new City(123, "Иваново и область"),
            new City(103, "Ижевск"),
            new City(007, "Иркутск и область"),
            new City(097, "Йошкар-Ола"),
            new City(101, "Казань"),
            new City(124, "Калининград и область"),
            new City(125, "Калуга и область"),
            new City(126, "Кемерово и область"),
            new City(127, "Киров и область"),
            new City(128, "Кострома и область"),
            new City(110, "Краснодар"),
            new City(111, "Красноярск"),
            new City(129, "Курган и область"),
            new City(130, "Курск и область"),
            new City(102, "Кызыл"),
            new City(132, "Липецк и область"),
            new City(133, "Магадан и область"),
            new City(090, "Магас"),
            new City(319, "Магнитогорск"),
            new City(085, "Майкоп и область"),
            new City(089, "Махачкала"),
            new City(003, "Москва и область"),
            new City(134, "Мурманск и область"),
            new City(315, "Набережные Челны"),
            new City(091, "Нальчик"),
            new City(163, "Нарьян-Мар"),
            new City(135, "Нижний Новгород и область"),
            new City(316, "Новокузнецк"),
            new City(137, "Новосибирск и область"),
            new City(138, "Омск и область"),
            new City(139, "Оренбург и область"),
            new City(140, "Орёл и область"),
            new City(141, "Пенза и область"),
            new City(112, "Пермь"),
            new City(094, "Петрозаводск"),
            new City(109, "Петропавловск-Камчатский"),
            new City(142, "Псков и область"),
            new City(005, "Ростов-на-Дону и область"),
            new City(143, "Рязань и область"),
            new City(166, "Салехард"),
            new City(144, "Самара и область"),
            new City(131, "Санкт-Петербург и область"),
            new City(098, "Саранск"),
            new City(145, "Саратов и область"),
            new City(148, "Смоленск и область"),
            new City(313, "Сочи"),
            new City(114, "Ставрополь"),
            new City(317, "Сургут"),
            new City(095, "Сыктывкар"),
            new City(149, "Тамбов и область"),
            new City(150, "Тверь и область"),
            new City(314, "Тольятти"),
            new City(151, "Томск и область"),
            new City(152, "Тула и область"),
            new City(153, "Тюмень и область"),
            new City(088, "Улан-Удэ"),
            new City(154, "Ульяновск и область"),
            new City(087, "Уфа"),
            new City(115, "Хабаровск"),
            new City(164, "Ханты-Мансийск"),
            new City(106, "Чебоксары"),
            new City(155, "Челябинск и область"),
            new City(093, "Черкесск"),
            new City(108, "Чита"),
            new City(092, "Элиста"),
            new City(146, "Южно-Сахалинск и область"),
            new City(099, "Якутск"),
            new City(156, "Ярославль и область")
        };

        private City(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}