using System.Collections.Generic;

namespace ACM.BL.repo
{
    public class AddressRepository
    {
        public Address Retrieve(int addressId)
        {
            Address address = new Address();

            if(addressId == 1)
            {
                address.AddressType = 1;
                address.Street1 = "1560 Boulder Ave";
                address.Street2 = "Apt 310";
                address.City = "Denver";
                address.State = "Colorado";
                address.Country = "USA";
                address.PostalCode = "80211";
            }

            return address;
        }

        public IEnumerable<Address> RetrieveByCustomerId(int customerId)
        {
            var AddressList = new List<Address>();
            Address address = new Address()
            {
                AddressType = 1,
                Street1 = "1560 Boulder Ave",
                Street2 = "Apt 310",
                City = "Denver",
                State = "Colorado",
                Country = "USA",
                PostalCode = "80211"
            };
            AddressList.Add(address);

            address = new Address()
            {
                AddressType = 2,
                Street1 = "1561 Boulder Ave",
                Street2 = "Apt 999",
                City = "Denver",
                State = "Colorado",
                Country = "USA",
                PostalCode = "80211"
            };
            AddressList.Add(address);

            return AddressList;

        }

        public bool Save(Address address)
        {
            return true;
        }
    }
}