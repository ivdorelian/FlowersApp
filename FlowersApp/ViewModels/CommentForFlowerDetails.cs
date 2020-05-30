using FlowersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowersApp.ViewModels
{
    public class CommentForFlowerDetails
    {
        public string Author { get; set; }
        public string Content { get; set; }

        public static CommentForFlowerDetails FromComment(Comment comment)
        {
            return new CommentForFlowerDetails
            {
                Content = comment.Content,
                Author = comment.Author
            };
        }
    }
}
