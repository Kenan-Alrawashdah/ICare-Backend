using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetAllDrugsApiDTO
    {
        public class Response
        {
            public int Id { get; set; }
            public int DrugCategoryId { get; set; }

            public string Name { get; set; }

            public double Price { get; set; }

            public string PicturePath { get; set; }

            public string Brand { get; set; }

            public int AvailableQuantity { get; set; }

            public string Description { get; set; }
        }
    }
}
