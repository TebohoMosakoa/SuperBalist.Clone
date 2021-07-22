using Catalog.Api.Models;
using Catalog.Api.Repositories.Shared;
using Catalog.Api.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : EntityBase
        where TRepository : IRepositoryBase<TEntity>
    {
        private readonly TRepository repository;
        private readonly ICloudStorage _cloudStorage;

        protected BaseController(TRepository repository, ICloudStorage cloudStorage)
        {
            this.repository = repository;
            _cloudStorage = cloudStorage;
        }

        private async Task UploadMainFile(TEntity item)
        {
            string fileNameForStorage = FormFileName(item.Name, item.MainImageFile.FileName);
            item.MainImageUrl = await _cloudStorage.UploadFileAsync(item.MainImageFile, fileNameForStorage);
            item.MainImageStorageName = fileNameForStorage;
        }
        private async Task UploadImage2(TEntity item)
        {
            string fileNameForStorage = FormFileName(item.Name, item.Image2File.FileName);
            item.Image2Url = await _cloudStorage.UploadFileAsync(item.Image2File, fileNameForStorage);
            item.Image2StorageName = fileNameForStorage;
        }
        private async Task UploadImage3(TEntity item)
        {
            string fileNameForStorage = FormFileName(item.Name, item.Image3File.FileName);
            item.Image3Url = await _cloudStorage.UploadFileAsync(item.Image3File, fileNameForStorage);
            item.Image3StorageName = fileNameForStorage;
        }

        private static string FormFileName(string title, string fileName)
        {
            var fileExtension = Path.GetExtension(fileName);
            var fileNameForStorage = $"{title}-{DateTime.Now:yyyyMMddHHmmss}{fileExtension}";
            return fileNameForStorage;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var item = await repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            if (item.MainImageFile != null)
            {
                if(item.MainImageStorageName != null)
                {
                    await _cloudStorage.DeleteFileAsync(item.MainImageStorageName);
                }
                await UploadMainFile(item);
            }
            if (item.Image2File != null)
            {
                if (item.Image2StorageName != null)
                {
                    await _cloudStorage.DeleteFileAsync(item.Image2StorageName);
                }
                await UploadImage2(item);
            }
            if (item.Image3File != null)
            {
                if (item.Image3StorageName != null)
                {
                    await _cloudStorage.DeleteFileAsync(item.Image3StorageName);
                }
                await UploadImage3(item);
            }
            await repository.Update(item);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity item)
        {
            if(item.MainImageFile != null)
            {
                await UploadMainFile(item);
            }
            if (item.Image2File != null)
            {
                await UploadImage2(item);
            }
            if (item.Image3File != null)
            {
                await UploadImage3(item);
            }
            await repository.Add(item);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var item = await repository.Delete(id);
            if (item == null)
            {
                return NotFound();
            }
            if (item.MainImageStorageName != null)
            {
                await _cloudStorage.DeleteFileAsync(item.MainImageStorageName);
            }
            if (item.Image2StorageName != null)
            {
                await _cloudStorage.DeleteFileAsync(item.Image2StorageName);
            }
            if (item.Image3StorageName != null)
            {
                await _cloudStorage.DeleteFileAsync(item.Image3StorageName);
            }
            return item;
        }
    }
}
