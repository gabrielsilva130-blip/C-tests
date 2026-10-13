using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Text.Json;
namespace TreinoApi.Controllers;
//I.A do caralho, para de ficar controlando a porra do meu código, to aprendendo C#. Porra. Obrigado : )
public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public int Idade { get; set; }
}



[ApiController]
[Route("[controller]")]
public class AlunosController : ControllerBase
{
    private static List<Aluno> alunos = new List<Aluno>() {
        new Aluno
        {
            Id = 1,
            Nome = "Nero",
            Idade = 17
        },

        new Aluno
        {
            Id = 2,
            Nome = "Carlos",
            Idade = 18
        }
    };
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(alunos);
    }
    [HttpGet("{Id:int}")]
    public IActionResult GetByID(int id)
    {
        var aluno = alunos.FirstOrDefault(a => a.Id == id);

        if (aluno == null)
            return NotFound();

        return Ok(aluno);
    }
    [HttpPost]
    public IActionResult Post(int Id, string Nome, int Idade)
    {
        alunos.Add(new Aluno() { Id, Nome, Idade });
    }
}