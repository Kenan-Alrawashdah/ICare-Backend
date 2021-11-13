using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetAllCategoryApiDto
    {
    
        public class Response
        {
            public List<CategoryModel> categories { get; set; }
        }

        public class CategoryModel
        {
            public int id { get; set; }

            public string Name { get; set; }

            public string ImagePath { get; set; }
        }
    }
}
