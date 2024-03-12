using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ICommentRepository
    {
        void CreateCommentByUser(Comment request);
        void UpdateCommentByUser(Comment request);
        void ChangeStatusByAdmin(int CommentId);
        Task<IList<CommentInformation>> GetAllCommentOItem(int shopId);
        Task<IList<CommentInformation>> GetAllCommentByAdmin();


    }
}
