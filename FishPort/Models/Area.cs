using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishPort.Models
{
    public class Area
    {
        //自動連番で付与されるID
        public int Id { get; set; }
        public int PrefectureId { get; set; }
        [Required]
        [StringLength(50)]
        public string AreaName { get; set; } = string.Empty;

        //ナビゲーションプロパティ
        public Prefecture? Prefecture { get; set; }
        public ICollection<Port> Ports { get; set; } = new List<Port>();


        /// <summary>
        /// テーブルに指定のデータが存在しない場合、データを挿入する
        /// </summary>
        /// <param name="context">DbContextのオブジェクト</param>
        public static void Initialize(DbContext context)
        {
            var t = context.Set<Area>();
            if (t.Any() == false)
            {
                t.AddRange(
                        new Area() { PrefectureId = 40, AreaName = "福岡市西区エリア" },
                        new Area() { PrefectureId = 40, AreaName = "糸島エリア" },
                        new Area() { PrefectureId = 40, AreaName = "宗像・福津エリア" },
                        new Area() { PrefectureId = 40, AreaName = "北九州エリア" },
                        new Area() { PrefectureId = 40, AreaName = "遠賀・芦屋エリア" },
                        new Area() { PrefectureId = 40, AreaName = "有明海エリア" },
                        new Area() { PrefectureId = 41, AreaName = "唐津エリア" },
                        new Area() { PrefectureId = 41, AreaName = "呼子エリア" },
                        new Area() { PrefectureId = 41, AreaName = "伊万里エリア" },
                        new Area() { PrefectureId = 41, AreaName = "有明海エリア" }
                    );
                context.SaveChanges();
            }
        }
    }
}
