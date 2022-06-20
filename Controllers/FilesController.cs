using _StarbucksApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _StarbucksApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        //Post api/files
        [HttpPost("")]
        public async Task<ActionResult<ResponseResource>> Upload() 
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Files", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var uniqueFileName = GetUniqueFileName(file.FileName);
                    var fullPath = Path.Combine(pathToSave, uniqueFileName);
                    var dbPath = Path.Combine(folderName, uniqueFileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(ResponseResource.GenerateResponse(dbPath));
                }
                else
                {
                    return BadRequest(ResponseResource.GenerateResponse(null, false, "İşlem başarısız!"));
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ResponseResource.GenerateResponse(null, false, ex.ToString()));
            }
            
        }


        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
