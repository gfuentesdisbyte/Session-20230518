namespace WebApiSample.Models;
using WebApiSample.Core;
using WebApiSample.Infrastructure;
public class Estimate
{
    public EstimateHeader estHeader {get; set;}
    public List<EstimateDetail> estDetails {get; set;}


    //Cambiar estructura como se ve a continuacióm
    //Utilizar para los nombres públicos de las propiedas el estilo PascalCase
    //https://www.freecodecamp.org/news/snake-case-vs-camel-case-vs-pascal-case-vs-kebab-case-whats-the-difference/#:~:text=and%20method%20names.-,What%20is%20Pascal%20Case%3F,first%20word%20is%20in%20lowercase).
    /*
    public int code { get; set; }
    public string own { get; set;}
    public string description { get; set; }
    public string articlefamily {get; set;}
    public string oemsupplier {get; set; }
    public bool ivaexcento {get; set;}
    public double dollarBillete{get;set;}
    public string freighttype {get; set; }
    public string freightfwd {get;set;}
    public double seguro {get;set;}
    public string htimestamp {get; set;}

    public IEnumerable<EstimateDetail> Items {get; private set;}
    */
    
}