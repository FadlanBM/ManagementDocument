using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocListController : ControllerBase
    {

        private readonly AppDbContext dbContext;
        private string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\image\";
        public DocListController(AppDbContext dbContext) { 
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetData() {
            var data = await (from h in dbContext.TbHistories
                              join d in dbContext.TbDokumen
                              on h.IdDokumen equals d.IdDokumen
                              join u in dbContext.TbUsers
                              on h.IdUser equals u.IdUser
                              where h.IdUser == int.Parse(User.FindFirstValue(ClaimTypes.SerialNumber))
                              select new
                              {
                                  Id = h.IdDokumen,
                                  nameDoc = d.NameDokumen,
                                  tglAgendaawal = d.TglAgendaAwal.ToString("dd/MM/yyyy | HH:mm"),
                                  tglagendaAkhir = d.TglAgendaAkhir.ToString("dd/MM/yyyy | HH:mm"),
                                  tglDoc = d.TglDokumen.ToString("dd/MM/yyyy | HH:mm"),
                                  tglTerima = d.TglDiterima.ToString("dd/MM/yyyy | HH:mm"),
                              }).ToListAsync();
            return Ok(data);


        }

    }
}
