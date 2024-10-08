﻿using Business.Abstract;
using Business.Constants;
using Castle.Core.Resource;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
           return new SuccessResult(Messages<Customer>.EntityDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages<Customer>.EntityListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=> c.CustomerId== customerId),Messages<Customer>.EntityListed);
        }

        public IResult Insert(Customer customer)
        {
            _customerDal.Insert(customer);
            return new SuccessResult(Messages<Customer>.EntityAdded);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages<Customer>.EntityUpdated);
        }
    }
}
