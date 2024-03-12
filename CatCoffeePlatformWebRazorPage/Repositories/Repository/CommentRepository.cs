using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public async void ChangeStatusByAdmin(int CommentId)
        {
            CommentDAO.Instance.ChangeStatusByAdmin(CommentId);
        }

        public async void CreateCommentByUser(Comment request)
        {
            CommentDAO.Instance.CreateCommentByUser(request);
        }

        public async Task<IList<CommentInformation>> GetAllCommentByAdmin()
        {
            return await CommentDAO.Instance.GetAllCommentByAdmin();
        }

        public async Task<IList<CommentInformation>> GetAllCommentOItem(int shopId)
        {
            return await CommentDAO.Instance.GetAllCommentOItem(shopId);
        }

        public async void UpdateCommentByUser(Comment request)
        {
            CommentDAO.Instance.UpdateCommentByUser(request);
        }
    }
}
