using Hakaton.Domain.Models.Models;
using Hakaton.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hakaton.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController
    {
        private readonly PhotoEditor _photoEditor;
        public PhotoController(PhotoEditor photoEditor)
        {
            _photoEditor = photoEditor;
        }

        [HttpPost("Add")]
        public async Task<JsonResult> AddPhoto([FromBody] PathPhoto photo)
        {
            var result = await _photoEditor.AddPhoto(photo.PhotoId, photo.Path);
            return new JsonResult("")
            {
                StatusCode = 200,
                Value = JsonConvert.SerializeObject(new { PathPhotoId =  result })
            };
        }
        [HttpDelete("Remove")]
        public async Task<JsonResult> Delete(int photoId)
        {
            var result = await _photoEditor.Delete(photoId);
            return new JsonResult("")
            {
                StatusCode = 200,
                Value = JsonConvert.SerializeObject(new { Status = true })
            };
        }
    }
}
