﻿namespace Lab1.Entities.Parameters
{
    public abstract class QueryStringParameters
    {

        const int MaxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public string? OrderBy { get; set; }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}