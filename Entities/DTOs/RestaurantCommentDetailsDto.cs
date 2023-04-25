using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RestaurantCommentDetailsDto : IDto
    {
        public string RestaurantName { get; set; }
        public string CustomerName { get; set; }
        public string CommentContent { get; set; }
        public string CommentTitle { get; set; }
        public string CommentDate { get; set; }
        public double RestaurantRate { get; set; }
    }
}
