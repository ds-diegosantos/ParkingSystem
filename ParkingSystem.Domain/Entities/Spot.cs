﻿using ParkingSystem.Domain.Validation;

namespace ParkingSystem.Domain.Entities
{
    public class Spot : Entity
    {
        public int Number { get; private set; }
        public bool IsOccupied { get; private set; }
        public int CategoryId { get; set; }

        public Spot(int number)
        {
            ValidateNumber(number);
            IsOccupied = false;
        }

        public void Update(int id, int number, bool isOccupied, int categoryId)
        {
            ValidateId(id);
            ValidateNumber(number);
            IsOccupied = isOccupied;
            CategoryId = categoryId;
        }

        private void ValidateNumber(int number)
        {
            DomainExceptionValidation.When(number < 0, "Invalid number value.");
            Number = number;
        }
    }
}
