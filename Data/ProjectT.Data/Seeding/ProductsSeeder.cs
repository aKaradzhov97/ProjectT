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
                    int sellCount)>
                {
                    (
                        "Mens T-Shirt",
                        "Luftfilter, Ölfilter, Zündkerzen - die Marke *Champion* gehört zu den ganz großen der Szene.",
                        "https://cdn1.louis.de/dynamic/articles/o_pad,w_1800,h_1800,ha_center,va_center,c_fff/1c.01.32.D3ChampionTShirtWeiss21859427019.JPG",
                        new List<string>
                        {
                            "https://cdn1.louis.de/dynamic/articles/o_pad,w_1800,h_1800,ha_center,va_center,c_fff/1c.01.32.D3ChampionTShirtWeiss21859427019.JPG",
                            "https://cdn1.louis.de/dynamic/articles/o_pad,w_1800,h_1800,ha_center,va_center,c_fff/1c.01.32.D3ChampionTShirtWeiss21859427019.JPG",
                            "https://cdn1.louis.de/dynamic/articles/o_pad,w_1800,h_1800,ha_center,va_center,c_fff/1c.01.32.D3ChampionTShirtWeiss21859427019.JPG",
                        },
                        22.50m,
                        10,
                        22
                    ),
                    (
                        "Mens T-Shirt",
                        "Luftfilter, Ölfilter, Zündkerzen - die Marke *Champion* gehört zu den ganz großen der Szene.",
                        "https://cdn03.plentymarkets.com/j1rx4udxin3f/item/images/1601/full/Schwarz.jpg",
                        new List<string>
                        {
                            "https://cdn03.plentymarkets.com/j1rx4udxin3f/item/images/1601/full/Schwarz.jpg",
                            "https://cdn03.plentymarkets.com/j1rx4udxin3f/item/images/1601/full/Schwarz.jpg",
                            "https://cdn03.plentymarkets.com/j1rx4udxin3f/item/images/1601/full/Schwarz.jpg",
                        },
                        33.50m,
                        10,
                        10
                    ),
                    (
                        "Mens T-Shirt - Nike",
                        "Luftfilter, Ölfilter, Zündkerzen - die Marke *Champion* gehört zu den ganz großen der Szene.",
                        "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/e8vqdl1xb7maontxnbw2/sportswear-t-shirt-fur-babys-WLlSQR.jpg",
                        new List<string>
                        {
                            "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/e8vqdl1xb7maontxnbw2/sportswear-t-shirt-fur-babys-WLlSQR.jpg",
                            "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/e8vqdl1xb7maontxnbw2/sportswear-t-shirt-fur-babys-WLlSQR.jpg",
                            "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/e8vqdl1xb7maontxnbw2/sportswear-t-shirt-fur-babys-WLlSQR.jpg",
                            "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto/e8vqdl1xb7maontxnbw2/sportswear-t-shirt-fur-babys-WLlSQR.jpg",
                        },
                        47.59m,
                        20,
                        0
                    ),
                    (
                        "Mens T-Shirt Puma New Collection",
                        "Luftfilter, Ölfilter, Zündkerzen - die Marke *Champion* gehört zu den ganz großen der Szene.",
                        "https://kickz.akamaized.net/de/media/images/p/600/puma-Archive_Logo_T_Shirt-Puma_White-1.jpg",
                        new List<string>
                        {
                            "https://kickz.akamaized.net/de/media/images/p/600/puma-Archive_Logo_T_Shirt-Puma_White-1.jpg",
                            "https://kickz.akamaized.net/de/media/images/p/600/puma-Archive_Logo_T_Shirt-Puma_White-1.jpg",
                            "https://kickz.akamaized.net/de/media/images/p/600/puma-Archive_Logo_T_Shirt-Puma_White-1.jpg",
                            "https://kickz.akamaized.net/de/media/images/p/600/puma-Archive_Logo_T_Shirt-Puma_White-1.jpg",
                        },
                        44.79m,
                        20,
                        15
                    ),
                    (
                        "Womens T-Shirt New Collection (2020)",
                        "Luftfilter, Ölfilter, Zündkerzen - die Marke *Champion* gehört zu den ganz großen der Szene.",
                        "https://images-na.ssl-images-amazon.com/images/I/81hLKdZYpAL._AC_UY1000_.jpg",
                        new List<string>
                        {
                            "https://images-na.ssl-images-amazon.com/images/I/81hLKdZYpAL._AC_UY1000_.jpg",
                            "https://images-na.ssl-images-amazon.com/images/I/81hLKdZYpAL._AC_UY1000_.jpg",
                            "https://images-na.ssl-images-amazon.com/images/I/81hLKdZYpAL._AC_UY1000_.jpg",
                            "https://images-na.ssl-images-amazon.com/images/I/81hLKdZYpAL._AC_UY1000_.jpg",
                        },
                        19.89m,
                        20,
                        1
                    ),
                    (
                        "Womens Sexy Prashchishta New Collection (2020)",
                        "Luftfilter, Ölfilter, Zündkerzen - die Marke *Champion* gehört zu den ganz großen der Szene.",
                        "https://cdn.shopify.com/s/files/1/2424/0679/products/386377FYB_OM_B_1024x1024.jpg?v=1553278833",
                        new List<string>
                        {
                            "https://cdn.shopify.com/s/files/1/2424/0679/products/386377FYB_OM_B_1024x1024.jpg?v=1553278833",
                            "https://cdn.shopify.com/s/files/1/2424/0679/products/386377FYB_OM_B_1024x1024.jpg?v=1553278833",
                            "https://cdn.shopify.com/s/files/1/2424/0679/products/386377FYB_OM_B_1024x1024.jpg?v=1553278833",
                        },
                        119.89m,
                        20,
                        0
                    ),
                    (
                        "Mens Everlast Shoes",
                        "Luftfilter, Ölfilter, Zündkerzen - die Marke *Champion* gehört zu den ganz großen der Szene.",
                        "https://ae01.alicdn.com/kf/H465ff30618374811bdbcdd7c1f89a9d1b/EVERLAST-Spring-Summer-man-s-casual-sports-shoes-Fahion-patchwork-ventilated-man-s-casual-shoes.jpg",
                        new List<string>
                        {
                            "https://ae01.alicdn.com/kf/H465ff30618374811bdbcdd7c1f89a9d1b/EVERLAST-Spring-Summer-man-s-casual-sports-shoes-Fahion-patchwork-ventilated-man-s-casual-shoes.jpg",
                            "https://ae01.alicdn.com/kf/H465ff30618374811bdbcdd7c1f89a9d1b/EVERLAST-Spring-Summer-man-s-casual-sports-shoes-Fahion-patchwork-ventilated-man-s-casual-shoes.jpg",
                            "https://ae01.alicdn.com/kf/H465ff30618374811bdbcdd7c1f89a9d1b/EVERLAST-Spring-Summer-man-s-casual-sports-shoes-Fahion-patchwork-ventilated-man-s-casual-shoes.jpg",
                        },
                        9.89m,
                        200,
                        10
                    ),
                    (
                        "Mens Everlast Sweatshirt",
                        "Luftfilter, Ölfilter, Zündkerzen - die Marke *Champion* gehört zu den ganz großen der Szene.",
                        "https://images-na.ssl-images-amazon.com/images/I/61ayW7dnxrL._AC_UX679_.jpg",
                        new List<string>
                        {
                            "https://images-na.ssl-images-amazon.com/images/I/61ayW7dnxrL._AC_UX679_.jpg",
                            "https://images-na.ssl-images-amazon.com/images/I/61ayW7dnxrL._AC_UX679_.jpg",
                            "https://images-na.ssl-images-amazon.com/images/I/61ayW7dnxrL._AC_UX679_.jpg",
                            "https://images-na.ssl-images-amazon.com/images/I/61ayW7dnxrL._AC_UX679_.jpg",
                        },
                        9.89m,
                        200,
                        110
                    ),
                    (
                        "NoFear T-Shirt",
                        "Luftfilter, Ölfilter, Zündkerzen - die Marke *Champion* gehört zu den ganz großen der Szene.",
                        "https://ukstore.nofear.com/images/products/59855803_l.jpg",
                        new List<string>
                        {
                            "https://ukstore.nofear.com/images/products/59855803_l.jpg",
                            "https://ukstore.nofear.com/images/products/59855803_l.jpg",
                            "https://ukstore.nofear.com/images/products/59855803_l.jpg",
                            "https://ukstore.nofear.com/images/products/59855803_l.jpg",
                        },
                        9.89m,
                        180,
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
                    SellCount = product.sellCount,
                };

                await dbContext.Products.AddAsync(newProduct);

                foreach (var images in product.Images)
                {
                    var newImages = new Image
                    {
                        ImageUrl = images,
                        ProductId = newProduct.Id,
                    };
                    await dbContext.Images.AddAsync(newImages);
                }
            }
        }
    }
}