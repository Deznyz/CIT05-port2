using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebServer.Controllers;

public class BaseController : ControllerBase
{
    private readonly LinkGenerator _linkGenerator;

    public BaseController(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    protected object Paging<T>(IEnumerable<T> items, int total, int page, int pageSize, string endpointName)
    {

        var numPages = (int)Math.Ceiling(total / (double)pageSize);
        var next = page < numPages - 1
            ? GetUrl(endpointName, new { page = page + 1, pageSize })
        : null;
        var prev = page > 0
            ? GetUrl(endpointName, new { page = page - 1, pageSize })
        : null;

        var cur = GetUrl(endpointName, new { page, pageSize });

        return new
        {
            Total = total,
            NumberOfPages = numPages,
            Next = next,
            Prev = prev,
            Current = cur,
            Items = items
        };
    }

    protected string GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values) ?? "Not specified";
    }
}