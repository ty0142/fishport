using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishPort.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(20)]
        public string NickName { get; set; } = string.Empty;

        //ナビゲーションプロパティ
        public ICollection<Comment> Comments { get; set; }=new List<Comment>();
    }
}
