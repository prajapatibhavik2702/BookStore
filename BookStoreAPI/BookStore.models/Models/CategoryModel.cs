﻿using BookStore.models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookStore.models.Models
{
    public class CategoryModel
    {
        public CategoryModel(){}
        public CategoryModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
