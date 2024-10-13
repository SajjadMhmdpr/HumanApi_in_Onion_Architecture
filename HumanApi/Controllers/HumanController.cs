
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Mime;
using Domain;
using Domain.UnitOfWork;
using Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HumanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        FileExtensionContentTypeProvider FileExtensionContentTypeProvider;

        public HumanController(IUnitOfWork unitOfWork, IWebHostEnvironment environment, FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            FileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }

        [HttpPost("upload")]
        public async Task<HumanForPostDto> PostHumanWithImage([FromForm] HumanForPostDto human)
        {

            foreach (var item in human.Images)
            {
                await item.SaveImage(_environment.WebRootPath,"Images");
            }


            //set address
            List<Place> places = new List<Place>();
            foreach (var item in human.Addresses)
            {
                places.Add(new Place()
                {
                    Address = item,
                });
            }

            //set image
            List<Img> images = new List<Img>();
            foreach (var item in human.Images)
            {
                images.Add(new Img()
                {
                    Path = "\\Images\\" + item.FileName,
                    Name = item.FileName,
                });
            }



            await _unitOfWork.HumanRepository.Insert(new Human
            {
                Name = human.Name,
                Family = human.Family,
                Addresses = places,
                Images = images,
                Avatar = "\\Images\\" + human.Avatar + ".jpg",
            });

            await _unitOfWork.Commit();

            return await Task.FromResult(human);

        }

        // GET api/<ValuesController>/5
        [HttpGet("HumanC/{id}")]
        public async Task<ActionResult<Human>> GetHumanCompelect(int id)
        {
            var human = await _unitOfWork.HumanRepository.Get(h=>h.Id==id,
                null,
                h=>h.Include(p=>p.Images).Include(p => p.Addresses));

            if (human == null) { 
            
                return NoContent();
            }

            return Ok(human.Single());
            //return Ok(JsonConvert.SerializeObject(human.Single()));
        }
        [HttpGet("Human/{id}")]
        public async Task<ActionResult<Human>> GetHuman(int id)
        {
            var human = await _unitOfWork.HumanRepository.Get(id);
            if (human == null)
            {
                return NoContent();
            }
            return Ok(human);
        }
        [HttpGet("HumanAvatar/{id}")]
        public async Task<ActionResult> GetHumanAvatar(int id)
        {
            var human = await _unitOfWork.HumanRepository.Get(id);
            if (human == null)
            {
                return NoContent();
            }
            var image = await human.Avatar.DownloadImage(_environment.WebRootPath, FileExtensionContentTypeProvider);
            
            if (image == null) { 
                return NoContent();
            }
            return File(image.bytes,image.contentType,image.fileName);
        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var status = await _unitOfWork.HumanRepository.Delete(id);
            if (status)
            {
                await _unitOfWork.Commit();
                return Ok(status);
            }
            return NoContent();
        }

        [HttpGet("image")]
        public ActionResult ShowImage(string name) {
            return Redirect("https://localhost:7105/Images/"+name+".jpg");
        }
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
    }
}
