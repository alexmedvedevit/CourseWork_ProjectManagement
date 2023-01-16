using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace contractservice.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractController : ControllerBase
{
    private HttpClient _client;

    public ContractController()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://goodsservice:80");
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Вас приветствует сервис исполнения контрактов!");
    }
    
    [HttpGet("contract")]
    public IActionResult NetworkRequest()
    {
        var input = _client.GetAsync("Goods").Result;
        string prodStr = input.Content.ReadAsStringAsync().Result;
        prodStr = prodStr.Substring(1, prodStr.Length-2);
        string[] productArr = prodStr.Split(" ");

        string name = productArr[0];
        double amount = Convert.ToDouble(productArr[2]),
            price = Convert.ToDouble(productArr[1]);
        

        Random random = new Random();
        int contractNum = random.Next(0,300);
        
         return Ok("Сведения о муниципальном контракте №"+contractNum+" от "+DateTime.Today+"\n" +
                  "Производится закупка "+name+" в размере "+amount+" шт."+"\n" +
                  "Цена единицы товара без НДС: "+price+" рублей"+"\n" +
                  "Цена контракта: "+amount*(price+price*0.2)+" рублей");
    }
}
