namespace ProjectT.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ProjectT.Data.Models;

    public class ProductsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Products.AnyAsync())
            {
                return;
            }

            var products =
                new List<(string Name, string Description,string Image, List<string> Images, decimal Price, int Quantity,
                    string size, int sellCount)>
                {
                    (
                        "Levi's® Print T-shirt",
                        "Material & care Outer fabric material: 100% cotton Fabric: Jersey Care instructions: Machine wash at 30°C",
                        "https://img01.ztat.net/article/LE/22/2O/00/RQ/11/LE222O00R-Q11@20.jpg?imwidth=1800",
                        new List<string>
                        {
                            "https://img01.ztat.net/article/LE/22/2O/00/RQ/11/LE222O00R-Q11@21.jpg?imwidth=1800",
                            "https://img01.ztat.net/article/LE/22/2O/00/RQ/11/LE222O00R-Q11@19.jpg?imwidth=1800",
                            "https://img01.ztat.net/article/LE/22/2O/00/RQ/11/LE222O00R-Q11@17.jpg?imwidth=1800&filter=packshot",
                        },
                        22.50m,
                        10,
                        "xs",
                        22
                    ),
                    (
                        "Karl Kani SIGNATURE RINGER TEE - Print T-shirt",
                        "Material & care Outer fabric material: 50% polyester, 50% cotton Fabric: Jersey Care instructions: Do not tumble dry, machine wash at 30°C",
                        "https://img01.ztat.net/article/KK/12/2O/02/2C/11/KK122O022-C11@4.jpg?imwidth=156",
                        new List<string>
                        {
                            "https://img01.ztat.net/article/KK/12/2O/02/2C/11/KK122O022-C11@9.jpg?imwidth=156",
                            "https://img01.ztat.net/article/KK/12/2O/02/2C/11/KK122O022-C11@10.jpg?imwidth=156",
                            "https://img01.ztat.net/article/KK/12/2O/02/2C/11/KK122O022-C11@11.jpg?imwidth=156",
                        },
                        33.50m,
                        10,
                        "xs",
                        10
                    ),
                    (
                        "Levi's®  Print T-shirt",
                        "Material & care Outer fabric material: 100% cotton Fabric: Jersey Care instructions: Machine wash at 30°C",
                        "https://img01.ztat.net/article/LE/22/2O/00/TA/11/LE222O00T-A11@17.jpg?imwidth=156",
                        new List<string>
                        {
                            "https://img01.ztat.net/article/LE/22/2O/00/TA/11/LE222O00T-A11@18.jpg?imwidth=156",
                            "https://img01.ztat.net/article/LE/22/2O/00/TA/11/LE222O00T-A11@15.jpg?imwidth=156",
                            "https://img01.ztat.net/article/LE/22/2O/00/TA/11/LE222O00T-A11@14.1.jpg?imwidth=156&filter=packshot",
                        },
                        47.59m,
                        20,
                        "xs",
                        0
                    ),
                    (
                        "Even&Odd 2 PACK - Print T-shirt",
                        "Material & care Outer fabric material: 95% cotton, 5% elastane Fabric: Jersey Care instructions: Do not tumble dry, machine wash at 30°C, Machine wash on gentle cycle",
                        "https://img01.ztat.net/article/EV/42/1D/1D/YQ/11/EV421D1DY-Q11@12.1.jpg?imwidth=156",
                        new List<string>
                        {
                            "https://img01.ztat.net/article/EV/42/1D/1D/YQ/11/EV421D1DY-Q11@9.1.jpg?imwidth=156",
                            "https://img01.ztat.net/article/EV/42/1D/1D/YQ/11/EV421D1DY-Q11@14.1.jpg?imwidth=156",
                            "https://img01.ztat.net/article/EV/42/1D/1D/YQ/11/EV421D1DY-Q11@11.1.jpg?imwidth=156",
                            "https://img01.ztat.net/article/EV/42/1D/1D/YQ/11/EV421D1DY-Q11@10.1.jpg?imwidth=156",
                        },
                        44.79m,
                        20,
                        "xs",
                        15
                    ),
                    (
                        "Protest  SET - Bikini",
                        "Outer fabric material: 80% polyamide, 20% elastane Bottom part material: 80% polyamide, 20% elastaneTop part material: 80% polyamide, 20% elastane Filling: 100% polyester  Lining: 100% polyester Care instructions: Do not tumble dry, Hand wash only, Do not iron, Do not bleach",
                        "https://img01.ztat.net/article/P4/48/1L/01/JQ/11/P4481L01J-Q11@13.jpg?imwidth=156",
                        new List<string>
                        {
                            "https://img01.ztat.net/article/P4/48/1L/01/JQ/11/P4481L01J-Q11@17.jpg?imwidth=156",
                            "https://img01.ztat.net/article/P4/48/1L/01/JQ/11/P4481L01J-Q11@15.jpg?imwidth=156",
                            "https://img01.ztat.net/article/P4/48/1L/01/JQ/11/P4481L01J-Q11@16.jpg?imwidth=156",
                        },
                        19.89m,
                        20,
                        "xs",
                        1
                    ),
                    (
                        "Protest ALE - Bikini",
                        "Material & care Outer fabric material: 80% polyamide, 20% elastane Bottom part material: 80% polyamide, 20% elastane Filling: 100% polyester Lining: 100% polyester Care instructions: Do not tumble dry, Hand wash only, Do not iron, Do not bleach",
                        "https://img01.ztat.net/article/L8/38/1A/00/7Q/11/L8381A007-Q11@13.jpg?imwidth=156",
                        new List<string>
                        {
                            "https://img01.ztat.net/article/L8/38/1A/00/7Q/11/L8381A007-Q11@12.jpg?imwidth=156",
                            "https://img01.ztat.net/article/L8/38/1A/00/7Q/11/L8381A007-Q11@11.jpg?imwidth=156",
                            "https://img01.ztat.net/article/L8/38/1A/00/7Q/11/L8381A007-Q11@10.jpg?imwidth=156",
                        },
                        119.89m,
                        20,
                        "xs",
                        0
                    ),
                    (
                        "Hunkemöller WILLOW - Underwired bra",
                        "Material & care Outer fabric material: 67% polyamide, 22% polyester, 11% elastane Fabric: Lace Care instructions: Hand wash only",
                        "https://img01.ztat.net/article/HM/18/1A/1F/JJ/11/HM181A1FJ-J11@13.jpg?imwidth=156",
                        new List<string>
                        {
                            "https://img01.ztat.net/article/HM/18/1A/1F/JJ/11/HM181A1FJ-J11@14.jpg?imwidth=156",
                            "https://img01.ztat.net/article/HM/18/1A/1F/JJ/11/HM181A1FJ-J11@17.jpg?imwidth=156",
                            "https://img01.ztat.net/article/HM/18/1A/1F/JJ/11/HM181A1FJ-J11@16.jpg?imwidth=156",
                        },
                        9.89m,
                        200,
                        "xs",
                        10
                    ),
                    (
                        "LASCANA Push-up bra",
                        "Material & care Outer fabric material: 100% silk Fabric: Lace Care instructions: Hand wash only",
                        "https://img01.ztat.net/article/L8/38/1A/00/UQ/13/L8381A00U-Q13@9.jpg?imwidth=156",
                        new List<string>
                        {
                            "https://img01.ztat.net/article/L8/38/1A/00/UQ/13/L8381A00U-Q13@10.jpg?imwidth=156",
                            "https://img01.ztat.net/article/L8/38/1A/00/UQ/13/L8381A00U-Q13@8.jpg?imwidth=156",
                            "https://img01.ztat.net/article/L8/38/1A/00/UQ/13/L8381A00U-Q13@6.jpg?imwidth=156",
                            "https://img01.ztat.net/article/L8/38/1A/00/UQ/13/L8381A00U-Q13@7.jpg?imwidth=156",
                        },
                        9.89m,
                        200,
                        "xs",
                        110
                    ),
                    (
                        "Even&Odd BASIC - MINI A-LINE SKIRT - A-line skirt",
                        "Material & care Outer fabric material: 95% viscose, 5% elastane Fabric: Jersey Care instructions: Do not tumble dry, machine wash at 30°C, Machine wash on gentle cycle",
                        "https://img01.ztat.net/article/EV/42/1B/08/SQ/11/EV421B08S-Q11@7.jpg?imwidth=156",
                        new List<string>
                        {
                            "https://img01.ztat.net/article/EV/42/1B/08/SQ/11/EV421B08S-Q11@4.jpg?imwidth=156",
                            "https://img01.ztat.net/article/EV/42/1B/08/SQ/11/EV421B08S-Q11@9.jpg?imwidth=156",
                            "https://img01.ztat.net/article/EV/42/1B/08/SQ/11/EV421B08S-Q11@6.jpg?imwidth=156",
                            "https://img01.ztat.net/article/EV/42/1B/08/SQ/11/EV421B08S-Q11@8.jpg?imwidth=156&filter=packshot",
                        },
                        9.89m,
                        180,
                        "xs",
                        78
                    ),
                };

            foreach (var product in products)
            {
                var newProduct = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Image = product.Image,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Created_On = DateTime.UtcNow,
                    Size = product.size,
                    SellCount = product.sellCount,
                };

                await dbContext.Products.AddAsync(newProduct);

                foreach (var images in product.Images)
                {
                    var newImages = new Image
                    {
                        Url = images,
                        ProductId = newProduct.Id,
                    };
                    await dbContext.Images.AddAsync(newImages);
                }
            }
        }
    }
}
