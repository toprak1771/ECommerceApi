using _StarbucksApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _StarbucksApi.Data
{
    public class DataGenerator
    {
        public async static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StarbucksContext(serviceProvider.GetRequiredService<DbContextOptions<StarbucksContext>>()))
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(
                        new Category() { CategoryName = "Coffee Beans", Imgsource = "/Files/Images/coffeebeans.jpg" },
                        new Category() { CategoryName = "Tea Box", Imgsource = "/Files/Images/teabox.jpg" },
                        new Category() { CategoryName = "Peripherals", Imgsource = "/Files/Images/teabox.jpg" }

                        );
                };
                await context.SaveChangesAsync();

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(
                        new Product() { ProductName = "Blonde Espresso Roast", Description = "Yoğun ve zengin aromalar ile karamelsi bir tatlılık ", AddTime = DateTime.Now.AddDays(-17), Price = 180, CategoryId = 1, Imgsource = "https://content.sbuxtr.com/images/96d1933e44d22ac98b174d29b499eebe.jpg" },
                        new Product() { ProductName = "Veranda Blend", Description = " Yumuşak kakao  ve hafif kavrulmuş fındık nüansları", AddTime = DateTime.Now.AddDays(-10), Price = 85, CategoryId = 1, Imgsource = "https://content.sbuxtr.com/images/128eb51584ba5700de46493604f0d053.jpg" },
                        new Product() { ProductName = "Kenya", Description = "Başka hiçbir ülkenin kahvelerinde bulunmayan belirgin greyfurt ve kuş üzümü aroması", AddTime = DateTime.Now.AddDays(-14), Price = 80, CategoryId = 1, Imgsource = "https://content.sbuxtr.com/images/e9344c178122926cb199be6371b9af47.jpg" },
                        new Product() { ProductName = "Indonesia West Java", Description = "Bitkisel notalarla birlikte vanilya bean lezzeti ve şurupsu bir gövde hissi", AddTime = DateTime.Now.AddDays(-7), Price = 120, CategoryId = 1, Imgsource = "https://content.sbuxtr.com/images/688509421cb148e7f0d37cd1c1faf842.jpg" },
                        new Product() { ProductName = "Guatemala Antigua", Description = "Zarif, rafine, kat kat açılan limon, çikolata ve yumuşak baharat lezzetleri", AddTime = DateTime.Now.AddDays(-17), Price = 140, CategoryId = 1, Imgsource = "https://content.sbuxtr.com/images/8e4f90d74e712f12e5dd4c4feac5f842.jpg" },
                        new Product() { ProductName = "Pike Place® Roast", Description = "Hafif kakao ve kavrulmuş fındık aromalarıyla dengeli ve yumuşak içimli", AddTime = DateTime.Now.AddDays(-42), Price = 150, CategoryId = 1, Imgsource = "https://content.sbuxtr.com/images/543d3158c225fd477b6999c2c703c0f4.jpg" },
                        new Product() { ProductName = "Sumatra", Description = "Ağızda pürüzsüz hissedilen, dolgun gövdeli, bitkisel aromalı bir kahve", AddTime = DateTime.Now.AddDays(-22), Price = 135, CategoryId = 1, Imgsource = "https://content.sbuxtr.com/images/ec3a703c0bc8992603dc7b175bbc6a54.jpg" },
                        new Product() { ProductName = "Starbucks® Espresso Roast", Description = "Yoğun ve zengin aromalar ile karamelsi bir tatlılık", AddTime = DateTime.Now.AddDays(-25), Price = 125, CategoryId = 1, Imgsource = "https://content.sbuxtr.com/images/9419628318d355e82f8f4a610b1ff56c.jpg" },
                        new Product() { ProductName = "Hibiscus Tea", Description = "Bu çay, hatmi çiçeği ve elmanın sulu mayhoşluğunu, turunçgil tadı içeren limon otuyla birleştirerek çekici bir baz oluşturur. ", AddTime = DateTime.Now.AddDays(-5), Price = 50, CategoryId = 2, Imgsource = "https://content.sbuxtr.com/images/46d21637e0facc584c2b6a24f5a4cf9c.jpg" },
                        new Product() { ProductName = "Youthberry Tea", Description = " Ananas, mango ve acai çileği aromalarına sahip bitki çay", AddTime = DateTime.Now.AddDays(-20), Price = 70, CategoryId = 2, Imgsource = "https://content.sbuxtr.com/images/0ce999482ada5f1e8c9dcbfd31704d55.jpg" },
                        new Product() { ProductName = "Mint Blend Tea Box", Description = "Serinletici nane ve yeşil nane lezzetleri", AddTime = DateTime.Now.AddDays(-8), Price = 90, CategoryId = 2, Imgsource = "https://content.sbuxtr.com/images/1c01e5e5508c0083b71717d94438a80c.jpg" },
                        new Product() { ProductName = "Starbucks Seri Desenli Termos", Description = " Starbucks®  yeşil renkli, desenli, plastik termos / 473ml / 16oz, Ürünlerin kullanım talimatları farklılık gösterebilmektedir.", AddTime = DateTime.Now.AddDays(-17), Price = 699, CategoryId = 3, Imgsource = "https://content.sbuxtr.com/images/a3b3537652c5fed81a611a120dc6cacb.jpg" },
                        new Product() { ProductName = "Coffee Press", Description = "Kullanılacak çekirdek kahve Coffee Press ölçüsünde öğütülmelidir. ", AddTime = DateTime.Now.AddDays(-18), Price = 100, CategoryId = 3, Imgsource = "https://content.sbuxtr.com/images/d7882b352b09033f6c54c6b6690619e9.jpg" },
                        new Product() { ProductName = "Starbucks® Reusable Cup", Description = "Sıcak ve soğuk içecekler ile kullanıma uygundur.", AddTime = DateTime.Now.AddDays(-19), Price = 150, CategoryId = 3, Imgsource = "https://content.sbuxtr.com/images/237dca910bcc73d1f98a25b74f7ecda4.jpg" },
                        new Product() { ProductName = "Starbucks® Klasik Seri Termos - Yarı saydam Yeşil Renkli 355ml", Description = "Sıcak ve soğuk içecekler ile kullanıma uygundur.", AddTime = DateTime.Now.AddDays(-22), Price = 180, CategoryId = 3, Imgsource = "https://content.sbuxtr.com/images/6e5010cd1f5fdb961eac947f1f10041e.jpg" },
                        new Product() { ProductName = "Starbucks® Klasik Seri Termos - Mat Yeşil - Siyah Renkli 355ml", Description = "Sıcak ve soğuk içecekler ile kullanıma uygundur.", AddTime = DateTime.Now.AddDays(-24), Price = 220, CategoryId = 3, Imgsource = "https://content.sbuxtr.com/images/25d88e66aa528f5cae8f750ae90bbeaf.jpg" },
                        new Product() { ProductName = "Starbucks® Klasik Seri Termos - Yeşil - Siyah Renkli 473ml", Description = "Sıcak ve soğuk içecekler ile kullanıma uygundur.", AddTime = DateTime.Now.AddDays(-25), Price = 200, CategoryId = 3, Imgsource = "https://content.sbuxtr.com/images/da53eab0f0fc88244ca75ba96a69939d.jpg" },
                        new Product() { ProductName = "Starbucks® Klasik Seri Soğuk İçecek Bardağı-Şeffaf 710 ml", Description = "Sıcak ve soğuk içecekler ile kullanıma uygundur.", AddTime = DateTime.Now.AddDays(-27), Price = 220, CategoryId = 3, Imgsource = "https://content.sbuxtr.com/images/8729a889c8ab147dfc887fcce9126887.jpg" },
                        new Product() { ProductName = "Starbucks® Klasik Seri Termos - Gri-Yeşil Renkli 473ml", Description = "Sıcak ve soğuk içecekler ile kullanıma uygundur.", AddTime = DateTime.Now.AddDays(-28), Price = 280, CategoryId = 3, Imgsource = "https://content.sbuxtr.com/images/2aa28d3c74d6901b178e1920e6fc109c.jpg" }
                );
                    await context.SaveChangesAsync();

                    if (context.Comments.Count() == 0)
                    {
                        context.Comments.AddRange(
                            new Comment() { UserName = "Toprak", Text = "Kahvele bizi Starbuckscı çocuk", ProductId = 1 },
                            new Comment() { UserName = "Murat", Text = "Çok güzel", ProductId = 2 },
                            new Comment() { UserName = "Kadir", Text = "Çok güzel", ProductId = 3 },
                            new Comment() { UserName = "Merve", Text = "Çok güzel", ProductId = 4 },
                            new Comment() { UserName = "Nur", Text = "Çok güzel", ProductId = 5 },
                            new Comment() { UserName = "Emir", Text = "Çok güzel", ProductId = 6 },
                            new Comment() { UserName = "Murat2", Text = "Çok güzel", ProductId = 7 },
                            new Comment() { UserName = "Murat3", Text = "Çok güzel", ProductId = 8 },
                            new Comment() { UserName = "Murat4", Text = "Çok güzel", ProductId = 9 },
                            new Comment() { UserName = "Murat5", Text = "Çok güzel", ProductId = 10 },
                            new Comment() { UserName = "Murat6", Text = "Çok güzel", ProductId = 11 },
                            new Comment() { UserName = "Murat7", Text = "Çok güzel", ProductId = 12 },
                            new Comment() { UserName = "Murat8", Text = "Çok güzel", ProductId = 13 },
                            new Comment() { UserName = "Murat9", Text = "Çok güzel", ProductId = 14 },
                            new Comment() { UserName = "Murat10", Text = "Çok güzel", ProductId = 15 },
                            new Comment() { UserName = "Murat11", Text = "Çok güzel", ProductId = 16 },
                            new Comment() { UserName = "Murat12", Text = "Çok güzel", ProductId = 17 },
                            new Comment() { UserName = "Murat13", Text = "Çok güzel", ProductId = 18 },
                            new Comment() { UserName = "Murat14", Text = "Çok güzel", ProductId = 19 }
                            );
                    };
                    await context.SaveChangesAsync();

                    if (context.Users.Count() == 0)
                    {
                        context.Users.AddRange(
                            new User() { FullName = "toprak", Email = "toprak@hotmail.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Role = Enums.UserRole.USER },
                            new User() { FullName = "kadir", Email = "kadir@hotmail.com", Password = BCrypt.Net.BCrypt.HashPassword("159357"), Role = Enums.UserRole.ADMIN },
                            new User() { FullName = "murat", Email = "murat@hotmail.com", Password = BCrypt.Net.BCrypt.HashPassword("654321"), Role = Enums.UserRole.USER },
                            new User() { FullName = "nur", Email = "nur@hotmail.com", Password = BCrypt.Net.BCrypt.HashPassword("987654"), Role = Enums.UserRole.USER }
                            );
                    };
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}