using Microsoft.AspNetCore.Mvc;

namespace goodsservice.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodsController : ControllerBase
{
   [HttpGet]
   public string GetGoods()
   {
      Random random = new Random();
      string productToOrder = "";
      switch (random.Next(0,2))
      {
         case 0: productToOrder = "Системный_блок 25000 10";
            break;
         case 1: productToOrder = "AstraLinux_лицензионный_CD 8500 1";
            break;
         case 2: productToOrder = "Бумага_Офисная_A4 350.5 100";
            break;
      }
      return productToOrder;
   }
}
