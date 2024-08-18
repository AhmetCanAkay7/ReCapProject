﻿using Business.Abstract;
using Business.Constants;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages<Rental>.EntityDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages<Rental>.EntityListed);
        }

        public IDataResult<Rental> GetById(int entityId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==entityId));
        }

        public IResult Insert(Rental entity)
        {
            if (entity.ReturnDate==null) 
            {
                return new ErrorResult("Araç kiralama başarısız.");
            }
            _rentalDal.Insert(entity);
            return new SuccessResult("Kiralama işlemi başarılı.");

        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages<Rental>.EntityUpdated);
        }
    }
}
