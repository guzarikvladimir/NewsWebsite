using System.Collections.Generic;
using Service.Interfaces.Entities;

namespace NewsWebsite.Models
{
    public class NewsListViewModel
    {
        public List<NewsEntity> News { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}