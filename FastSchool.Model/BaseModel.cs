using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastSchool.Model
{
    /// <summary>
    /// 所有实体的基类
    /// </summary>
    public class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid();
            Code = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
            IsDelete = false;
        }

        [Key]
        public Guid Id { get; set; }

        //唯一标识
        public Guid Code { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public DateTime LastEitDateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
    }
}
