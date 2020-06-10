namespace SistemaVentas.Model
{
    using System;

    public abstract class BaseModel
    {
        public virtual string fkUsuarioCrea { get; set; }
        public virtual DateTimeOffset? fFechaCrea { get; set; }
        public virtual string fkUsuarioEdita { get; set; }
        public virtual DateTimeOffset? fFechaEdita { get; set; }
        
    }

    public abstract class BaseModelDeleted : BaseModel
    {
        public virtual bool isDeleted { get; set; }
    }
}
