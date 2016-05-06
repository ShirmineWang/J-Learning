using J_LearingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace J_Learning.Web.Models {
    public class CreateTopicModel {
        public CreateTopicModel() {
            Id= Guid.NewGuid().ToString("N");
        }
        public Topic Topic { get; set; }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CourseId { get; set; }
    }
}