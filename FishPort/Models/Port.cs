using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishPort.Models
{
    public  class Port
    {
        //自動連番で付与されるID
        public int Id { get; set; }
        public int AreaId { get; set; } // 外部キーとしてのAreaIdプロパティを追加

        [Required]
        [StringLength(20)]
        public string PortName { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        public string? Description { get; set; } // 追加の説明フィールドを追加（必要に応じて）

        //ナビゲーションプロパティ
        public Area? Area { get; set; }
        public ICollection<Comment> Comments { get; set; }=new List<Comment>();


        ///// <summary>
        ///// テーブルに指定のデータが存在しない場合、データを挿入する
        ///// </summary>
        ///// <param name="context">DbContextのオブジェクト</param>
        //public static void Initializa(DbContext context)
        //{
        //    var t = context.Set<Port>();
        //    if (t.Any() == false)
        //    {
        //        t.AddRange(
        //              new Port() { PortName = "北海道" },
        //                new Port() { PortName = "青森県" },
        //                new Port() { PortName = "岩手県" },
        //                new Port() { PortName = "宮城県" },
        //                new Port() { PortName = "秋田県" },
        //                new Port() { PortName = "山形県" },
        //                new Port() { PortName = "福島県" },
        //                new Port() { PortName = "茨城県" },
        //                new Port() { PortName = "栃木県" },
        //                new Port() { PortName = "群馬県" },
        //                new Port() { PortName = "埼玉県" },
        //                new Port() { PortName = "千葉県" },
        //                new Port() { PortName = "東京都" },
        //                new Port() { PortName = "神奈川県" },
        //                new Port() { PortName = "新潟県" },
        //                new Port() { Name = "富山県" },
        //                new Port() { Name = "石川県" },
        //                new Port() { Name = "福井県" },
        //                new Port() { Name = "山梨県" },
        //                new Port() { Name = "長野県" },
        //                new Port() { Name = "岐阜県" },
        //                new Port() { Name = "静岡県" },
        //                new Port() { Name = "愛知県" },
        //                new Port() { Name = "三重県" },
        //                new Port() { Name = "滋賀県" },
        //                new Port() { Name = "京都府" },
        //                new Port() { Name = "大阪府" },
        //                new Port() { Name = "兵庫県" },
        //                new Port() { Name = "奈良県" },
        //                new Port() { Name = "和歌山県" },
        //                new Port() { Name = "鳥取県" },
        //                new Port() { Name = "島根県" },
        //                new Port() { Name = "岡山県" },
        //                new Port() { Name = "広島県" },
        //                new Port() { Name = "山口県" },
        //                new Port() { Name = "徳島県" },
        //                new Port() { Name = "香川県" },
        //                new Port() { Name = "愛媛県" },
        //                new Port() { Name = "高知県" },
        //                new Port() { Name = "福岡県" },
        //                new Port() { Name = "佐賀県" },
        //                new Port() { Name = "長崎県" },
        //                new Port() { Name = "熊本県" },
        //                new Port() { Name = "大分県" },
        //                new Port() { Name = "宮崎県" },
        //                new Port() { Name = "鹿児島県" },
        //                new Port() { Name = "沖縄県" }

        //            );
        //        context.SaveChanges();
        //    }
        //}
    }
}
