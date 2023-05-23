using SmartKart.Web.Models;

namespace SmartKart.Web.Data;

public class SmartKartContextSeed
{
    public static async Task SeedAsync(SmartKartContext? smartKartContext, ILoggerFactory loggerFactory, int? retry = 0)
    {
        var retryForAvailability = retry!.Value;

        try
        {
            // TODO: Only run this if using a real database
            // smartKartContext.Database.Migrate();
            // smartKartContext.Database.EnsureCreated();

            if (!smartKartContext!.Categories!.Any())
            {
                smartKartContext.Categories!.AddRange(GetPreconfiguredCategories());
                await smartKartContext.SaveChangesAsync();
            }

            if (!smartKartContext.Products!.Any())
            {
                smartKartContext.Products?.AddRange(GetPreconfiguredProducts());
                await smartKartContext.SaveChangesAsync();
            }
        }
        catch (Exception exception)
        {
            if (retryForAvailability >= 10) throw;
            retryForAvailability++;
            var log = loggerFactory.CreateLogger<SmartKartContextSeed>();
            log.LogError(exception.Message);
            await SeedAsync(smartKartContext, loggerFactory, retryForAvailability);

            throw;
        }
    }

    private static IEnumerable<Category> GetPreconfiguredCategories()
    {
        return new List<Category>
        {
            new()
            {
                Name = "iOS",
                Description =
                    "iOS (formerly iPhone OS[9]) is a mobile operating system developed by Apple Inc. exclusively for its hardware. It is the operating system that powers many of the company's mobile devices, including the iPhone; the term also includes the system software for iPads predating iPadOS.",
                ImageName = "one"
            },
            new()
            {
                Name = "Android",
                Description =
                    "Android is a mobile operating system based on a modified version of the Linux kernel and other open-source software, designed primarily for touchscreen mobile devices such as smartphones and tablets. Android is developed by a consortium of developers known as the Open Handset Alliance, though its most widely used version is primarily developed by Google. ",
                ImageName = "two"
            }
        };
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        return new List<Product>
        {
            new()
            {
                Name = "IPhone X",
                Summary =
                    "The iPhone X uses a glass and stainless-steel form factor and \"bezel-less\" design, shrinking the bezels while not having a \"chin\", unlike many Android phones.",
                Description =
                    "It is the first iPhone to use an OLED screen. The screen is a Super Retina HD display. The home button's fingerprint sensor was replaced with a new type of authentication called Face ID, which used sensors to scan the user's face to unlock the device. This face-recognition capability also enabled emojis to be animated following the user's expression (Animoji).",
                ImageFile = "product-1.png",
                Price = 950.00M,
                CategoryId = 1
            },
            new()
            {
                Name = "Samsung S10",
                Summary =
                    "The Samsung Galaxy S10 is a line of Android-based smartphones manufactured, released and marketed by Samsung Electronics as part of the Samsung Galaxy S series.",
                Description =
                    "The Galaxy S10 series is the tenth generation of the Samsung Galaxy S, its flagship line of phones next to the Note models, which is also the 10th anniversary of the Galaxy S.",
                ImageFile = "product-2.png",
                Price = 840.00M,
                CategoryId = 2
            },
            new()
            {
                Name = "Huawei Plus",
                Summary =
                    "TThe Huawei P series (formerly the Ascend P series) is a line of high-end and medium-range Android smartphones produced by Huawei.                                ",
                Description =
                    "Under the company's current hardware release cadence, P series phones are typically directed towards mainstream consumers as the company's flagship smartphones, refining and expanding upon technologies introduced in Mate series devices.",
                ImageFile = "product-3.png",
                Price = 650.00M,
                CategoryId = 2
            },
            new()
            {
                Name = "Xiaomi Mi 9",
                Summary =
                    "The Xiaomi Mi 9 is a flagship Android smartphone developed by Xiaomi Inc.                                                                                          ",
                Description =
                    "The Xiaomi Mi 9 is powered by the Qualcomm Snapdragon 855 processor, with 6 GB or 8 GB LPDDR4X RAM and the Adreno 640 GPU. It has a 6.39-inch (162 mm) FHD+ AMOLED display. Storage options include 64 GB or 128 GB. The handset features a fingerprint scanner under the display.",
                ImageFile = "product-4.png",
                Price = 470.00M,
                CategoryId = 2
            },
            new()
            {
                Name = "HTC U11+ Plus",
                Summary =
                    "Features a 6-inch 2:1 display (marketed as 18:9) with thinner bezels, a larger battery, and a rear-mounted fingerprint reader.                                      ",
                Description =
                    "The HTC U series is a line of upper mid-range and high-end flagship Android smartphones developed and produced by HTC. The first phones in the series, the HTC U Play and the HTC U Ultra, were announced in January 2017. The HTC U series is the successor of the HTC One series.                            ",
                ImageFile = "product-5.png",
                Price = 380.00M,
                CategoryId = 2
            },
            new()
            {
                Name = "LG G7 ThinQ",
                Summary =
                    "An Android smartphone developed by LG Electronics as part of the LG G series.                                                                                        ",
                Description =
                    "The LG G7 ThinQ utilizes a metal chassis with a glass backing, and is IP68-rated for water and dust-resistance. It is available in black, blue, rose and silver-color finishes. The G7 features a 1440p FullVision IPS LCD display, with a diagonal size of 6.1 inches. The display uses a 19:9 aspect ratio that is taller than the 18:9 displays used by the majority of smartphones, such as the Samsung Galaxy S9.",
                ImageFile = "product-6.png",
                Price = 240.00M,
                CategoryId = 2
            }
        };
    }
}