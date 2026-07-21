using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishPort.Models
{
    public  class Comment
    {
        //自動連番で付与されるID
        public int Id { get; set; }
        
        public int PortId { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string CommentText { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //ナビゲーションプロパティ
        public ApplicationUser? User { get; set; }

        public Port? Port { get; set; }


        ///// <summary>
        ///// テーブルに指定のデータが存在しない場合、データを挿入する
        ///// </summary>
        ///// <param name="context">DbContextのオブジェクト</param>
        //public static void Initializa(DbContext context)
        //{
        //    var t = context.Set<Area>();
        //    if (t.Any() == false)
        //    {
        //        t.AddRange(
        //              new Area() { Name = "北海道" },
        //                new Area() { Name = "青森県" },
        //                new Area() { Name = "岩手県" },
        //                new Area() { Name = "宮城県" },
        //                new Area() { Name = "秋田県" },
        //                new Area() { Name = "山形県" },
        //                new Area() { Name = "福島県" },
        //                new Area() { Name = "茨城県" },
        //                new Area() { Name = "栃木県" },
        //                new Area() { Name = "群馬県" },
        //                new Area() { Name = "埼玉県" },
        //                new Area() { Name = "千葉県" },
        //                new Area() { Name = "東京都" },
        //                new Area() { Name = "神奈川県" },
        //                new Area() { Name = "新潟県" },
        //                new Area() { Name = "富山県" },
        //                new Area() { Name = "石川県" },
        //                new Area() { Name = "福井県" },
        //                new Area() { Name = "山梨県" },
        //                new Area() { Name = "長野県" },
        //                new Area() { Name = "岐阜県" },
        //                new Area() { Name = "静岡県" },
        //                new Area() { Name = "愛知県" },
        //                new Area() { Name = "三重県" },
        //                new Area() { Name = "滋賀県" },
        //                new Area() { Name = "京都府" },
        //                new Area() { Name = "大阪府" },
        //                new Area() { Name = "兵庫県" },
        //                new Area() { Name = "奈良県" },
        //                new Area() { Name = "和歌山県" },
        //                new Area() { Name = "鳥取県" },
        //                new Area() { Name = "島根県" },
        //                new Area() { Name = "岡山県" },
        //                new Area() { Name = "広島県" },
        //                new Area() { Name = "山口県" },
        //                new Area() { Name = "徳島県" },
        //                new Area() { Name = "香川県" },
        //                new Area() { Name = "愛媛県" },
        //                new Area() { Name = "高知県" },
        //                new Area() { Name = "福岡県" },
        //                new Area() { Name = "佐賀県" },
        //                new Area() { Name = "長崎県" },
        //                new Area() { Name = "熊本県" },
        //                new Area() { Name = "大分県" },
        //                new Area() { Name = "宮崎県" },
        //                new Area() { Name = "鹿児島県" },
        //                new Area() { Name = "沖縄県" }

        //            );
        //        context.SaveChanges();
        //    }
        //}
    }
}
