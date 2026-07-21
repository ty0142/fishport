using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishPort.Models
{
    public  class Prefecture
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string PrefectureName { get; set; } = string.Empty;

        /// <summary>
        /// テーブルに指定のデータが存在しない場合、データを挿入する
        /// </summary>
        /// <param name="context">DbContextのオブジェクト</param>
        public static void Initialize(DbContext context)
        {
            var t = context.Set<Prefecture>();
            if (t.Any() == false)
            {
                t.AddRange(
                      new Prefecture() { PrefectureName = "北海道" },
                        new Prefecture() { PrefectureName = "青森県" },
                        new Prefecture() { PrefectureName = "岩手県" },
                        new Prefecture() { PrefectureName = "宮城県" },
                        new Prefecture() { PrefectureName = "秋田県" },
                        new Prefecture() { PrefectureName = "山形県" },
                        new Prefecture() { PrefectureName = "福島県" },
                        new Prefecture() { PrefectureName = "茨城県" },
                        new Prefecture() { PrefectureName = "栃木県" },
                        new Prefecture() { PrefectureName = "群馬県" },
                        new Prefecture() { PrefectureName = "埼玉県" },
                        new Prefecture() { PrefectureName = "千葉県" },
                        new Prefecture() { PrefectureName = "東京都" },
                        new Prefecture() { PrefectureName = "神奈川県" },
                        new Prefecture() { PrefectureName = "新潟県" },
                        new Prefecture() { PrefectureName = "富山県" },
                        new Prefecture() { PrefectureName = "石川県" },
                        new Prefecture() { PrefectureName = "福井県" },
                        new Prefecture() { PrefectureName = "山梨県" },
                        new Prefecture() { PrefectureName = "長野県" },
                        new Prefecture() { PrefectureName = "岐阜県" },
                        new Prefecture() { PrefectureName = "静岡県" },
                        new Prefecture() { PrefectureName = "愛知県" },
                        new Prefecture() { PrefectureName = "三重県" },
                        new Prefecture() { PrefectureName = "滋賀県" },
                        new Prefecture() { PrefectureName = "京都府" },
                        new Prefecture() { PrefectureName = "大阪府" },
                        new Prefecture() { PrefectureName = "兵庫県" },
                        new Prefecture() { PrefectureName = "奈良県" },
                        new Prefecture() { PrefectureName = "和歌山県" },
                        new Prefecture() { PrefectureName = "鳥取県" },
                        new Prefecture() { PrefectureName = "島根県" },
                        new Prefecture() { PrefectureName = "岡山県" },
                        new Prefecture() { PrefectureName = "広島県" },
                        new Prefecture() { PrefectureName = "山口県" },
                        new Prefecture() { PrefectureName = "徳島県" },
                        new Prefecture() { PrefectureName = "香川県" },
                        new Prefecture() { PrefectureName = "愛媛県" },
                        new Prefecture() { PrefectureName = "高知県" },
                        new Prefecture() { PrefectureName = "福岡県" },
                        new Prefecture() { PrefectureName = "佐賀県" },
                        new Prefecture() { PrefectureName = "長崎県" },
                        new Prefecture() { PrefectureName = "熊本県" },
                        new Prefecture() { PrefectureName = "大分県" },
                        new Prefecture() { PrefectureName = "宮崎県" },
                        new Prefecture() { PrefectureName = "鹿児島県" },
                        new Prefecture() { PrefectureName = "沖縄県" }

                    );
                context.SaveChanges();
            }
        }
    }
}
