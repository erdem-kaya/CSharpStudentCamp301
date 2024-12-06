﻿using CSharpStudentCamp301.BusinessLayer.Abstract;
using CSharpStudentCamp301.DataAccessLayer.Abstract;
using CSharpStudentCamp301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudentCamp301.BusinessLayer.Concrete
{

    public class CategoryManager : ICategoryService
    {
        // Field 
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public List<Category> TGetAll()
        {
           return _categoryDal.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void TInsert(Category entity)
        {
            _categoryDal.Insert(entity);
        }
           
        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
