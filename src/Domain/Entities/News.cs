using System;
using System.Collections.Generic;
using System.Text;
using static HomiePages.Domain.Enums.Enums;

namespace HomiePages.Domain.Entities
{
    public class News
    {
        public int Id { get; set; }
        public NewsSources NewsSource { get; set; }
    }
}
