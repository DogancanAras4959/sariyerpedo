using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.PostData;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Service
{
    public interface IPostService : ICrudService<Post, PostDto>
    {
        List<PostDto> listToKeyword(string keyword);
        List<PostDto> listToCreatedTime();
        List<PostDto> listTakePost(int max);
    }
}
