using Mad.Data.Entities.Chocolate;

namespace Mad.Bl.Services.Chocolate
{
    public class ChocolateService
    {
        public string NewCompany(string companyName)
        {
            string newCompany;
            if (Company.Name.Contains(companyName))
            {
                newCompany = "This company already exist.";
            }
            else
            {
                Company.Id.Add(Guid.NewGuid());
                Company.Name.Add(companyName);
                newCompany = $"ID: {Company.Id[^1]}; Name: {Company.Name[^1]}";
            }
            return newCompany;
        }
        public List<string> GetCompanies()
        {
            var list = new List<string>();
            for (int i = 0; i < Company.Name.Count; i++)
            {
                list.Add($"ID: {Company.Id[i]}; Name: {Company.Name[i]}");
            }
            return list;
        }
        public string NewBrand(string brandName)
        {
            string newBrand;
            if (Brand.Name.Contains(brandName))
            {
                newBrand = "This brand already exist.";
            }
            else
            {
                Brand.Id.Add(Guid.NewGuid());
                Brand.Name.Add(brandName);
                newBrand = $"ID: {Brand.Id[^1]}; Name: {Brand.Name[^1]}";
            }
            return newBrand;
        }
        public List<string> GetBrands()
        {
            var list = new List<string>();
            for (int i = 0; i < Brand.Name.Count; i++)
            {
                list.Add($"ID: {Brand.Id[i]}; Name: {Brand.Name[i]}");
            }
            return list;
        }
        public List<string> SearchCompany(string companyName)
        {
            var list = new List<string>();
            if (Company.Name.Contains(companyName)) {
                int index = 0;
                for (int i = 0; i < Company.Name.Count; i++)
                {   
                    if (companyName == Company.Name[i]) break;
                    index++;
                }
                list.Add($"ID: {Company.Id[index]} Name: {Company.Name[index]}");
            } else
            {
                list.Add("This company not exist.");
            }
            return list;
        }
        public List<string> SearchBrand(string brandName)
        {
            var list = new List<string>();
            if (Brand.Name.Contains(brandName))
            {
                int index = 0;
                for (int i = 0; i < Brand.Name.Count; i++)
                {
                    if (brandName == Brand.Name[i]) break;
                    index++;
                }
                list.Add($"ID: {Brand.Id[index]} Name: {Brand.Name[index]}");
            }
            else
            {
                list.Add("This brand not exist.");
            }
            return list;
        }
    }
}
