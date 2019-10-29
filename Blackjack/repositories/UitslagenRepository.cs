using Blackjack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.repository
{
    public class UitslagenRepository
    {
        private SpellenEntities2 context = new SpellenEntities2();

        public IEnumerable<uitslagen> GetUitslagen()
        {
            return context.uitslagens.AsEnumerable();
        }
        public void SetBankBySpelerID(int spelerID, int spelID, int bankSaldo)
        {
            var spelersaldo = context.uitslagens.First(u => u.speler_ID == spelerID && u.spel_ID == spelID);
            spelersaldo.Bank = bankSaldo;
            context.SaveChanges();
        }
        
        public int GetBankBySpelerID(int spelerID, int spelID)
        {
            var uitslag = context.uitslagens.First(u => u.speler_ID == spelerID && u.spel_ID == spelID);
            return (int)uitslag.Bank;
        }

        public void MakeUitslagRow(uitslagen uitslag)
        {
            context.uitslagens.Add(uitslag);
            context.SaveChanges();
        }

        public bool CheckUitslag(int spelerID, int spelID)
        {
            return context.uitslagens.Any(u => u.speler_ID == spelerID && u.spel_ID == spelID);
        }

    }
}


//public class BrandRepository
//{
//    private BikeStoresEntities context = new BikeStoresEntities();

//    public IEnumerable<brand> GetBrands()
//    {
//        return context.brands.AsEnumerable();
//    }

//    public brand GetBrandByName(string name)
//    {
//        return context.brands.Single(b => b.brand_name == name);
//    }

//    public void AddNewBrand(brand brand)
//    {
//        context.brands.Add(brand);
//        context.SaveChanges();
//    }

//    public void UpdateBrand(brand brand)
//    {
//        context.SaveChanges();
//    }

//    public void DeleteBrand(brand brand)
//    {
//        context.brands.Remove(brand);
//        context.SaveChanges();
//    }

//}