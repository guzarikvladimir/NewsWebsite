using System;

namespace NewsWebsite.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }

        // Кол-во товаров на одной странице
        public int ItemPerPage { get; set; }

        // Номер текущей страницы
        public int CurrentPage { get; set; }

        // Общее кол-во страниц
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemPerPage);
    }
}