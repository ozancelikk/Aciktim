﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RestaurantCommentDetailsDto : IDto
    {
        public string Id { get; set; }
        public string RestaurantName { get; set; }
        public string CustomerName { get; set; }
        public string CommentContent { get; set; }
        public string CommentTitle { get; set; }
        public string CustomerId { get; set; }
        public string CommentDate { get; set; }
        public double RestaurantRate { get; set; }
        public string RestaurantId { get; set; }
        public string Answer { get; set; }
        public string AnswerDate { get; set; }
        public bool Status { get; set; }
    }
}
