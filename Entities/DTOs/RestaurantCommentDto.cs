using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RestaurantCommentDto : IDto
    {
        public string RestaurantId { get; set; }
        public string CustomerId { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public string CommentDate { get; set; }
        public double RestaurantRate { get; set; }
    }
}
