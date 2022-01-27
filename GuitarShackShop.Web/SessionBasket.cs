using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GuitarShackShop.Web
{
    public class SessionBasket
    {
        private readonly ISession _session;

        public SessionBasket(ISession session)
        {
            _session = session;
        }

        public Basket GetBasket()
        {
            string basketJson = _session.GetString("basket");
            Basket basket;

            if (basketJson == null)
            {
                basket = new Basket();

                SetBasket(basket);
            }
            else
            {
                basket = JsonConvert.DeserializeObject<Basket>(basketJson);
            }

            return basket;
        }

        public void SetBasket(Basket basket)
        {
            _session.SetString("basket", JsonConvert.SerializeObject(basket));
        }
    }
}