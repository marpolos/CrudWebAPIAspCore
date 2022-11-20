using CrudWebAPIAspCore.Models;
using CrudWebAPIAspCore.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
// using CrudWebAPIAspCore.Helper;

namespace CrudWebAPIAspCore.Controllers;

[Route("filmes")]
public class FilmesController : Controller
{
    private readonly IFilmeService _service;

    public FilmesController(IFilmeService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var model = _service.GetFilmes();
        var outputModel = ToOutputModel(model);
        return Ok(outputModel);
    }

    [HttpGet("{id}", Name = "GetFilme")]
    public IActionResult Get(int id)
    {
        var model = _service.GetFilme(id);
        if(model == null) return NotFound();
        
        var outputModel = ToOutputModel(model);
        return Ok(outputModel);
    }

    [HttpPost]
    public IActionResult Create([FromBody]FilmeInputModel inputModel)
    {
        if(inputModel == null) return BadRequest();

        /* var filme = new Filme()
        {
            Titulo = inputModel.Titulo,
            Resumo = inputModel.Resumo,
            AnoLancamento = inputModel.AnoLancamento,
        }; */
        var model = ToDomainModel(inputModel);
        _service.AddFilme(model);

        var outputModel = ToOutputModel(model);

        return CreatedAtRoute("GetFilme", new { id = outputModel.Id }, outputModel);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody]FilmeInputModel inputModel)
    {
        if(inputModel == null || id != inputModel.Id) return BadRequest();
        if(!_service.FilmeExists(id)) return NotFound();

        /* var filme = new Filme()
        {
            Titulo = inputModel.Titulo,
            Resumo = inputModel.Resumo,
            AnoLancamento = inputModel.AnoLancamento,
        }; */
        var model = ToDomainModel(inputModel);
        _service.UpdateFilme(model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if(!_service.FilmeExists(id)) return NotFound();
        _service.DeleteFilme(id);
        return NoContent();
    }

    private static FilmeOutputModel ToOutputModel(Filme model)
    {
        return new FilmeOutputModel
        {
            Id = model.Id,
            Titulo = model.Titulo,
            AnoLancamento = model.AnoLancamento,
            Resumo = model.Resumo,
            UltimoAcesso = DateTime.Now
        };
    }

    private static List<FilmeOutputModel> ToOutputModel(List<Filme> model)
    {
        return model.Select(item => ToOutputModel(item)).ToList();
    }

    private static Filme ToDomainModel(FilmeInputModel inputModel)
    {
        return new Filme
        {
            Id = inputModel.Id,
            Titulo = inputModel.Titulo,
            AnoLancamento = inputModel.AnoLancamento,
            Resumo = inputModel.Resumo
        };
    }

    private static FilmeInputModel ToInputModel(Filme model)
    {
        return new FilmeInputModel
        {
            Id = model.Id,
            Titulo = model.Titulo,
            AnoLancamento = model.AnoLancamento,
            Resumo = model.Resumo
        };
    }
}