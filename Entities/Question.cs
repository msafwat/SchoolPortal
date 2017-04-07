using Entities.CustomAttributes;
using GlobalizationResources;
using GlobalizationResources.Resources.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Entities
{
    public class Question
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Validations))]
        [LocalizedDisplayName(ResourcesType.Questions, "Title")]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Validations))]
        [LocalizedDisplayName(ResourcesType.Questions, "Question")]
        //[DataType(DataType.MultilineText)]
        //[AllowHtml]
        public string Text { get; set; }

        [LocalizedDisplayName(ResourcesType.Questions, "Explanation")]
        //[AllowHtml]
        public string Explanation { get; set; }

        [Required]
        public short QuestionLevelId { get; set; }

        public QuestionLevel QuestionLevel { get; set; }

        [Required]
        public short QuestionTypeId { get; set; }

        [Required]
        public QuestionType QuestionType { get; set; }

        [Required]
        public short QuestionPrivacyId { get; set; }

        [Required]
        public QuestionPrivacy QuestionPrivacy { get; set; }

        [Required]
        public List<Answer> Answers { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime LastModifiedDateTime { get; set; }
    }
}
