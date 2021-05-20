using System;

namespace Lab1.Entities.Parameters
{
    public class CategoryParameters : QueryStringParameters
    {
        public CategoryParameters()
        {
            OrderBy = "name";
        }
        public string CategoryName { get; set; } = "";
    }
}