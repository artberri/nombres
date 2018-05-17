using System;
using System.Threading.Tasks;
using Names.Domain.Entities;
using Names.Web.Model;

namespace Names.Web.ApiClients
{
    public class MixedApiClient
    {
        private readonly NameApiClient _nameApiClient;
        private readonly QuantityApiClient _quantityApiClient;

        public MixedApiClient(NameApiClient nameApiClient, QuantityApiClient quantityApiClient)
        {
            _nameApiClient = nameApiClient;
            _quantityApiClient = quantityApiClient;
        }

        public async Task<TagName[]> GetNames(int province, int year)
        {
            TagName[] names;

            if (year > 0 && province > 0)
            {
                names = await _nameApiClient.GetByYearAndProvince(province, year);
            }
            else if (year > 0)
            {
                names = await _nameApiClient.GetByYear(year);
            }
            else if (province > 0)
            {
                names = await _nameApiClient.GetByProvince(province);
            }
            else
            {
                names = await _nameApiClient.GetAll();
            }

            return names;
        }

        public async Task<Quantity[]> GetQuantities(TagName name, int province)
        {
            Quantity[] quantities;
            if (province > 0)
            {
                quantities = await _quantityApiClient.GetByNameAndProvince(name.Id, province);
            }
            else
            {
                quantities = await _quantityApiClient.GetByName(name.Id);
            }

            return quantities;
        }
    }
}
