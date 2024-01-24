using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListPenerimaController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ListPenerimaController(AppDbContext dbContext) {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> getListPenerima(string id) {
            var data = await (from h in dbContext.TbHistories
                              join u in dbContext.TbUsers
                              on h.IdUser equals u.IdUser
                              join d in dbContext.TbDokumen
                                on h.IdDokumen equals d.IdDokumen
                              select new
                              {
                                  id=h.IdDokumen,
                                  namaPenerima=u.Name,
                                  tgl_diterima=h.CreatedAt.ToString("dd/MM/yyyy | HH:mm")
                              }).ToListAsync();
            if (data == null )
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }
    }
}
