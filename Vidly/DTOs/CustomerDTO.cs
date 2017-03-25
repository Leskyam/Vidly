using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

         public DateTime? Dob { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public static IEnumerable<CustomerDto> MapToCustomersDto(IEnumerable<Customer> customers)
        {
            /* Old fashion:
            foreach (var customer in customers)
            {
                customersDto.Add(new CustomerDto
                {
                    Id = customer.Id,
                    Dob = customer.Dob,
                    Name = customer.Name,
                    IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter,
                    MembershipTypeId = customer.MembershipTypeId
                });
            }
            */
            // New way:
            return customers.Select(customer => new CustomerDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                Dob = customer.Dob,
                MembershipTypeId = customer.MembershipTypeId,
                IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter
            });
        }

        public static Customer MapFromCustomerDto(CustomerDto customerDto, Customer customer)
        {
            customer.Name = customerDto.Name;
            customer.Dob = customerDto.Dob;
            customer.MembershipTypeId = customerDto.MembershipTypeId;
            customer.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;

            return customer;
        }

    }
}