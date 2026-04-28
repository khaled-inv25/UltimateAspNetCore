using CompanyEmployees.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEmployees.EntityFramework.Data
{
    public class CompanyDataSeeder : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(Companies());
        }

        private Company[] Companies()
        {
            Company[] data = [
                    new Company
                    {
                        Id = new Guid("a627d731-5382-4bf4-87c0-4f256fddd004"),
                        Name = "Ebda3Soft",
                        Address = "Marib street, Al-akwa3 building",
                        Country = "Yemen"
                    },
                    new Company
                    {
                        Id = new Guid("73625b4e-4149-4912-b6d9-08a595d78124"),
                        Name = "YemenSoft",
                        Address = "50 street, YemenSoft building",
                        Country = "Yemen"
                    },
                    new Company
                    {
                        Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                        Name = "IT_Solutions Ltd",
                        Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                        Country = "USA"
                    },
                    new Company
                    {
                        Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                        Name = "Admin_Solutions Ltd",
                        Address = "312 Forest Avenue, BF 923",
                        Country = "USA"
                    }
                ];

            return data;
        }
    }
}
