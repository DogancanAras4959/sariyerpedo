using AutoMapper;
using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.PostData;
using sariyerpedo.BUSSINES.Service;
using sariyerpedo.CORE.Repository;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Engine
{
    public class PostService : CrudService<Post, PostDto>, IPostService
    {
        public PostService(IRepository<Post> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public List<PostDto> listToCreatedTime()
        {
            var entity = _repository.Where(x => x.Id > 0).OrderByDescending(x => x.CreatedTime).ToList();
            var entityDto = _mapper.Map<List<Post>, List<PostDto>>(entity);
            return entityDto;
        }

        public List<PostDto> listTakePost(int max)
        {
            var entity = _repository.Where(x => x.IsActive == true).OrderByDescending(x => x.CreatedTime).Take(max).ToList();
            var entityDto = _mapper.Map<List<Post>, List<PostDto>>(entity);
            return entityDto;
        }

        public List<PostDto> listToKeyword(string keyword)
        {
            var entity = _repository.Where(x => x.title!.Contains(keyword) && x.IsActive == true).OrderByDescending(x => x.CreatedTime).ToList();
            var entityDto = _mapper.Map<List<Post>, List<PostDto>>(entity);
            return entityDto;
        }
    }
}
