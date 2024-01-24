using Api.Models;
using Api.Request;
using Api.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrValidationController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public QrValidationController(AppDbContext dbContext) { 
            this.dbContext= dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> getTokenDoc(QrCodeRequest request) {
          
            var data =await dbContext.TbDokumen.Where(d=>d.TokenDokumen == request.TokenDokumen).FirstOrDefaultAsync();
            if (data != null)
            {
                return Ok(new QrTokenResponse{ 
                    token=data.IdDokumen.ToString()
                });
            }
            return BadRequest();
        }

        [HttpPost("{id}")]
        [Authorize]
        public async Task<IActionResult> validasiData(string id) {
            var data = await dbContext.TbDokumen.Where(d => d.IdDokumen == int.Parse(id)).FirstOrDefaultAsync();
            if (data == null)
            {
                return BadRequest();
            }
            var user = await dbContext.TbUsers.Where(u => u.IdUser == int.Parse(User.FindFirstValue(ClaimTypes.SerialNumber))).FirstOrDefaultAsync();
            if (user != null)
            {
                DateTime time = DateTime.Now;
                TbHistory hsi = new TbHistory();
                var historyDokuman = await dbContext.TbHistories.Where(dt => dt.IdDokumen == data.IdDokumen).FirstOrDefaultAsync();
             
                data.IdPenerima = user.IdUser;
                data.TglDiterima=time;
                await dbContext.SaveChangesAsync();
                hsi.IdDokumen= data.IdDokumen;
                hsi.IdUser = user.IdUser;
                hsi.CreatedAt = time;
                await dbContext.TbHistories.AddAsync(hsi);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Unauthorized();
            }

        }

        [Authorize]
        [HttpGet("{id}")]
        public
            async Task<IActionResult> getDataDoc(string id) {
            var data = await (from d in dbContext.TbDokumen
                              where d.IdDokumen == int.Parse(id)
                              select new
                              {
                                  id = d.IdDokumen,
                                  nameDokumen = d.NameDokumen,
                                  agendaDokumen = d.AgendaDokumen,
                                  perihalDokumen = d.PerihalDokumen,
                                  pengirimDokumen = d.PengirimDokumen,
                                  uraianDokumen = d.UraianDokumen,
                                  tglDiterima = d.TglDiterima.ToString("yyyy/MM/dd | HH:mm:ss"),
                                  tglDokumen = d.TglDokumen.ToString("yyyy/MM/dd | HH:mm:ss"),
                                  tglAgendaAwal = d.TglAgendaAwal.ToString("yyyy/MM/dd | HH:mm:ss"),
                                  tglAgendaAkhir = d.TglAgendaAkhir.ToString("yyyy/MM/dd | HH:mm:ss")
                              }).FirstOrDefaultAsync();
            if (data != null) {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }

        private string getToken(string s) { 
            StringBuilder sb=new StringBuilder();
            using (var sha=SHA256.Create())
            {
                var baytes = sha.ComputeHash(Encoding.UTF8.GetBytes(s));
                for (int i = 0; i < baytes.Length; i++)
                {
                    sb.Append(baytes[i].ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}
