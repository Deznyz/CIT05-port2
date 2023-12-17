using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/principals")]
[ApiController]
public class PrincipalsController : BaseController
{
    private readonly IDataService _dataService;

    public PrincipalsController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet(Name = nameof(GetPrincipals))]
    public IActionResult GetPrincipals(int page = 0, int pageSize = 10)
    {
        (var principals, var total) = _dataService.GetPrincipals(page, pageSize);

        var items = principals.Select(CreatePrincipalsModel);

        var result = Paging(items, total, page, pageSize, nameof(GetPrincipals));

        return Ok(result);

    }


    [HttpGet("{principalsId}", Name = nameof(GetPrincipal))]
    public IActionResult GetPrincipal(int principalsId)
    {
        var principal = _dataService.GetPrincipal(principalsId);
        if (principal == null)
        {
            return NotFound();
        }

        return Ok(principal);
    }

    [HttpPut("{principalsId}", Name = nameof(UpdatePrincipals))]
    public IActionResult UpdatePrincipals(int principalsId, CreatePrincipalsModel model)
    {
        var existPrincipals = _dataService.GetPrincipal(principalsId);

        if (existPrincipals != null)
        {
            var updatePrincipals = new Principals
            {
                PrincipalsId = model.PrincipalsId,
                TitleId = model.TitleId,
                Ordering = model.Ordering,
                NameId = model.NameId,
                JobCategory = model.JobCategory,
                Job = model.Job,
                Role = model.Role
            };

            _dataService.UpdatePrincipals(principalsId, updatePrincipals);
            return Ok(existPrincipals);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult CreatePrincipals(CreatePrincipalsModel model)
    {
        var principals = new Principals
        {
            PrincipalsId = model.PrincipalsId,
            TitleId = model.TitleId,
            Ordering = model.Ordering,
            NameId = model.NameId,
            JobCategory = model.JobCategory,
            Job = model.Job,
            Role = model.Role
        };

        _dataService.CreatePrincipals(principals);

        var principalsUri = Url.Link("GetPrincipals", new { principalsId = principals.PrincipalsId });

        return Created(principalsUri, principals);
    }

    private PrincipalsModel CreatePrincipalsModel(Principals principals)
    {
        return new PrincipalsModel
        {
            Url = GetUrl(nameof(GetPrincipal), new { principals.PrincipalsId}),
            PrincipalsId = principals.PrincipalsId,
            TitleId = principals.TitleId,
            Ordering = principals.Ordering,
            NameId = principals.NameId,
            JobCategory = principals.JobCategory,
            Job = principals.Job,
            Role = principals.Role
        };
    }
}

