using WebApp.Models;

namespace WebApp.Services;

public class ShowcaseService
{
    private readonly List<ShowcaseModel> _showcases = new() 
    { 
        new ShowcaseModel()
        {
            Ingress = "WELCOME TO BMERKETO SHOP",
            Title = "Exclusive Chair gold Collection.",
            ImageUrl = "images/placeholders/625x647.svg",
            Button = new LinkButtonModel
            {
                Content = "SHOP NOW",
                Url = "/products",
            }
        },
        new ShowcaseModel()
        {
            Ingress = "BMERKETO THE BEST A PERSON CAN GET",
            Title = "Now with all new spices",
            ImageUrl = "images/placeholders/625x647.svg",
            Button = new LinkButtonModel
            {
                Content = "SHOP NOW",
                Url = "/products",
            }
        }
    };


    public ShowcaseModel GetLatest()
    {
        return _showcases.LastOrDefault()!;
    }

}
